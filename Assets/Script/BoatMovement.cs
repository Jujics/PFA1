using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{
    public SliderScript Slider;
    public RectTransform rectTransform;
    public GameObject SliderTarget;
    public float speed = 200f; 
    public float interval; 
    private float timer;

    public float SliderTime;

    public bool isTP = false;
    public int BoatPassage = -1;

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
        float preTargetX = -1220;


        if (isTP)
        {
            Debug.Log("Wait");
            yield return new WaitForSeconds(interval);
            isTP = false;
        }

        while (rectTransform.anchoredPosition.x > targetX)
        {
            rectTransform.anchoredPosition += Vector2.left * speed * Time.deltaTime;

            yield return null;
        }

        if(rectTransform.anchoredPosition.x <= SliderTarget.transform.position.x)
            Slider.canMoveSlider = true;    

        
        Slider.thisSlider.value = 0;


        rectTransform.anchoredPosition = new Vector2(screenWidth, rectTransform.anchoredPosition.y);
        BoatPassage += 1;
        isTP = true;
    }
}
