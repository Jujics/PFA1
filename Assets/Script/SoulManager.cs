using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = Unity.Mathematics.Random;
using System.IO;

[CreateAssetMenu(fileName = "newSoul", menuName = "Soul")]
public class SoulManager : ScriptableObject
{
    public String name;
    public SoulAct[] Acts;
    public ColorOfSoul colorOfDoor;
    public bool IsWhite;

    public enum ColorOfSoul
    {
        Blue,
        Red,
        Orange,
        Yellow
    }
}

[System.Serializable]
public class SoulAct
{
    public string Desc;
    public int Gravity;
}