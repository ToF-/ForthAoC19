CREATE PUZZLE-PROGRAM
\ values from the puzzle file
HERE \ keep track of the size of dictionnary
1 , 0 , 0 , 3 , 1 , 1 , 2 , 3 , 1 , 3 , 4 , 3 , 1 , 5 , 0 , 3 , 2 , 9 , 1 , 19 , 1 , 19 , 5 , 23 , 1 , 9 , 23 , 27 , 2 , 27 , 6 , 31 , 1 , 5 , 31 , 35 , 2 , 9 , 35 , 39 , 2 , 6 , 39 , 43 , 2 , 43 , 13 , 47 , 2 , 13 , 47 , 51 , 1 , 10 , 51 , 55 , 1 , 9 , 55 , 59 , 1 , 6 , 59 , 63 , 2 , 63 , 9 , 67 , 1 , 67 , 6 , 71 , 1 , 71 , 13 , 75 , 1 , 6 , 75 , 79 , 1 , 9 , 79 , 83 , 2 , 9 , 83 , 87 , 1 , 87 , 6 , 91 , 1 , 91 , 13 , 95 , 2 , 6 , 95 , 99 , 1 , 10 , 99 , 103 , 2 , 103 , 9 , 107 , 1 , 6 , 107 , 111 , 1 , 10 , 111 , 115 , 2 , 6 , 115 , 119 , 1 , 5 , 119 , 123 , 1 , 123 , 13 , 127 , 1 , 127 , 5 , 131 , 1 , 6 , 131 , 135 , 2 , 135 , 13 , 139 , 1 , 139 , 2 , 143 , 1 , 143 , 10 , 0 , 99 , 2 , 0 , 14 , 0 ,

\ determine the size of the puzzles in cells
HERE SWAP - CELL /
VARIABLE PUZZLE-SIZE
PUZZLE-SIZE !
CREATE TEST-PROGRAM
1 , 9 , 10 , 3 , 2 , 3 , 11 , 0 , 99 , 30 , 40 , 50 ,


CREATE CANDIDATE-PROGRAM PUZZLE-SIZE @ CELLS ALLOT

VARIABLE BASE-ADDRESS

\ copy the puzzle program into the candidate program
: REINIT-CANDIDATE-PROGRAM
    PUZZLE-SIZE @ 0 DO
        PUZZLE-PROGRAM I CELLS + @
        CANDIDATE-PROGRAM I CELLS + !
    LOOP ;

1 CONSTANT ADD
2 CONSTANT MUL

\ load v at location loc in the program
: LOAD-POS ( v,loc -- @ba+loc = v )
    CELLS BASE-ADDRESS @ + ! ;

\ fetch value at location defined by the value at position pc, increments pc
: FETCH ( pc -- pc+1, @@pc )
    DUP CELL+ SWAP @ CELLS BASE-ADDRESS @ + @ ;

\ store value v at location defined by the value at position pc, increments pc
: STORE ( v,pc -- pc+1 / @@pc=v )
    DUP CELL+ -ROT @ CELLS BASE-ADDRESS @ + ! ;

\ find the value at pc, increments pc
: FETCH-INTCODE ( pc -- pc+1, op )
    DUP CELL+ SWAP @ ;

\ fetch 2 values at locations defined by the values at positions pc,pc+1, increments pc twice
: OPERANDS ( pc -- pc+2,@@pc,@@pc+1 )
    FETCH                ( pc+1, @@pc )
    SWAP FETCH           ( @@pc,pc+2,@@pc+1 )
    ROT SWAP ;           ( pc+2,@@pc,@@pc+1 )
    
\ execute intcode at pc, increments pc and flag true or flag false if end of program
: EXECUTE-CODE ( pc,op -- pc+4,t / f )
    DUP ADD = IF
        DROP OPERANDS + SWAP STORE TRUE
    ELSE DUP MUL = IF
        DROP OPERANDS * SWAP STORE TRUE
    ELSE ( END )
        DROP DROP FALSE
    THEN THEN ;

\ runs the intcode program at base address
: RUN-PROGRAM ( -- )
    BASE-ADDRESS @
    BEGIN
        FETCH-INTCODE
        EXECUTE-CODE
    0= UNTIL ;

VARIABLE CORRECT-NOUN
VARIABLE CORRECT-VERB

: SET-NOUN ( v -- )
    1 LOAD-POS ;

: SET-VERB ( v -- )
    2 LOAD-POS ;

: GET-OUTPUT ( -- v )
    BASE-ADDRESS @ @ ;

: RUN-CANDIDATES
    CANDIDATE-PROGRAM BASE-ADDRESS !
    -1 CORRECT-NOUN !
    -1 CORRECT-VERB !
    100 0 DO
        100 0 DO
            REINIT-CANDIDATE-PROGRAM
            J SET-NOUN
            I SET-VERB
            RUN-PROGRAM
            GET-OUTPUT 19690720 = IF
                I CORRECT-VERB !
                J CORRECT-NOUN !
                LEAVE
            THEN
        LOOP
        CORRECT-NOUN @ -1 <> IF
            LEAVE
        THEN
    LOOP ;

\ show n values at base address
: SHOW-VALUES ( n -- )
    BASE-ADDRESS @ SWAP
    CELLS OVER + SWAP
    BEGIN
        2DUP > WHILE
        FETCH-INTCODE .
    REPEAT 2DROP ;


CR
." PUZZLE SIZE: " PUZZLE-SIZE ? CR

REINIT-CANDIDATE-PROGRAM
CANDIDATE-PROGRAM BASE-ADDRESS !

12 SET-NOUN
2  SET-VERB
RUN-PROGRAM
." PUZZLE 02a ANSWER: " GET-OUTPUT . CR
RUN-CANDIDATES
." PUZZLE 02b ANSWER: " CORRECT-NOUN @ 100 * CORRECT-VERB @ + . CR


BYE
