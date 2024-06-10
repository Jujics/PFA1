using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = Unity.Mathematics.Random;

public class SoulManager : MonoBehaviour
{
    public GameObject GetSeqManager;
    private Dictionary<string, int> SoulInfo = new Dictionary<string, int>();
    private SequenceManager SQ;

    void Start()
    {
        SQ = GetSeqManager.GetComponent<SequenceManager>();
        Random Rnd = new Random((uint)DateTime.Now.Ticks); 
        int color = Rnd.NextInt(1, 3); 
        SoulInfo.Add("color",color);
        switch (color)
        {
            case 1:
                int NumbreOfBad = Rnd.NextInt(1, 2);
                int i = 0;
                while(i != NumbreOfBad)
                    {
                        
                    }
                break;
            case 2:
                //
                break;
            case 3:
                //
                break;
        }
        int IsWhite = Rnd.NextInt(1, 100);
    }

    void Update()
    {
        
    }
}
