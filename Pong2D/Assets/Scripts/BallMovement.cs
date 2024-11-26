using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public GameManager gameManager; 
    private bool leftDirection = false; // true = ball is moving left, false = ball is moving right
    private float speed = 10.0f;
    private float randomY;

    private Rigidbody2D ballRb;

    // Start is called before the first frame update
    void Start()
    {
        ballRb = GetComponent<Rigidbody2D>();
        randomY = Random.Range(-10.0f, 10.0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 leftMovement = new Vector2(-speed, randomY);
        Vector2 rightMovement = new Vector2(speed, randomY);

        if (leftDirection)
        {
            ballRb.velocity = leftMovement;
        }
        else
        {
            ballRb.velocity = rightMovement;
        }
    }

    private void ResetBall()
    {
        randomY = Random.Range(-10.0f, 10.0f);
        ballRb.velocity = new Vector2(0, randomY);
        transform.position = new Vector2(0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            leftDirection = !leftDirection;
            randomY = Random.Range(-10.0f, 10.0f);
            ballRb.velocity = new Vector2(ballRb.velocity.x, randomY);
        }

        if (collision.gameObject.tag == "SimpleBorder")
        {
            randomY = -randomY;
            ballRb.velocity = new Vector2(ballRb.velocity.x, randomY);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ScoreZone scoreZone = collision.GetComponent<ScoreZone>(); 
        if(scoreZone)
        {
            gameManager.OnScoreZoneReached(scoreZone.id);
            ResetBall();
        }
    }
}
