
INCLUDE ffl/tst.fs
INCLUDE puzzle03.fs

T{ ." WIRE>CELL converts row col steps and intersection distance to a cell" CR
    42 -17 4807 13 WIRE>CELL
   ." CELL>WIRE converts a cell to row,col,steps and intersection distance" CR
   CELL>WIRE
   13 ?S 4807 ?S -17 ?S 42 ?S
}T

BYE

