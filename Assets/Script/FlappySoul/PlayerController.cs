using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public float flapForce = 5f;
    public int Score;
    public TMP_Text ScoreText;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        ScoreText.text = "Score : " + Score;
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            Flap();
        }
    }

    void Flap()
    {
        rb.velocity = Vector2.zero;
        rb.AddForce(Vector2.up * flapForce, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Score = Score + 1;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        SceneManager.LoadScene(0);
    }
}
