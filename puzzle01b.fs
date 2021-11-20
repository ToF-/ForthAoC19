4 CONSTANT EOF

: IS-DIGIT?  ( c -- b )
    DUP  [CHAR] 0 >= 
    SWAP [CHAR] 9 <= AND ;


: SKIP-SPACE ( -- c )
    BEGIN
        KEY 
        DUP EOF <> 
        OVER IS-DIGIT? 0= 
        AND WHILE
        DROP
    REPEAT ;

: GET-NUMBER? ( -- n,true | 0,false )
    FALSE 0 SKIP-SPACE
    BEGIN
        DUP EOF <> 
        OVER IS-DIGIT? 
        AND WHILE
            [CHAR] 0 - SWAP 10 * +
            SWAP DROP TRUE SWAP
            KEY
    REPEAT 
    DROP SWAP ;

: FUEL-REQUIREMENT
    3 / 2 - ;

: TOTAL-FUEL-REQUIREMENT
    0 SWAP
    BEGIN
        FUEL-REQUIREMENT DUP 0> WHILE 
            DUP ROT + SWAP
    REPEAT DROP ;

: EVAL-FUEL-REQUIREMENTS
    0
    BEGIN
        GET-NUMBER? WHILE
        TOTAL-FUEL-REQUIREMENT +
    REPEAT DROP ;

EVAL-FUEL-REQUIREMENTS . BYE 
