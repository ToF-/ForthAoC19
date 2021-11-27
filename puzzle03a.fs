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

: COORDS>CELL ( row,col -- n )
    COORD>CELL SWAP
    COORD>CELL COORD-BITS LSHIFT OR ;

: CELL>COORDS ( n -- row,col )
    DUP COORD-BITS RSHIFT COORD>CELL
    SWAP COORD>CELL ;

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
    ." STORING LINES" CR ." FROM 0 0 " CR
    0 ROW ! 0 COLUMN !
    0 DO                   ( srce,dest )
        OVER WIRE@         ( srce,dest,dir,n )
        ROW @ COLUMN @     ( srce,dest,dir,n,row,col )
        2SWAP WIRE>LINE    ( srce,dest,dir,pos,p0,pN )
        LINE>CELL          ( srce,dest,w )
        OVER !             ( srce,dest )
        OVER WIRE@         ( srce,dest,dir,n )
        WIRE>ROW-COL!      ( srce,dest )
        ."   TO " ROW ? COLUMN ? CR
        CELL+ SWAP         ( dest',srce )
        CELL+ SWAP         ( srce',dest' )
    LOOP 2DROP ;

: INTERSECTION? ( addr1,addr2 -- row,col,T | F )
    OVER LINE@ 2DROP DROP           ( addr1,addr2,dir1 )
    OVER LINE@ 2DROP DROP           ( addr1,addr2,dir1,dir2 )
    2DUP ORTHOGONAL? IF             ( addr1,addr2,dir1,dir2 )
        DROP VERTICAL? 0=
        IF SWAP THEN                ( addr2,addr1 )
        LINE@                       ( addr,H,row,c0,cN )
        ROT >R ROT DROP             ( addr1,c0,cN { row } )
        ROT LINE@                   ( c0,cN,V,col,r0,rN { row } )
        ROT >R ROT DROP             ( c0,cN,r0,rN { row,col } )
        2R@ SWAP                    ( c0,cN,r0,rN,col,row { row,col } )
        2SWAP                       ( c0,cN,col,row,r0,rN { row,col } )
        1+ WITHIN                   ( c0,cN,col,f1 { row,col } )
        SWAP 2SWAP                  ( f1,col,c0,cN { row,col } )
        1+ WITHIN AND               ( f { row,col } )
        2R> ROT IF                  ( row,col )
            TRUE                    ( row,col,T )
        ELSE
            2DROP FALSE             ( F )
        THEN
    ELSE
        2DROP 2DROP FALSE
    THEN ;

CREATE INTERSECTIONS 100 CELLS ALLOT
VARIABLE MAX-INTERSECTION

: INTERSECTIONS! ( addr1,size1,addr2,size2 -- )
    ." FINDING INTERSECTIONS" CR
    0 MAX-INTERSECTION !
    0 DO                       ( addr1,size1,addr2 )
        OVER 0 DO                ( addr1,size1,addr2 )
            DUP I CELLS +        ( addr1,size1,addr2,addr2+i )
            2SWAP OVER J CELLS + ( addr2,addr2+i,addr1,size1,addr1+j )
            -ROT 2SWAP           ( addr2,addr1,size1,addr2+i,addr1+j )
            INTERSECTION? IF     ( addr2,addr1,size1,row,col )
                2DUP SWAP . . CR
                COORDS>CELL
                INTERSECTIONS
                MAX-INTERSECTION @ CELLS + !
                1 MAX-INTERSECTION +!
            THEN ROT             ( addr1,size1,addr2 )
        LOOP
    LOOP DROP 2DROP ;
