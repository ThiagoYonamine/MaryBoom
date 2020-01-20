using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constant
{
    public static readonly string MENU = "MainMenu";
    public static readonly string FASE_PREFIX = "Fase";
    public static readonly string EXTRA_BOMBS = "Extra";
    
    //number of bombs left
    //                               Level    1  2   3   4  5  6  7  8  9  10  11  12 13 14 15  16  17 18 19  20  21 22  23 24 25  26 27 28  29  30
    public static readonly int[] initb = { 0, 3, 3,  3,  3, 3, 3, 3, 3, 3, 3,  3,  3, 3, 3, 3,  3,  3, 3,  3,  3,  3, 3,  3, 3, 3,  6, 3, 3,  4,  5};
    public static readonly int[] star3 = { 0, 2, 2,  1,  1, 2, 2, 2, 2, 2, 2,  1,  1, 2, 2, 2,  1,  2, 2,  1,  1,  1, 2,  1, 2, 2,  3, 2, 2,  1,  1};
    public static readonly int[] star2 = { 0, 1, 1, -1, -1, 1, 1, 1, 1, 1, 1, -1, -1, 1, 1, 1, -1,  1, 1, -1, -1, -1, 1, -1, 1, 1,  2, 1, 1, -1,  0};
    public static readonly int[] star1 = { 0, 0, 0,  0,  0, 0, 0, 0, 0, 0, 0,  0,  0, 0, 0, 0,  0,  0, 0,  0,  0,  0, 0,  0, 0, 0,  1, 0, 0,  0, -1};

   /*
     *                           Level    1  2   3   4  5  6  7  8  9  10 11  12  13 14 15  16  17 18 19  20 21 22  23 24 25  26 27 28 29  30
    public static readonly int[] initb = { 0, 3, 3,  3,  3, 3, 3, 3, 3, 3, 3, 3,  3,  3, 3, 3,  3,  3, 3, 3,  3, 6, 3,  4,  3, 3,  3, 3, 3, 3,  5};
    public static readonly int[] star3 = { 0, 2, 2,  1,  1, 2, 2, 2, 2, 2, 2, 2,  1,  0, 2, 2,  1,  1, 2, 2,  1, 3, 2,  1,  0, 2,  1, 2, 2, 2,  1};
    public static readonly int[] star2 = { 0, 1, 1, -1, -1, 1, 1, 1, 1, 1, 1, 1, -1, -1, 1, 1, -1, -1, 1, 1, -1, 2, 1, -1, -1, 1, -1, 1, 1, 1,  0};
    public static readonly int[] star1 = { 0, 0, 0,  0,  0, 0, 0, 0, 0, 0, 0, 0,  0, -1, 0, 0,  0,  0, 0, 0,  0, 1, 0,  0, -1, 0,  0, 0, 0, 0, -1};
     * 
     */
    // facil 1 2 3 4 7 9 10 12 14 19 23 25 26 27 29
    // medio 5 6 8 11 15 16 18 20 22 28
    // hard 13 17 21 24 30

    // check 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30
    //       x x x x x x x x x  x  x  x  x  x  x  x  x  x  x  x  x  x  x  x       x   x  x    

    //                d d d d    d  d  d         d  d  d  d  d  d  d  d  d    d  d    c
    //      1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30
    //ordem 1 2 3 4 5 7 9 6 8 10 12 17 19 14 15 23 16 26 13 27 18 20 21 29 25 22 11 28 24 30 
    //      F F F F M F F M M  F  F  H  F  F M   F  M  F  H  F  M  M  H  F  F  H  M  M  H  H
}
