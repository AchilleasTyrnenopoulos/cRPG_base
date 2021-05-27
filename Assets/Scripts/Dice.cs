using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Dice 
{
    public static int DiceRoll(int dx)
    {
        return Random.Range(1, dx + 1);
    }
}
