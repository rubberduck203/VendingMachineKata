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
 1. No Money (Insert Coin/Exact Change)
 2. Money (Current Value)
 3. Display Price
 4. Display Thank you!
 5. Sold Out

TODO: Add state diagram from notebook

# Future Improvements

 - The change making algorithm does find opitmal results, but the Exact Change Only algorithm does not.
   - Move to the [Greedy Algorithm][5] to make it a more robust solution all around.
 - I don't care for the fact that the abstract base `VendingMachineState` class has knowledge of its inheritors.
   - It was implemented this way to centralize logic that would have otherwise had to have been implemented in each of the child classes.
   - Find a way to decouple it.
 - There are several missing states. A few of the states have `if...then` logic that should really be represented as different states unto themselves.