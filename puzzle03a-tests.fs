INCLUDE ffl/tst.fs
INCLUDE puzzle03a.fs

T{ ." DIRECTIONS CAN BE ORTHOGONAL OR NOT" CR
    LEFT-DIR UP-DIR ORTHOGONAL?     1 ?S
    LEFT-DIR RIGHT-DIR ORTHOGONAL?  0 ?S
    DOWN-DIR RIGHT-DIR ORTHOGONAL?  1 ?S
    UP-DIR DOWN-DIR ORTHOGONAL?     0 ?S
}T


T{ ." WIRE WORDS COMPILE A WIRE IN A DIRECTION" CR
    CREATE WIRES
    8 WIRE-R 5 WIRE-U 5 WIRE-L 3 WIRE-D
    WIRES 0 CELLS + WIRE@ 8 ?S RIGHT-DIR ?S
    WIRES 1 CELLS + WIRE@ 5 ?S UP-DIR ?S
    WIRES 2 CELLS + WIRE@ 5 ?S LEFT-DIR ?S
    WIRES 3 CELLS + WIRE@ 3 ?S DOWN-DIR ?S
}T

: <---->S ( a,b,c,d -- d,c,b,a )
    SWAP 2SWAP SWAP ;

T{ ." WIRE>LINE CONVERT A LOCATION AND A WIRE INTO A LINE" CR
    100 200 RIGHT-DIR 8 WIRE>LINE
    <---->S
    RIGHT-DIR ?S 100 ?S 200 ?S 208 ?S

    100 200 UP-DIR 5 WIRE>LINE
    <---->S
    UP-DIR ?S 200 ?S 100 ?S 105 ?S

    100 200 LEFT-DIR 3 WIRE>LINE
    <---->S
    LEFT-DIR ?S 100 ?S 197 ?S 200 ?S

    100 200 DOWN-DIR 7 WIRE>LINE
    <---->S
    DOWN-DIR ?S 200 ?S 93 ?S 100 ?S
}T

T{ ." LINE>CELL CONVERT A LINE INTO A SINGLE CELL" CR
    -100 200 UP-DIR 5 WIRE>LINE LINE>CELL
    100 -200 LEFT-DIR 3 WIRE>LINE LINE>CELL
   ." CELL>LINE CONVERT A CELL INTO A LINE" CR
    CELL>LINE <---->S
    LEFT-DIR ?S 100 ?S -203 ?S -200 ?S
    CELL>LINE <---->S
    UP-DIR ?S 200 ?S -100 ?S -95 ?S
}T

BYE
