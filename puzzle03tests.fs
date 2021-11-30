
INCLUDE ffl/tst.fs
INCLUDE puzzle03.fs

." WIRE>CELL converts row col steps and intersection distance to a cell" CR
    42 -17 4807 13 WIRE>CELL
." CELL>WIRE converts a cell to row,col,steps and intersection distance" CR
   CELL>WIRE
   13 ?S 4807 ?S -17 ?S 42 ?S


." WIRES creates a new list of wires with a first point at 0,0" CR
    WIRES CIRCUIT-0
    CIRCUIT-0 @ CELL>WIRE -1 ?S 0 ?S 0 ?S 0 ?S
." END-WIRES compiles a end of circcuit mark
    END-WIRES
    CIRCUIT-0 CELL+ @ CELL>WIRE 0 ?S 0 ?S 0 ?S 0 ?S

." WIRE- words, compile a wire to the right, with current steps, no intersection" CR
    WIRES CIRCUIT-1
    42 WIRE-R,
    17 WIRE-U,
    10 WIRE-L,
    37 WIRE-D,
    END-WIRES
    CIRCUIT-1 1 CELLS + @ CELL>WIRE -1 ?S 42 ?S 42 ?S 0 ?S
    CIRCUIT-1 2 CELLS + @ CELL>WIRE -1 ?S 59 ?S 42 ?S 17 ?S
    CIRCUIT-1 3 CELLS + @ CELL>WIRE -1 ?S 69 ?S 32 ?S 17 ?S
    CIRCUIT-1 4 CELLS + @ CELL>WIRE -1 ?S 106 ?S 32 ?S -20 ?S

." VERTICAL? says if a line is vertical or not" CR
    0 0 100 0 VERTICAL? TRUE ?S
    10 23 10 47 VERTICAL? FALSE ?S

." ORTHOGONAL? says if two lines are orthogonal" CR
    0 0 100 0  0 0 0 50 ORTHOGONAL? TRUE ?S
    0 0 0 100  0 0 0 50 ORTHOGONAL? FALSE ?S

." WITHIN+ tells if a value is within a range" CR
    40 0 100 WITHIN+ TRUE ?S
    100 0 100 WITHIN+ TRUE ?S
    101 0 100 WITHIN+ FALSE ?S
    -1 0 100 WITHIN+ FALSE ?S
    -5 0 -100 WITHIN+ TRUE ?S
    0 0 -100 WITHIN+ TRUE ?S
    -100 0 -100 WITHIN+ TRUE ?S
    -101 0 -100 WITHIN+ FALSE ?S
    1 0 -100 WITHIN+ FALSE ?S

." INTERSECT! stores an intersection at a given step of a wire" CR
    WIRES CIRCUIT-2
    8 WIRE-R, 5 WIRE-U, 5 WIRE-L, 3 WIRE-D,
    END-WIRES
    23 CIRCUIT-2 1 CELLS + INTERSECT! 
    CIRCUIT-2 1 CELLS + @ CELL>WIRE 23 ?S 8 ?S 8 ?S 0 ?S

." VERTICAL-INTERSECT? tells is a vertical intersects a horizontal and at which point" CR
    10 15 30 15 20 5 20 50 VERTICAL-INTERSECT? TRUE ?S SWAP 20 ?S 15 ?S
    10 15 30 15  9 5  9 50 VERTICAL-INTERSECT? FALSE ?S
    10 15 30 15 31 5 31 50 VERTICAL-INTERSECT? FALSE ?S
    10 15 30 15 20 0 20 14 VERTICAL-INTERSECT? FALSE ?S
    10 15 30 15 20 16 20 24 VERTICAL-INTERSECT? FALSE ?S
." HORIZONTAL-INTERSECT? tells is a horizontak intersects a vertical and at which point" CR
    20 5 20 50 10 15 30 15 HORIZONTAL-INTERSECT? TRUE ?S SWAP 20 ?S 15 ?S 

." DISTANCES tells the distances (row and col) from the start of a line to a point of that line" CR
    10 20 0 20 40 20 DISTANCES SWAP 10 ?S 0 ?S 
    15 20 15 10 15 30 DISTANCES SWAP 0 ?S 10 ?S 
    -12 10 10 10 -15 10 DISTANCES SWAP 22 ?S 0 ?S
    -12 10 -15 10 -5 10 DISTANCES SWAP 3 ?S 0 ?S
    34 10 34 4 34 40 DISTANCES SWAP 0 ?S 6 ?S
    34 10 34 40 34 4 DISTANCES SWAP 0 ?S 30 ?S

    WIRES CIRCUIT-A
    \ R8,U5,L5,D3,
    8 WIRE-R, 5 WIRE-U, 5 WIRE-L, 3 WIRE-D,
    END-WIRES
    WIRES CIRCUIT-B
    \ U7,R6,D4,L4,
    7 WIRE-U, 6 WIRE-R, 4 WIRE-D, 4 WIRE-L,
    END-WIRES

." @INTERSECT? tells if two wires intersect and at what point" CR
    CIRCUIT-A 3 CELLS + CIRCUIT-B 3 CELLS + @INTERSECT? TRUE ?S SWAP 5 ?S 6 ?S
    CIRCUIT-A 2 CELLS + CIRCUIT-B 3 CELLS + @INTERSECT? FALSE ?S 
    CIRCUIT-A 3 CELLS + CIRCUIT-B 2 CELLS + @INTERSECT? FALSE ?S 
    CIRCUIT-A 4 CELLS + CIRCUIT-B 4 CELLS + @INTERSECT? TRUE ?S SWAP 3 ?S 3 ?S

." INTERSECT! stores an intersection step value at wires which intersect" CR
    5 6 CIRCUIT-A 3 CELLS + CIRCUIT-B 3 CELLS + @INTERSECTS!
    CIRCUIT-A 3 CELLS + @ CELL>WIRE 15 ?S DROP 2DROP 
    CIRCUIT-B 3 CELLS + @ CELL>WIRE 15 ?S DROP 2DROP 
    3 3 CIRCUIT-A 4 CELLS + CIRCUIT-B 4 CELLS + @INTERSECTS!
    CIRCUIT-A 4 CELLS + @ CELL>WIRE 20 ?S DROP 2DROP 
    CIRCUIT-B 4 CELLS + @ CELL>WIRE 20 ?S DROP 2DROP 

BYE

