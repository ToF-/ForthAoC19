
INCLUDE ffl/tst.fs
INCLUDE puzzle03.fs

T{ ." WIRE>CELL converts row col steps and intersection distance to a cell" CR
    42 -17 4807 13 WIRE>CELL
   ." CELL>WIRE converts a cell to row,col,steps and intersection distance" CR
   CELL>WIRE
   13 ?S 4807 ?S -17 ?S 42 ?S
}T

T{ ." WIRES creates a new list of wires with a first point at 0,0" CR
    WIRES CIRCUIT-A
    CIRCUIT-A @ CELL>WIRE -1 ?S 0 ?S 0 ?S 0 ?S
    END-WIRES
}T

T{ ." WIRE- words, compile a wire to the right, with current steps, no intersection" CR
    WIRES CIRCUIT-B
    42 WIRE-R,
    17 WIRE-U,
    10 WIRE-L,
    37 WIRE-D,
    END-WIRES
    CIRCUIT-B 1 CELLS + @ CELL>WIRE -1 ?S 42 ?S 42 ?S 0 ?S
    CIRCUIT-B 2 CELLS + @ CELL>WIRE -1 ?S 59 ?S 42 ?S 17 ?S
    CIRCUIT-B 3 CELLS + @ CELL>WIRE -1 ?S 69 ?S 32 ?S 17 ?S
    CIRCUIT-B 4 CELLS + @ CELL>WIRE -1 ?S 106 ?S 32 ?S -20 ?S
}T

T{ ." VERTICAL? says if a line is vertical or not" CR
    0 0 100 0 VERTICAL? TRUE ?S
    10 23 10 47 VERTICAL? FALSE ?S
}T

T{ ." ORTHOGONAL? says if two lines are orthogonal" CR
    0 0 100 0  0 0 0 50 ORTHOGONAL? TRUE ?S
    0 0 0 100  0 0 0 50 ORTHOGONAL? FALSE ?S
}T

T{ ." INTERSECT! stores an intersection at a given step of a wire" CR
    WIRES CIRCUIT-C
    8 WIRE-R, 5 WIRE-U, 5 WIRE-L, 3 WIRE-D,
    END-WIRES
    23 CIRCUIT-C 1 CELLS + INTERSECT! 
    CIRCUIT-C 1 CELLS + @ CELL>WIRE 23 ?S 8 ?S 8 ?S 0 ?S
}T
    

BYE

