using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoulScoreData", menuName = "Hell/SoulScoreData")]
public class SoulScoreData : ScriptableObject
{
    public int DieOutScreen = 10;
    public int DieOnCorrectDoor = 25;
    public int DieOnWrongDoor = 5;
    public int DieWhileWait = 20;
}