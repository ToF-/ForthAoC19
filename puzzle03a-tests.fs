INCLUDE ffl/tst.fs
INCLUDE puzzle03a.fs

CREATE EXPECTED 32 CELLS ALLOT
CREATE ACTUAL   32 CELLS ALLOT
VARIABLE MAX-VALUES
VARIABLE CURRENT-VALUE

: N-EXPECTED! ( ......*N,n -- )
    1- BEGIN                           ( a..m,n,c )
            DUP 0 >= WHILE             ( a..m,n,c )
            TUCK                       ( a..m,c,n,c )
            CELLS EXPECTED + !         ( a..m,c )
            1-                         ( a..l,m,c )
    REPEAT                             ( -1 )
    DROP ;

: N-ACTUAL! ( ......*N,n -- )
    1- BEGIN                           ( a..m,n,c )
            DUP 0 >= WHILE             ( a..m,n,c )
            TUCK                       ( a..m,c,n,c )
            CELLS ACTUAL + !           ( a..m,c )
            1-                         ( a..l,m,c )
    REPEAT                             ( -1 )
    DROP ;

: N-COMPARE ( n -- )
    0 DO
        ACTUAL I CELLS + @
        EXPECTED I CELLS + @
        ?S
    LOOP ;

: N?S ( a...z,n -- )
    DUP >R N-EXPECTED!
    R@ N-ACTUAL!
    R> N-COMPARE ;

T{ ." directions can be orthogonal or not" CR
    LEFT-DIR UP-DIR ORTHOGONAL?     1 ?S
    LEFT-DIR RIGHT-DIR ORTHOGONAL?  0 ?S
    DOWN-DIR RIGHT-DIR ORTHOGONAL?  1 ?S
    UP-DIR DOWN-DIR ORTHOGONAL?     0 ?S
}T


T{ ." WIRE WORDS compile a wire in a direction" CR
    CREATE WIRES
    8 WIRE-R 5 WIRE-U 5 WIRE-L 3 WIRE-D
    WIRES 0 CELLS + WIRE@ RIGHT-DIR 8  2 N?S
    WIRES 1 CELLS + WIRE@ UP-DIR 5     2 N?S
    WIRES 2 CELLS + WIRE@ LEFT-DIR 5   2 N?S
    WIRES 3 CELLS + WIRE@ DOWN-DIR 3   2 N?S
}T

T{ ." WIRE>LINE convert a location and a wire into a line" CR
    100 200 RIGHT-DIR 8 WIRE>LINE RIGHT-DIR 100 200 208 4 N?S
    100 200 UP-DIR 5 WIRE>LINE    UP-DIR 200 100 105    4 N?S
    100 200 LEFT-DIR 3 WIRE>LINE  LEFT-DIR 100 197 200  4 N?S
    100 200 DOWN-DIR 7 WIRE>LINE   DOWN-DIR 200 93 100  4 N?S
}T

T{ ." LINE>CELL convert a line into a single cell" CR
    -100 200 UP-DIR 5 WIRE>LINE LINE>CELL
    100 -200 LEFT-DIR 3 WIRE>LINE LINE>CELL
   ." CELL>LINE CONVERT A CELL INTO A LINE" CR
    CELL>LINE LEFT-DIR 100 -203 -200  4 N?S
    CELL>LINE UP-DIR 200 -100 -95     4 N?S
}T

T{ ." WIRE>ROW-COL! update coords from wire" CR
    0 ROW ! 0 COLUMN !
    RIGHT-DIR 100 WIRE>ROW-COL!
    ROW @ 0 ?S COLUMN @ 100 ?S
}T

T{ ." WIRE>LINE>CELLS store wire lines as cells" CR
    CREATE LINE-CELLS 4 CELLS ALLOT
    WIRES LINE-CELLS 4 WIRE>LINE>CELLS
    LINE-CELLS 0 CELLS + LINE@    RIGHT-DIR 0 0 8     4 N?S
    LINE-CELLS 1 CELLS + LINE@    UP-DIR    8 0 5     4 N?S
    LINE-CELLS 2 CELLS + LINE@    LEFT-DIR  5 3 8     4 N?S
    LINE-CELLS 3 CELLS + LINE@    DOWN-DIR  3 2 5     4 N?S
}T

T{ ." INTERSECTION? find an intersection between two orthogonal lines" CR
    CREATE B-WIRES
    7 WIRE-U 6 WIRE-R 4 WIRE-D 4 WIRE-L
    CREATE B-LINE-CELLS 4 CELLS ALLOT
    B-WIRES B-LINE-CELLS 4 WIRE>LINE>CELLS
    LINE-CELLS 4 B-LINE-CELLS 4 INTERSECTIONS!
    MAX-INTERSECTION @ 3 ?S
    INTERSECTIONS 0 CELLS + @ CELL>COORDS 0 0 2 N?S
    INTERSECTIONS 1 CELLS + @ CELL>COORDS 5 6 2 N?S
    INTERSECTIONS 2 CELLS + @ CELL>COORDS 3 3 2 N?S
}T
    
BYE
