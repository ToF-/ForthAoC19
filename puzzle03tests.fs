
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
}T

T{ ." WIRE-R, compiles a wire to the right, with current steps, no intersection" CR
    WIRES CIRCUIT-B
    42 WIRE-R, 
    42 ?S 42 ?S 0 ?S
    CIRCUIT-B 1 CELLS + @ CELL>WIRE -1 ?S 42 ?S 42 ?S 0 ?S
}T

BYE

