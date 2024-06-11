using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;

public class SliderScript : MonoBehaviour
{
    public BoatMovement Boat;
    public bool canMoveSlider = false;

    public Slider thisSlider;

    // Start is called before the first frame update
    void Start()
    {
        thisSlider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMoveSlider)
            StartCoroutine(MoveSlider());
    }

    public IEnumerator MoveSlider()
    {
        thisSlider.value += Time.deltaTime * thisSlider.maxValue/100 * Boat.interval; 
        yield return new WaitForEndOfFrame();
    }

}
