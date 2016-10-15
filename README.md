# VendingMachineKata

My implementation of [Guy Royse's][1] [Vending Machine Kata][2].

  [1]:https://github.com/guyroyse
  [2]:https://github.com/guyroyse/vending-machine-kata

# Design

Vending machines are really just [Finite State Machines][3] and can be implemented in hardware. If the wikipedia article above is a bit too heavy, there's a great video from Computerphile, [Computers without memory][4].

Being we're building a state machine, I suspect we'll make use of the state pattern.

  [3]:https://en.wikipedia.org/wiki/Finite-state_machine
  [4]:https://www.youtube.com/watch?v=vhiiia1_hC4

The following display states exist:
 1. No Money (Insert Coin)
 2. Money (Current Value)
 3. Display Price
 4. Display Thank you!
 5. Sold Out
 6. Exact Change (not implemented yet)

TODO: Add state diagram from notebook