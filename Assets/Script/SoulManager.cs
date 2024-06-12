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
    public int[] ActGravity;
    public String[] Acts;
    public enum ColorOfSoul{Blue,Red,Orange,Yellow}
    public ColorOfSoul colorOfSoul;
    public bool IsWhite;
}


