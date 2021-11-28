
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

    
    
