using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rd2d;
    public float id; 
    public float moveSpeed = 5f;

    private void Update()
    {
        float movement = ProcessInput();
        Move(movement);
    }

    private float ProcessInput()
    {
        float movement = 0f;
        switch (id)
        {
            case 1:
                movement = Input.GetAxis("MovePlayer1");
                break;
            case 2:
                movement = Input.GetAxis("MovePlayer2");
                break;
        }

        return movement;
    }

    private void Move(float movement)
    {
        Vector2 velo = rd2d.velocity;
        velo.y = moveSpeed * movement;
        rd2d.velocity = velo;
    }

}
