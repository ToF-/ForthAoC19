0 CONSTANT RIGHT-DIR
1 CONSTANT DOWN-DIR
2 CONSTANT LEFT-DIR
3 CONSTANT UP-DIR

: ORTHOGONAL? ( dir1,dir2 -- b )
    2 < SWAP 2 < XOR ;

: WIRE, ( n,dir -- )
    16 LSHIFT OR , ;

: WIRE-R ( n -- )
    RIGHT-DIR WIRE, ;

: WIRE-D ( n -- )
    DOWN-DIR WIRE, ;

: WIRE-L ( n -- )
    LEFT-DIR WIRE, ;

: WIRE-U ( n -- )
    UP-DIR WIRE, ;

: WIRE@ ( addr -- dir,n )
    @ DUP 16 RSHIFT SWAP 65535 AND ;

: RIGHT-WIRE>LINE ( row,col,n -- R,row,col,col+n )
    OVER +
    ROT RIGHT-DIR SWAP
    2SWAP ;

: LEFT-WIRE>LINE ( row,col,n -- L,row,col-n,col )
    OVER >R -
    SWAP LEFT-DIR
    SWAP ROT R> ;

: UP-WIRE>LINE ( row,col,n -- U,col,row,row+n )
    ROT TUCK +
    ROT UP-DIR SWAP
    2SWAP ;

: DOWN-WIRE>LINE ( row,col,n -- D,col,row-n,row )
    ROT DUP      ( col,n,row,row )
    ROT - SWAP   ( col,row-n,row )
    ROT DOWN-DIR SWAP
    2SWAP ;

: WIRE>LINE ( row,col,dir,n -- dir,pos,p0,pN )
    SWAP
    DUP RIGHT-DIR = IF
        DROP RIGHT-WIRE>LINE
    ELSE DUP UP-DIR = IF
        DROP UP-WIRE>LINE
    ELSE LEFT-DIR = IF
        LEFT-WIRE>LINE
    ELSE
        DOWN-WIRE>LINE
    THEN THEN THEN ;

20 CONSTANT COORD-BITS
1 COORD-BITS LSHIFT 1- CONSTANT COORD-MASK

: LINE>CELL ( dir,pos,p0,pN )
    2SWAP SWAP COORD-BITS 3 * LSHIFT SWAP
    COORD-MASK AND COORD-BITS 2 * LSHIFT OR
    -ROT SWAP COORD-MASK AND COORD-BITS LSHIFT
    SWAP COORD-MASK AND OR OR ;

: CELL>LINE ( w -- dir,pos,p0,pN )
    DUP COORD-MASK AND >R
    COORD-BITS RSHIFT DUP COORD-MASK AND >R
    COORD-BITS RSHIFT DUP COORD-MASK AND >R
    COORD-BITS RSHIFT R> R> R> ;
