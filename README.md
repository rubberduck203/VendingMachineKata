# VendingMachineKata

My implementation of [Guy Royse's][1] [Vending Machine Kata][2].

  [1]:https://github.com/guyroyse
  [2]:https://github.com/guyroyse/vending-machine-kata

# Design

Vending machines are really just [Finite State Machines][3] and can be implemented in hardware. If the wikipedia article above is a bit too heavy, there's a great video from Computerphile, [Computers without memory][4].

Being we're building a state machine, I suspect we'll make use of the state pattern once we move beyong simply accepting/rejecting coins.

  [3]:https://en.wikipedia.org/wiki/Finite-state_machine
  [4]:https://www.youtube.com/watch?v=vhiiia1_hC4

The following display states exist:
 1. Price
 2. Thank you!
 3. Insert Coin
 4. Current Total

*Note:*
So, we did end up with a state machine of sorts, but not the one I expected.
It would be interesting to do this again as an actual finite state machine.
One that doesn't keep track of the coins.

Maybe more suited for a different kata. Perhaps a Parking Meter Kata.