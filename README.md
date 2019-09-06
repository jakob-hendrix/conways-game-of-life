# Conway's Game of Life

This is my follow along of Jeremy Clark's walkthrough of Conway's Game of Life.

The goal is to create a simulation that models cells that are either alive or dead based on the following rules:

* any live cell with fewer tan two live neighbors dies
* any live cell with two or three live neighbors lives.
* any live cell with more than three neighbors dies.
* any dead cell with three neighbors becomes a live cell

Instructions can be found at:
* https://jeremybytes.blogspot.com/2014/11/adding-simple-ui-for-conways-game-of.html
* https://jeremybytes.blogspot.com/2014/11/optimizing-conways-game-of-life-with.html

## Key Notes:

### On Parallelization:

https://jeremybytes.blogspot.com/2014/11/optimizing-conways-game-of-life-with.html

So what makes this conducive to running in parallel? First, I created this as a static method. This means that the method does not belong to a particular instance of a class; it stands on its own.

Next, the method itself does not modify any state or instance data. The method takes in 2 values (the current state and the number of live neighbors) and returns a new value (the new state of the cell). Since "CellState" is an enum (a value type), this means that the return value is a separate value even if we return the parameter unmodified.

Because this method is an atomic operation that does not modify shared state, we can call this method at the same time on different threads without worry.
