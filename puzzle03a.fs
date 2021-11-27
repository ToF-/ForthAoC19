0 CONSTANT RIGHT-DIR
1 CONSTANT DOWN-DIR
2 CONSTANT LEFT-DIR
3 CONSTANT UP-DIR

20 CONSTANT COORD-BITS
1 COORD-BITS LSHIFT 1- CONSTANT COORD-MASK
1 COORD-BITS 1- LSHIFT CONSTANT COORD-SIGN-BIT
COORD-MASK -1 XOR CONSTANT NEGATIVE-COORD-MASK

: COORD>CELL ( coord -- n )
    COORD-MASK AND
    DUP COORD-SIGN-BIT AND IF
        NEGATIVE-COORD-MASK OR
    THEN ;

: EXTRACT-COORD ( w -- w',coord )
    COORD-BITS RSHIFT DUP COORD>CELL ;

: VERTICAL? ( dir -- b )
    1 AND ;

: ORTHOGONAL? ( dir1,dir2 -- b )
    VERTICAL? SWAP VERTICAL? XOR ;

: WIRE, ( n,dir -- )
    COORD-BITS LSHIFT SWAP
    COORD-MASK AND OR , ;

: WIRE-R ( n -- )
    RIGHT-DIR WIRE, ;

: WIRE-D ( n -- )
    DOWN-DIR WIRE, ;

: WIRE-L ( n -- )
    LEFT-DIR WIRE, ;

: WIRE-U ( n -- )
    UP-DIR WIRE, ;

: WIRE@ ( addr -- dir,n )
    @ DUP COORD-BITS RSHIFT
    SWAP COORD>CELL ;

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


: LINE>CELL ( dir,pos,p0,pN )
    2SWAP SWAP COORD-BITS 3 * LSHIFT SWAP
    COORD-MASK AND COORD-BITS 2 * LSHIFT OR
    -ROT SWAP COORD-MASK AND COORD-BITS LSHIFT
    SWAP COORD-MASK AND OR OR ;

: CELL>LINE ( w -- dir,pos,p0,pN )
    DUP COORD>CELL >R
    EXTRACT-COORD >R
    EXTRACT-COORD >R
    COORD-BITS RSHIFT R> R> R> ;

: LINE@ ( addr -- dir,pos,p0,pN )
    @ CELL>LINE ;

VARIABLE ROW
VARIABLE COLUMN

: WIRE>ROW-COL! ( dir,n -- )
    OVER RIGHT-DIR = IF
        COLUMN +!
    ELSE OVER DOWN-DIR = IF
        NEGATE ROW +!
    ELSE OVER LEFT-DIR = IF
        NEGATE COLUMN +!
    ELSE ROW +!
    THEN THEN THEN DROP ;

: WIRE>LINE>CELLS ( srce,dest,size --  )
    0 ROW ! 0 COLUMN !
    0 DO                   ( srce,dest )
        OVER WIRE@         ( srce,dest,dir,n )
        ROW @ COLUMN @     ( srce,dest,dir,n,row,col )
        2SWAP WIRE>LINE    ( srce,dest,dir,pos,p0,pN )
        LINE>CELL          ( srce,dest,w )
        OVER !             ( srce,dest )
        OVER WIRE@         ( srce,dest,dir,n )
        WIRE>ROW-COL!      ( srce,dest )
        CELL+ SWAP         ( dest',srce )
        CELL+ SWAP         ( srce',dest' )
    LOOP 2DROP ;
        
