using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EventData", menuName = "New Event")]
public class EventScript : ScriptableObject
{
    public int DayOfTheEvent;
    public int PassageOfTheEvent;
    public bool IsCloseY1, IsCloseY2, IsCloseO1, IsCloseO2, IsCloseR1, IsCloseR2,IsErebeClosed;
    public float ForHowLong;
}
