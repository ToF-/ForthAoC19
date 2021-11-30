
: WITHIN+ ( a,b,c -- b<=a<=c )
    2DUP > IF SWAP THEN
    1+ WITHIN ;

16 CONSTANT WORD-BITS
1 WORD-BITS LSHIFT 1- CONSTANT WORD-MASK
1 WORD-BITS 1- LSHIFT CONSTANT SIGN-BIT
WORD-MASK -1 XOR CONSTANT NEGATIVE-CELL-MASK

: WORD>CELL ( w -- n )
    DUP SIGN-BIT AND IF
        NEGATIVE-CELL-MASK OR
    THEN ;

: <<WORD| ( n,w -- w:n )
    WORD-BITS LSHIFT SWAP WORD-MASK AND OR ;

: |WORD>> ( w -- n,w' )
    DUP WORD-MASK AND WORD>CELL
    SWAP WORD-BITS RSHIFT ;

: WIRE>CELL ( row,col,steps,dist? -- w )
      0 <<WORD| <<WORD| <<WORD| <<WORD| ;

: CELL>WIRE ( w -- row,col,steps,dist? )
    |WORD>> |WORD>> |WORD>> |WORD>> DROP ;

: WIRES ( 'name' -- 0,0,0 )
    CREATE 0 0 0 -1 WIRE>CELL , 
    0 0 0 ;

: END-WIRES ( row,col,steps -- )
    0 0 0 0 WIRE>CELL ,
    DROP 2DROP ;

: WIRE, ( row,col,steps -- row,col,steps )
    -1 2OVER 2OVER           ( r,c,s,f,r,c,s,f )
    WIRE>CELL , DROP ;       ( row,col',steps' )
    
: WIRE-R, ( row,col,steps,dist -- row',col',steps' )
    DUP -ROT +               ( row,col,dist,steps' )
    -ROT + SWAP              ( row,col',steps' )
    WIRE, ;                  ( row,col',steps' )

: WIRE-U, ( row,col,steps,dist -- row',col',steps' )
    DUP -ROT +               ( row,col,dist,steps' )
    >R ROT + SWAP R>         ( row',col,steps' )
    WIRE, ;                  ( row',col,steps' )

: WIRE-L, ( row,col,steps,dist -- row',col',steps' )
    DUP -ROT +               ( row,col,dist,steps' )
    >R - R>                  ( row,col',steps' )
    WIRE, ;                  ( row,col',steps' )

: WIRE-D, ( row,col,steps,dist -- row',col',steps' )
    DUP -ROT +               ( row,col,dist,steps' )
    >R NEGATE ROT + SWAP R>  ( row',col,steps' )
    WIRE, ;                  ( row',col,steps' )

: VERTICAL? ( row,col,row',col' -- f )
    ROT = -ROT <> AND ;

: ORTHOGONAL? ( r0,c0,rn,cn,r0',c0,rn',cn' )
    VERTICAL? >R VERTICAL? R> <> ;

: INTERSECT! ( steps,addr -- )
    SWAP >R
    DUP @ CELL>WIRE DROP R> WIRE>CELL SWAP ! ;

: VERTICAL-INTERSECT? ( py,x,qy,x,y,rx,y,sx -- y,x,T|F )
    OVER >R             \                         { y } 
    4 PICK >R           \                         { y,x }  
    NIP                 \ py,x,qy,x,y,rx,sx       { y,x }
    2>R 2>R NIP         \ py,qy                   { y,x,rx,sx,x,y }
    2R> SWAP 2R>        \ py,qy,y,x,rx,sx         { y,x }
    WITHIN+ >R          \ py,qy,y                 { y,x,rx<=x<=sx }
    -ROT WITHIN+        \ py<=y<=qy               { y,x,rx<=x<=sx }
    R> AND 2R> ROT      \ y,x,py<=y<=qy&rx<=x<=sx
    DUP 0= IF -ROT 2DROP THEN ;

: 4SWAP ( a,b,c,d,e,f,g,h -- e,f,g,h,a,b,c,d )
    2>R 2SWAP       \ a,b,e,f,c,d  { g,h }
    2ROT 2R>        \ e,f,c,d,a,b,g,h
    2SWAP 2ROT ;    \ e,f,g,h,a,b,c,d 

: HORIZONTAL-INTERSECT? ( y,px,y,qx,ry,x,sy,x -- y,x,T|F )
    4SWAP VERTICAL-INTERSECT? ;

: DISTANCES ( y,x,py,px,qy,qx -- dy,dx )
    2DROP ROT - ABS 
    -ROT - ABS SWAP ;

: END-WIRE? ( row,col,steps,dist -- f )
    + + + 0= ;

: 8DUP ( a,b,c,d,e,f,g,h -- a,b,c,d,e,f,g,h,a,b,c,d,e,f,g,h )
    8 0 DO 7 PICK LOOP ;

: 8DROP 
    8 0 DO DROP LOOP ;

: @WIRE>LINE ( addr -- py,px,qy,qx )
    DUP @ CELL>WIRE 2DROP  \ addr,qy,qx
    ROT CELL -             \ qy,qx,addr-1
    @ CELL>WIRE 2DROP      \ qy,qx,py,px
    2SWAP ;                \ py,px,qy,qx

: @INTERSECT? ( addrA,addrB -- y,x,T|F )
    @WIRE>LINE                         \ addrA,ry,rx,sy,sx
    2>R 2>R @WIRE>LINE                 \ py,px,qy,qx
    2R> 2R>                            \ py,px,qy,qx,ry,rx,sy,sx
    8DUP VERTICAL-INTERSECT? IF        \ py,px,qy,qx,ry,rx,sy,sx,y,x
        2>R 8DROP 2R> TRUE \ y,x,T
    ELSE HORIZONTAL-INTERSECT? IF      \ y,x 
            TRUE
        ELSE                           \ py,px,qy,qx,ry,rx,sy,sx
            FALSE
    THEN THEN ;
    
: @INTERSECT! ( dy,dx,addr -- )
    >R + R>                      \ dist,addr
    DUP CELL - @ CELL>WIRE       \ dist,addr,py,px,steps,i
    DROP -ROT 2DROP              \ dist,addr,steps
    ROT + SWAP                   \ steps',addr
    INTERSECT! ;

: @INTERSECTS! ( y,x,addrA,addrB )
    2SWAP 2>R SWAP        \ addrB,addrA  { y,x }
    DUP @WIRE>LINE       \ addrB,addrA,py,px,qy,qx
    2R@ 2ROT 2ROT        \ addrB,addrA,y,x,py,px,qy,qx
    DISTANCES            \ addrB,addrA,dy,dx
    ROT @INTERSECT!      \ addrB
    DUP @WIRE>LINE       \ addrB,ry,rx,sy,sx
    2R> 2ROT 2ROT        \ addrB,x,y,ry,rx,sy,sx
    DISTANCES            \ addrB,dy,dx
    ROT @INTERSECT!     ;

: INTERSECTIONS! ( addrA,addrB -- )
    CELL+ SWAP CELL+ SWAP
    SWAP BEGIN                                \ addrB,addrA
        OVER
        OVER @ CELL>WIRE END-WIRE? 0= WHILE   \ addrB,addrA,addrB
        BEGIN                                 
            DUP @ CELL>WIRE END-WIRE? 0= WHILE
            2DUP @INTERSECT? IF               \ addrB,addrA,addrB,y,x,T
                2OVER @INTERSECTS!            \ addrB,addrA,addrB
            THEN
            CELL+                             \ addrB,addrA,addrB+1
        REPEAT DROP                           \ addrB,addrA
        CELL+ OVER                            \ addrB,addrA+1
    REPEAT 2DROP ;


