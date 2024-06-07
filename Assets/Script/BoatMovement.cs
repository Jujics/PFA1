using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{
    public RectTransform rectTransform;
    public float speed = 200f; 
    public float interval; 
    private float timer;
    void Start()
    {
        if (rectTransform == null)
        {
            rectTransform = GetComponent<RectTransform>();
        }
        timer = interval;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        
        if (timer <= 0)
        {
            StartCoroutine(MoveFromRightToLeft());
            timer = interval;
        }
    }

    private IEnumerator MoveFromRightToLeft()
    {
        float screenWidth = Screen.width;
        float targetX = -1225;
        
        while (rectTransform.anchoredPosition.x > targetX)
        {
            rectTransform.anchoredPosition += Vector2.left * speed * Time.deltaTime;
            yield return null;
        }

        rectTransform.anchoredPosition = new Vector2(screenWidth, rectTransform.anchoredPosition.y);
    }
}
