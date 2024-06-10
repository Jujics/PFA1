using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulManager : MonoBehaviour
{
    public GameObject GetSeqManager;
    private Dictionary<string, int> SoulInfo = new Dictionary<string, int>();
    private SequenceManager SQ;
    
    void Start()
    {
        SQ = GetSeqManager.GetComponent<SequenceManager>();
        switch (SQ.DayNumber)
        {
            case 1:
                
                //SoulInfo.Add("Act1",int i);
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
