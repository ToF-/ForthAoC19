1 CONSTANT RIGHT-DIR
2 CONSTANT DOWN-DIR
3 CONSTANT LEFT-DIR
4 CONSTANT UP-DIR

: EVEN? ( n -- b )
    1 AND 0= ;

: ORTHOGONAL? ( dir1,dir2 -- b )
    EVEN? SWAP EVEN? XOR ;

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

