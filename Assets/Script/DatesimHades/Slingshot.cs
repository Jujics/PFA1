using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    public GameObject birdPrefab;         
    public Transform launchPoint;        
    public float launchForce = 100f;       

    private GameObject currentBird;
    private bool isDragging = false;
    private Vector3 dragStartPos;

    void Start()
    {
        SetupBird();
    }

    void Update()
    {
        if (isDragging)
        {
            DragBird();
        }

        if (Input.GetMouseButtonUp(0) && currentBird != null)
        {
            LaunchBird();
        }
    }

    void SetupBird()
    {
        currentBird = Instantiate(birdPrefab, launchPoint.position, Quaternion.identity);
        currentBird.GetComponent<Rigidbody2D>().isKinematic = true;
    }

    void DragBird()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        currentBird.transform.position = mousePos;
    }

    void LaunchBird()
    {
        isDragging = false;
        Vector3 launchDirection = launchPoint.position - currentBird.transform.position;
        currentBird.GetComponent<Rigidbody2D>().isKinematic = false;
        currentBird.GetComponent<Rigidbody2D>().AddForce(launchDirection * launchForce, ForceMode2D.Impulse);
        StartCoroutine(SetupNextBirdAfterDelay(1f));
    }

    IEnumerator SetupNextBirdAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SetupBird();
    }

    void OnMouseDown()
    {
        if (currentBird != null)
        {
            isDragging = true;
            dragStartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            dragStartPos.z = 0;
        }
    }

    void OnMouseUp()
    {
        isDragging = false;
    }
}