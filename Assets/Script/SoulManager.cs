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
                while(i != 10)
                    {
                        //pull random object from csv
                        SoulInfo.Add("Deed" + i ,0);
                        i += 1;
                    }
                break;
            case 2:
                int NumbreOfBad2= Rnd.NextInt(3, 4);
                int n = 0;
                while(n != 10)
                {
                    //pull random object from csv
                    SoulInfo.Add("Deed" + n ,0);
                    n += 1;
                }
                break;
            case 3:
                int NumbreOfBad3= Rnd.NextInt(3, 4);
                int f = 0;
                while(f != 10)
                {
                    //pull random object from csv
                    SoulInfo.Add("Deed" + f ,0);
                    f += 1;
                }
                break;
        }
        int IsWhite = Rnd.NextInt(1, 100);

        switch (IsWhite)
        {
            case >70:
                //set as white
                break;
        }
        //set color
    }

    void Update()
    {
        
    }
}
