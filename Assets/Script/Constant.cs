using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constant
{
    public static readonly string MENU = "MainMenu";
    public static readonly string FASE_PREFIX = "Fase";
    public static readonly string EXTRA_BOMBS = "Extra";
    
    //number of bombs left
    //                               Level    1  2   3   4  5  6  7  8  9  10  11  12 13 14 15  16  17  18  19 20 21  22  23 24 25  26 27  28  29  30
    public static readonly int[] initb = { 0, 3, 3,  3,  3, 3, 3, 3, 3, 3, 3,  3,  3, 3, 3, 3,  3,  3,  3,  3, 3, 3,  3,  5, 3, 3,  3, 3,  4,  3,  5};
    public static readonly int[] star3 = { 0, 2, 2,  1,  1, 2, 2, 2, 2, 2, 2,  1,  1, 2, 2, 2,  1,  1,  1,  0, 2, 2,  1,  2, 2, 2,  2, 2,  1,  0,  1};
    public static readonly int[] star2 = { 0, 1, 1, -1, -1, 1, 1, 1, 1, 1, 1, -1, -1, 1, 1, 1, -1, -1, -1, -1, 1, 1, -1,  1, 1, 1,  1, 1, -1, -1,  0};
    public static readonly int[] star1 = { 0, 0, 0,  0,  0, 0, 0, 0, 0, 0, 0,  0,  0, 0, 0, 0,  0,  0,  0, -1, 0, 0,  0,  0, 0, 0,  0, 0,  0, -1, -1};

}
