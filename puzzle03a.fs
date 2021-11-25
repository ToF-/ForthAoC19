1000000 CONSTANT MAXIMUM
MAXIMUM NEGATE CONSTANT MINIMUM
VARIABLE HMIN   MAXIMUM HMIN !
VARIABLE HMAX   MINIMUM HMAX !
VARIABLE VMIN   MAXIMUM VMIN !
VARIABLE VMAX   MINIMUM VMAX !
VARIABLE HPOS
VARIABLE VPOS

HEX
1 CONSTANT LEFT-DIR
2 CONSTANT RIGHT-DIR
4 CONSTANT DOWN-DIR
8 CONSTANT UP-DIR

: CALIBRATE
    HPOS @ HMAX @ MAX HMAX !
    HPOS @ HMIN @ MIN HMIN !
    VPOS @ VMAX @ MAX VMAX !
    VPOS @ VMIN @ MIN VMIN ! ;

: WIRE-R ( n -- )
    DUP HPOS +!
    RIGHT-DIR 10 LSHIFT OR ,
    CALIBRATE ;

: WIRE-L ( n -- )
    DUP NEGATE HPOS +!
    LEFT-DIR 10 LSHIFT OR ,
    CALIBRATE ;

: WIRE-U ( n -- )
    DUP VPOS +!
    UP-DIR 10 LSHIFT OR ,
    CALIBRATE ;

: WIRE-D ( n -- )
    DUP NEGATE VPOS +!
    DOWN-DIR 10 LSHIFT OR ,
    CALIBRATE ;

HEX
: WIRE-MOVE ( n -- dist,dir )
    DUP FFFF AND
    SWAP 10 RSHIFT ;
DECIMAL

VARIABLE PUZZLE-A-WIRE-SIZE
0 HPOS !  0 VPOS !
CREATE PUZZLE-A-WIRE HERE
990 WIRE-R 408 WIRE-U 583 WIRE-L 275 WIRE-U 483 WIRE-R 684 WIRE-U 437 WIRE-R 828 WIRE-U 108 WIRE-R 709 WIRE-U 378 WIRE-R 97 WIRE-U 252 WIRE-R 248 WIRE-D 413 WIRE-R 750 WIRE-U 428 WIRE-R 545 WIRE-D 570 WIRE-R 795 WIRE-D 204 WIRE-L 975 WIRE-D 557 WIRE-L 160 WIRE-U 861 WIRE-L 106 WIRE-U 436 WIRE-R 934 WIRE-U 81 WIRE-R 237 WIRE-D 660 WIRE-R 704 WIRE-U 451 WIRE-L 135 WIRE-U 282 WIRE-R 391 WIRE-D 39 WIRE-R 109 WIRE-D 125 WIRE-R 918 WIRE-U 214 WIRE-R 481 WIRE-U 853 WIRE-R 825 WIRE-U 91 WIRE-L 763 WIRE-D 335 WIRE-R 868 WIRE-U 42 WIRE-R 218 WIRE-U 152 WIRE-R 429 WIRE-D 414 WIRE-R 607 WIRE-D 28 WIRE-R 436 WIRE-U 7 WIRE-R 770 WIRE-U 215 WIRE-L 373 WIRE-D 209 WIRE-R 440 WIRE-U 536 WIRE-L 120 WIRE-U 900 WIRE-R 46 WIRE-D 635 WIRE-R 75 WIRE-D 58 WIRE-R 267 WIRE-U 581 WIRE-L 474 WIRE-U 858 WIRE-L 172 WIRE-U 725 WIRE-R 54 WIRE-U 291 WIRE-R 274 WIRE-D 583 WIRE-L 743 WIRE-D 130 WIRE-L 563 WIRE-U 137 WIRE-R 524 WIRE-U 659 WIRE-R 997 WIRE-D 131 WIRE-R 364 WIRE-D 883 WIRE-R 222 WIRE-D 628 WIRE-R 579 WIRE-U 801 WIRE-R 890 WIRE-D 519 WIRE-L 749 WIRE-D 620 WIRE-L 60 WIRE-U 759 WIRE-L 759 WIRE-D 376 WIRE-R 769 WIRE-U 910 WIRE-L 570 WIRE-D 814 WIRE-L 954 WIRE-U 153 WIRE-L 42 WIRE-D 784 WIRE-L 66 WIRE-D 844 WIRE-L 29 WIRE-U 794 WIRE-L 342 WIRE-D 924 WIRE-L 825 WIRE-U 447 WIRE-R 828 WIRE-U 404 WIRE-R 52 WIRE-D 330 WIRE-L 876 WIRE-D 125 WIRE-R 203 WIRE-U 245 WIRE-R 936 WIRE-U 866 WIRE-R 804 WIRE-D 186 WIRE-L 693 WIRE-U 620 WIRE-L 722 WIRE-D 32 WIRE-L 735 WIRE-D 191 WIRE-L 217 WIRE-D 68 WIRE-R 209 WIRE-U 736 WIRE-L 365 WIRE-U 280 WIRE-R 608 WIRE-U 450 WIRE-L 240 WIRE-D 282 WIRE-L 434 WIRE-U 589 WIRE-R 94 WIRE-U 470 WIRE-R 5 WIRE-D 49 WIRE-R 407 WIRE-U 552 WIRE-R 651 WIRE-D 69 WIRE-L 518 WIRE-U 358 WIRE-L 130 WIRE-D 710 WIRE-L 929 WIRE-D 315 WIRE-L 345 WIRE-U 511 WIRE-L 229 WIRE-D 557 WIRE-L 44 WIRE-U 890 WIRE-L 702 WIRE-D 181 WIRE-L 61 WIRE-D 208 WIRE-L 553 WIRE-U 878 WIRE-R 354 WIRE-U 787 WIRE-R 624 WIRE-U 961 WIRE-L 92 WIRE-D 891 WIRE-L 70 WIRE-U 203 WIRE-R 255 WIRE-U 532 WIRE-R 154 WIRE-U 299 WIRE-R 934 WIRE-U 609 WIRE-L 985 WIRE-D 115 WIRE-R 757 WIRE-U 13 WIRE-L 368 WIRE-D 936 WIRE-R 742 WIRE-D 412 WIRE-L 346 WIRE-U 56 WIRE-R 67 WIRE-D 371 WIRE-R 175 WIRE-D 868 WIRE-R 107 WIRE-U 806 WIRE-R 530 WIRE-D 40 WIRE-L 153 WIRE-U 374 WIRE-R 223 WIRE-D 517 WIRE-R 481 WIRE-D 194 WIRE-L 545 WIRE-U 356 WIRE-L 906 WIRE-U 999 WIRE-L 885 WIRE-D 967 WIRE-R 407 WIRE-U 141 WIRE-L 927 WIRE-U 489 WIRE-L 959 WIRE-U 992 WIRE-L 638 WIRE-U 332 WIRE-R 51 WIRE-U 256 WIRE-R 901 WIRE-U 891 WIRE-L 803 WIRE-U 885 WIRE-L 804 WIRE-U 242 WIRE-L 180 WIRE-U 277 WIRE-R 693 WIRE-U 935 WIRE-R 253 WIRE-D 68 WIRE-L 153 WIRE-D 614 WIRE-L 596 WIRE-D 999 WIRE-L 633 WIRE-D 995 WIRE-R 803 WIRE-D 17 WIRE-R 303 WIRE-U 569 WIRE-L 231 WIRE-U 737 WIRE-R 970 WIRE-D 45 WIRE-L 860 WIRE-D 225 WIRE-L 65 WIRE-D 41 WIRE-R 313 WIRE-D 698 WIRE-R 340 WIRE-D 599 WIRE-R 531 WIRE-D 55 WIRE-R 568 WIRE-D 911 WIRE-L 547 WIRE-D 196 WIRE-R 228 WIRE-D 868 WIRE-R 227 WIRE-D 262 WIRE-R 525 WIRE-U 104 WIRE-R 625 WIRE-D 570 WIRE-R 968 WIRE-U 276 WIRE-L 586 WIRE-D 690 WIRE-R 73 WIRE-D 336 WIRE-L 287 WIRE-U 294 WIRE-R 148 WIRE-U 781 WIRE-R 395 WIRE-D 478 WIRE-R 804 WIRE-D 429 WIRE-L 872 WIRE-U 351 WIRE-L 910 WIRE-D 597 WIRE-L 726 WIRE-U 320 WIRE-L 964 WIRE-D 928 WIRE-R 2 WIRE-U 540 WIRE-R 325 WIRE-D 222 WIRE-L
HERE SWAP - CELL / PUZZLE-A-WIRE-SIZE !
VARIABLE PUZZLE-B-WIRE-SIZE
0 HPOS !  0 VPOS !
CREATE PUZZLE-B-WIRE HERE
998 WIRE-L 662 WIRE-U 342 WIRE-R 104 WIRE-U 140 WIRE-R 92 WIRE-U 67 WIRE-R 102 WIRE-D 225 WIRE-L 265 WIRE-U 641 WIRE-R 592 WIRE-U 295 WIRE-L 77 WIRE-D 415 WIRE-R 908 WIRE-U 640 WIRE-L 381 WIRE-D 312 WIRE-R 44 WIRE-U 424 WIRE-R 847 WIRE-D 892 WIRE-R 625 WIRE-D 337 WIRE-L 344 WIRE-D 917 WIRE-L 914 WIRE-D 127 WIRE-R 273 WIRE-D 627 WIRE-L 812 WIRE-U 200 WIRE-L 262 WIRE-D 226 WIRE-R 273 WIRE-U 911 WIRE-R 597 WIRE-U 888 WIRE-L 28 WIRE-U 921 WIRE-R 464 WIRE-U 254 WIRE-R 771 WIRE-U 818 WIRE-R 808 WIRE-D 239 WIRE-L 225 WIRE-D 280 WIRE-L 785 WIRE-U 322 WIRE-R 831 WIRE-D 622 WIRE-L 506 WIRE-U 139 WIRE-R 12 WIRE-U 491 WIRE-L 572 WIRE-D 172 WIRE-L 685 WIRE-U 54 WIRE-R 747 WIRE-U 812 WIRE-L 717 WIRE-D 874 WIRE-R 428 WIRE-U 867 WIRE-L 174 WIRE-U 360 WIRE-R 36 WIRE-D 217 WIRE-R 539 WIRE-D 210 WIRE-R 791 WIRE-D 82 WIRE-L 665 WIRE-D 190 WIRE-L 313 WIRE-D 649 WIRE-R 849 WIRE-U 63 WIRE-R 385 WIRE-U 105 WIRE-R 806 WIRE-U 207 WIRE-L 697 WIRE-U 823 WIRE-L 272 WIRE-D 830 WIRE-R 952 WIRE-D 386 WIRE-L 987 WIRE-U 775 WIRE-R 517 WIRE-U 139 WIRE-R 756 WIRE-D 545 WIRE-R 973 WIRE-D 743 WIRE-L 286 WIRE-D 261 WIRE-R 448 WIRE-U 946 WIRE-R 884 WIRE-U 903 WIRE-L 142 WIRE-D 28 WIRE-R 374 WIRE-D 259 WIRE-R 403 WIRE-U 689 WIRE-R 245 WIRE-D 302 WIRE-L 134 WIRE-D 710 WIRE-R 762 WIRE-U 67 WIRE-L 561 WIRE-D 801 WIRE-R 140 WIRE-D 887 WIRE-L 346 WIRE-U 227 WIRE-L 682 WIRE-U 350 WIRE-L 218 WIRE-D 711 WIRE-L 755 WIRE-U 226 WIRE-R 277 WIRE-D 114 WIRE-R 61 WIRE-D 992 WIRE-R 602 WIRE-U 191 WIRE-L 640 WIRE-U 733 WIRE-R 329 WIRE-D 862 WIRE-R 242 WIRE-U 754 WIRE-R 161 WIRE-D 52 WIRE-L 974 WIRE-D 251 WIRE-L 444 WIRE-D 552 WIRE-L 977 WIRE-U 174 WIRE-R 483 WIRE-U 869 WIRE-R 955 WIRE-D 925 WIRE-R 693 WIRE-U 610 WIRE-R 353 WIRE-D 843 WIRE-L 148 WIRE-U 866 WIRE-L 167 WIRE-D 412 WIRE-R 31 WIRE-D 847 WIRE-L 979 WIRE-D 282 WIRE-L 797 WIRE-D 837 WIRE-L 473 WIRE-U 402 WIRE-L 193 WIRE-U 332 WIRE-L 603 WIRE-D 48 WIRE-R 589 WIRE-D 760 WIRE-L 673 WIRE-D 843 WIRE-L 428 WIRE-U 779 WIRE-R 592 WIRE-D 688 WIRE-L 141 WIRE-D 851 WIRE-R 642 WIRE-D 559 WIRE-R 939 WIRE-U 999 WIRE-R 64 WIRE-D 297 WIRE-L 817 WIRE-U 670 WIRE-R 322 WIRE-U 768 WIRE-L 936 WIRE-D 39 WIRE-L 95 WIRE-U 342 WIRE-L 849 WIRE-U 692 WIRE-L 714 WIRE-U 732 WIRE-L 734 WIRE-D 373 WIRE-L 66 WIRE-U 577 WIRE-L 453 WIRE-D 336 WIRE-R 760 WIRE-U 217 WIRE-L 542 WIRE-U 920 WIRE-R 24 WIRE-U 529 WIRE-R 594 WIRE-D 34 WIRE-L 79 WIRE-D 877 WIRE-R 965 WIRE-D 932 WIRE-R 460 WIRE-U 879 WIRE-R 26 WIRE-U 803 WIRE-R 876 WIRE-U 780 WIRE-L 956 WIRE-U 235 WIRE-L 270 WIRE-D 315 WIRE-L 577 WIRE-D 835 WIRE-R 750 WIRE-U 414 WIRE-R 584 WIRE-D 828 WIRE-L 335 WIRE-U 563 WIRE-L 238 WIRE-U 815 WIRE-L 780 WIRE-U 550 WIRE-L 18 WIRE-U 743 WIRE-R 54 WIRE-D 816 WIRE-L 344 WIRE-U 806 WIRE-L 197 WIRE-D 518 WIRE-L 682 WIRE-D 835 WIRE-L 255 WIRE-U 666 WIRE-L 442 WIRE-U 286 WIRE-L 543 WIRE-D 102 WIRE-R 52 WIRE-D 570 WIRE-L 787 WIRE-D 763 WIRE-L 223 WIRE-D 279 WIRE-R 892 WIRE-D 828 WIRE-L 111 WIRE-D 554 WIRE-L 452 WIRE-D 575 WIRE-R 299 WIRE-D 932 WIRE-R 187 WIRE-D 439 WIRE-L 616 WIRE-U 278 WIRE-L 701 WIRE-D 360 WIRE-L 524 WIRE-D 891 WIRE-L 953 WIRE-U 896 WIRE-L 788 WIRE-U 776 WIRE-R 782 WIRE-U 71 WIRE-L 741 WIRE-D 652 WIRE-L 121 WIRE-U 669 WIRE-R 809 WIRE-D 662 WIRE-L 319 WIRE-U 392 WIRE-R 313 WIRE-D 870 WIRE-R 794 WIRE-U 937 WIRE-R 469 WIRE-D 571 WIRE-R 761 WIRE-D 947 WIRE-R
HERE SWAP - CELL / PUZZLE-B-WIRE-SIZE !

: INTERSECT? ( hy,hx0,hxn,vx,vy0,vyn -- b )
    >R >R               ( hy,hx0,hxn,vx )
    SWAP OVER           ( hy,hx0,vx,hxn,vx )
    >=                  ( hy,hx0,vx,vx <= hxn )
    -ROT                ( hy,vx<=hxn,hx0,vx )
    <=                  ( hy,vx<=hxn,vx>=hx0 )
    AND                 ( hy,vy E hxs )
    SWAP DUP            ( vy E hxs,hy,hy )
    R>                  ( vy E hxs,hy,hy,vy0 )
    >=                  ( vy E hxs,hy,hy>=vy0 )
    SWAP R>             ( vy E hys,hy>=vy0,hy,vyn )
    <=                  ( vy E hys,hy>=vy0,hy<=vyn )
    AND AND ;           ( b )

VARIABLE #HLINES-A
VARIABLE #VLINES-A
VARIABLE #HLINES-B
VARIABLE #VLINES-B

4 CELLS CONSTANT LINE-SIZE
: LINES LINE-SIZE * ;

CREATE LINES-A PUZZLE-A-WIRE-SIZE @ LINES ALLOT
CREATE LINES-B PUZZLE-B-WIRE-SIZE @ LINES ALLOT

: .WIRE-MOVE ( n -- )
    WIRE-MOVE
    DUP LEFT-DIR = IF
        DROP ." L"
    ELSE DUP RIGHT-DIR = IF
        DROP ." R"
    ELSE DUP UP-DIR = IF
        DROP ." U"
    ELSE DROP ." D"
    THEN THEN THEN
    0 .R ." " ;

: .WIRE-MOVES ( addr,size -- )
    0 DO
        DUP I CELLS + @ .WIRE-MOVE ." ,"
    LOOP DROP ;


\ converts a wire into a line from current coords
\ e.g  103,104,R42 -- 103,R,103,104,146
\       22,17,U100 -- 17,U,22,122
\        5,0,L50   -- 5,L,0,-50
\        3,9,D20   -- 9,D,3,-17
: WIRE-LINE                    ( row,col,wire -- dir,pos,p0,pN )
    -ROT 2>R                   ( wire -- { J=col, I=row } )
    WIRE-MOVE                  ( dist,dir )
    DUP LEFT-DIR = IF          ( dist,L )
        SWAP 2R>               ( L,dist,row,col )
        ROT OVER               ( L,row,col,dist,col )
        SWAP - SWAP            ( L,row,col-dist,col )
    ELSE DUP RIGHT-DIR = IF    ( dist,R )
        SWAP 2R>               ( R,dist,row,col )
        ROT OVER               ( R,row,col,dist,col )
        +                      ( R,row,col,col+dist )
    ELSE DUP DOWN-DIR = IF     ( dist,D )
        SWAP 2R> SWAP          ( D,dist,col,row )
        ROT OVER               ( D,col,row,dist,row )
        SWAP - SWAP            ( D,col,row-dist,row )
    ELSE                       ( dist,U )
        SWAP 2R> SWAP          ( U,dist,col,row )
        ROT OVER               ( U,col,row,dist,row )
        +                      ( U,col,row,row+dist )
    THEN THEN THEN ;

: MOVE-TO-LINE      ( dir,c|r,p0,pn -- row',col' )
    2>R SWAP        ( c|r,dir )
    DUP LEFT-DIR = IF
        DROP 2R> DROP ( row,col-dist )
    ELSE DUP RIGHT-DIR = IF
        DROP 2R> NIP ( row,col+dist )
    ELSE DOWN-DIR = IF
        2R> DROP SWAP ( row-dist,col )
    ELSE 2R> NIP SWAP ( row+dist,col )
    THEN THEN THEN ;

: LINE@ ( addr -- dir,pos,p0,pN )
    >R R@ 2@ R> 2 CELLS + 2@ ;

: LINE! ( dir,pos,p0,pN,addr -- )
    >R 2SWAP R@ 2! R> 2 CELLS + 2! ;

: POINT 2 CELLS ;
: POINTS POINT * ;

VARIABLE MAX-INTERSECTIONS
CREATE INTERSECTIONS PUZZLE-A-WIRE-SIZE @ POINTS ALLOT

: ADD-INTERSECTION ( row,col -- )
    INTERSECTIONS MAX-INTERSECTIONS @ POINTS + 2!
    1 MAX-INTERSECTIONS +! ;

: .INTERSECTIONS
    MAX-INTERSECTIONS @ ?DUP IF
        0 DO
            INTERSECTIONS I POINTS + 2@
            SWAP . . CR
        LOOP THEN ;

VARIABLE WIRE-SRCE
VARIABLE LINE-DEST
: WIRE-LINES ( srce,dest,size )
    -ROT LINE-DEST ! WIRE-SRCE !
    0 0 ROT             ( row,col,size )
    0 DO                ( row,col )
        WIRE-SRCE @ @   ( row,col,wire )
        WIRE-LINE       ( dir,pos,p0,pN )
        2OVER 2OVER     ( dir,pos,p0,pN,dir,pos,p0,pN )
        LINE-DEST @ LINE!  ( dir,pos,p0,pN )
        LINE-SIZE LINE-DEST +!
        MOVE-TO-LINE    ( row',col' )
        CELL WIRE-SRCE +!
    LOOP 2DROP ;

: .LINE ( dir,pos,p0,pN )
    .S CR
    2SWAP SWAP
    DUP LEFT-DIR = IF
        DROP ." LEFT ON ROW " . ." FROM " . ." TO " .
    ELSE DUP RIGHT-DIR = IF
        DROP ." RIGHT ON ROW " . ." FROM " SWAP . ." TO " .
    ELSE DOWN-DIR = IF
        ." DOWN ON COL " . ." FROM " . ." TO " .
    ELSE
        ." UP ON COL " . ." FROM " SWAP . ." TO " .
    THEN THEN THEN ;

: .LINES ( addr,size )
    0 DO
        DUP I LINES +
        LINE@
        .LINE CR
    LOOP DROP ;

: ADD-HORZ-INTERSECTIONS ( pos,p0,pN,q0,qN )
    2OVER 2OVER          ( pos,p0,pN,q0,qN,p0,pN,q0,qN )
    DROP  NIP            ( pos,p0,pN,q0,qN,p0,q0 )
    > IF 2SWAP THEN      ( pos,p0,pN,q0,qN )
    -ROT                 ( pos,p0,qN,pN,q0 )
    2>R 2DROP 2R>        ( pos,pN,q0 )
    2DUP                 ( pos,pN,q0,pN,q0 )
    >= IF                ( pos,pN,q0 )
        2DUP MAX         ( pos,pN,q0,end )
        -ROT MIN         ( pos,end,start )
        SWAP 1+ SWAP DO  ( pos )
            DUP I ADD-INTERSECTION
        LOOP
    THEN DROP ;

PUZZLE-A-WIRE PUZZLE-A-WIRE-SIZE @ .WIRE-MOVES CR
PUZZLE-B-WIRE PUZZLE-B-WIRE-SIZE @ .WIRE-MOVES CR
." PUZZLE-A-WIRE-SIZE:" PUZZLE-A-WIRE-SIZE ? CR
." PUZZLE-B-WIRE-SIZE:" PUZZLE-B-WIRE-SIZE ? CR
CR
." HMIN: " HMIN ? ." HMAX:" HMAX ? ." VMIN:" VMIN ? ." VMAX:" VMAX ? CR
CR
VARIABLE TEST-PUZZLE-A-WIRE-SIZE
MAXIMUM HMIN !  MINIMUM HMAX !  MAXIMUM VMIN !  MINIMUM VMAX !
0 HPOS ! 0 VPOS !
CREATE TEST-PUZZLE-A-WIRE HERE
8 WIRE-R 5 WIRE-U 5 WIRE-L 3 WIRE-D
HERE SWAP - CELL / TEST-PUZZLE-A-WIRE-SIZE !
VARIABLE TEST-PUZZLE-B-WIRE-SIZE
0 HPOS ! 0 VPOS !
CREATE TEST-PUZZLE-B-WIRE HERE
7 WIRE-U 6 WIRE-R 4 WIRE-D 4 WIRE-L
HERE SWAP - CELL / TEST-PUZZLE-B-WIRE-SIZE !

TEST-PUZZLE-A-WIRE TEST-PUZZLE-A-WIRE-SIZE @ .WIRE-MOVES CR
TEST-PUZZLE-B-WIRE TEST-PUZZLE-B-WIRE-SIZE @ .WIRE-MOVES CR
." HMIN: " HMIN ? ." HMAX:" HMAX ? ." VMIN:" VMIN ? ." VMAX:" VMAX ? CR
0 0
TEST-PUZZLE-A-WIRE @ WIRE-LINE           MOVE-TO-LINE
TEST-PUZZLE-A-WIRE CELL+ @ WIRE-LINE     MOVE-TO-LINE
TEST-PUZZLE-A-WIRE 2 CELLS + @ WIRE-LINE MOVE-TO-LINE
TEST-PUZZLE-A-WIRE 3 CELLS + @ WIRE-LINE MOVE-TO-LINE
2DROP 0 0
TEST-PUZZLE-B-WIRE @ WIRE-LINE           MOVE-TO-LINE
TEST-PUZZLE-B-WIRE CELL+ @ WIRE-LINE     MOVE-TO-LINE
TEST-PUZZLE-B-WIRE 2 CELLS + @ WIRE-LINE MOVE-TO-LINE
TEST-PUZZLE-B-WIRE 3 CELLS + @ WIRE-LINE MOVE-TO-LINE
2DROP
CREATE TEST-PUZZLE-A-LINES TEST-PUZZLE-A-WIRE-SIZE @ CELLS 2* ALLOT
CREATE TEST-PUZZLE-B-LINES TEST-PUZZLE-B-WIRE-SIZE @ CELLS 2* ALLOT

TEST-PUZZLE-A-WIRE TEST-PUZZLE-A-LINES TEST-PUZZLE-A-WIRE-SIZE @ WIRE-LINES
TEST-PUZZLE-A-LINES 4 .LINES CR
0 MAX-INTERSECTIONS !
10 3 7 4 22 ADD-HORZ-INTERSECTIONS
12 -3 27 -54 22 ADD-HORZ-INTERSECTIONS
100 3 7 10 12 ADD-HORZ-INTERSECTIONS
." INTERSECTIONS:" CR
.INTERSECTIONS

