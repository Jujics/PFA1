using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = Unity.Mathematics.Random;
using System.IO;

public class SoulManager : MonoBehaviour
{
    public GameObject GetSeqManager;
    private Dictionary<string, int> SoulInfo = new Dictionary<string, int>();
    //private SequenceManager SQ;

    void Start()
    {
        //SQ = GetSeqManager.GetComponent<SequenceManager>();
        Random Rnd = new Random((uint)DateTime.Now.Ticks); 
        int color = Rnd.NextInt(1, 3); 
        SoulInfo.Add("color",color);
        
        
        var result = CSVReader.ParseCSV(File.ReadAllText(@"Assets/Script/Actes.csv"));
        
        foreach(var line in result){
            Debug.Log(line);
            foreach(var col in line){
                
            }
        }
        
        switch (color)
        {
                
            case 1:
                int NumbreOfBad = Rnd.NextInt(1, 2);
                int i = 0;
                while(i != 10)
                    {
                        //pull random object from csv
                        SoulInfo.Add("Deed" + i ,0);
                        //check for exceptions
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
                int NumbreOfBad3 = Rnd.NextInt(5, 10);
                int f = 0;
                switch (NumbreOfBad3)
                {
                    case 5:
                        int CsvRnd = Rnd.NextInt(1, 216);
                        SoulInfo.Add("Deed1",CsvRnd);
                        CsvRnd = Rnd.NextInt(1, 216);
                        SoulInfo.Add("Deed2",CsvRnd);
                        CsvRnd = Rnd.NextInt(1, 216);
                        SoulInfo.Add("Deed3",CsvRnd);
                        CsvRnd = Rnd.NextInt(1, 216);
                        SoulInfo.Add("Deed4",CsvRnd);
                        CsvRnd = Rnd.NextInt(1, 216);
                        SoulInfo.Add("Deed5",CsvRnd);
                        break;
                    case 6:
                        int CsvRnd6 = Rnd.NextInt(1, 216);
                        SoulInfo.Add("Deed1",CsvRnd6);
                        CsvRnd6 = Rnd.NextInt(1, 216);
                        SoulInfo.Add("Deed2",CsvRnd6);
                        CsvRnd6 = Rnd.NextInt(1, 216);
                        SoulInfo.Add("Deed3",CsvRnd6);
                        CsvRnd6 = Rnd.NextInt(1, 216);
                        SoulInfo.Add("Deed4",CsvRnd6);
                        CsvRnd6 = Rnd.NextInt(1, 216);
                        SoulInfo.Add("Deed5",CsvRnd6);
                        break;
                }
                    
                
                break;
        }
        
        
        
        
        
        int IsWhite = Rnd.NextInt(1, 100);

        switch (IsWhite)
        {
            case >70:
                //set white as true
                break;
        }
        //set color
    }

    void Update()
    {
        
    }
}
