using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class BoatMovement : MonoBehaviour
{
    public RectTransform rectTransform; 
    public float MaxTravelTime;
    public float CurrentTravelTime;
    private bool Pause = true;
    private Vector2 StartPosition, EndPosition;
    

    void Start()
    {
        if (rectTransform == null)
        {
            rectTransform = GetComponent<RectTransform>();
        }
        StartPosition = new Vector2(Screen.width, rectTransform.anchoredPosition.y);
        EndPosition = new Vector2(-1225, rectTransform.anchoredPosition.y);
    }

    void Update()
    {
        if (!Pause && CurrentTravelTime < MaxTravelTime)
        {
            CurrentTravelTime += Time.deltaTime;
            if (CurrentTravelTime >= MaxTravelTime)
            {
                CurrentTravelTime = MaxTravelTime;
                Pause = true;
            }

            float t = CurrentTravelTime / MaxTravelTime;
            rectTransform.anchoredPosition = Vector2.Lerp(StartPosition, EndPosition, t);
        }
    }

    public void StartMovement()
    {
        Reset();
        Pause = false;
    }

    private void Reset()
    {
        CurrentTravelTime = 0;
    }
}
