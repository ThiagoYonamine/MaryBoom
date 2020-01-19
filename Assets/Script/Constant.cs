﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constant
{
    public static readonly string MENU = "MainMenu";
    public static readonly string FASE_PREFIX = "Fase";
    public static readonly string EXTRA_BOMBS = "Extra";

    //                               Level 1  2  3  4  5  6  7  8  9  10 11 12 13 14 15 16 17 18 19 20 21
    public static readonly int[] initb = { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 6};
    public static readonly int[] star3 = { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0};
    public static readonly int[] star2 = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1};
    public static readonly int[] star1 = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2};
}
