using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour
{
    private float moveSpeed = 2f;
    private float leftBound = -10f;

    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        if (transform.position.x < leftBound)
        {
            Destroy(gameObject);
        }
    }

    public void SetMoveSpeed(float speed)
    {
        moveSpeed = speed;
    }
}