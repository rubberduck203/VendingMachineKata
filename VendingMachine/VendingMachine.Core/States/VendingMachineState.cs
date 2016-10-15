using System.Collections.Generic;
using System.Linq;

namespace Vending.Core.States
{
    public abstract class VendingMachineState
    {
        protected VendingMachineState(VendingMachineState state)
            :this(state.Context, state.ReturnTray, state.CoinSlot, state.ProductInfoRepository, state.Output)
        { }

        protected VendingMachineState(StateContext context, List<Coin> returnTray, List<Coin> coinSlot, ProductInfoRepository productInfoRepository, List<string> output)
        {
            Context = context;
            CoinSlot = coinSlot;
            ProductInfoRepository = productInfoRepository;
            Output = output;
            ReturnTray = returnTray;
        }

        protected internal StateContext Context { get; }
        public List<Coin> CoinSlot { get; }
        public List<Coin> ReturnTray { get; }
        protected internal List<string> Output { get; }
        protected internal ProductInfoRepository ProductInfoRepository { get; }

        public abstract string Display();
        protected abstract void DispenseCallback(string sku);

        public int CurrentTotal()
        {
            var counts = new Dictionary<Coin, int>()
            {
                {Coin.Nickel, 0},
                {Coin.Dime, 0},
                {Coin.Quarter, 0}
            };

            foreach (var coin in CoinSlot)
            {
                counts[coin]++;
            }

            var total = 0;
            foreach (var coinCount in counts)
            {
                total += (coinCount.Value * coinCount.Key.Value());
            }

            return total;
        }

        public void Refund(int currentTotal, int? priceInCents)
        {
            var calculator = new RefundCalculator();
            var refund = calculator.CalculateRefund(priceInCents ?? 0, currentTotal);

            foreach (var coinCount in refund)
            {
                ReturnTray.AddRange(Enumerable.Repeat(coinCount.Key, coinCount.Value));
            }
        }

        public void ReturnCoins()
        {
            ReturnTray.AddRange(CoinSlot);
            CoinSlot.Clear();
            Context.State = new NoMoneyState(this);
        }

        public void Accept(Coin coin)
        {
            if (coin.Value() == 0)
            {
                ReturnTray.Add(coin);
                return;
            }

            CoinSlot.Add(coin);
            Context.State = new CurrentValueState(this);
        }

        public void Dispense(string sku)
        {
            if (ProductInfoRepository.GetQuantityAvailable(sku) == 0)
            {
                Context.State = new SoldOutState(this);
                return;
            }

            DispenseCallback(sku);
        }
    }
}
