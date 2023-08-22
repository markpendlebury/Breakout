using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float ballSpeed;

    [SerializeField]
    public GameLogic gameLogic;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * ballSpeed;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Did we the Player?
        if (collision.gameObject.name == "Player")
        {
            // Calculate hit Angle
            float x = hitFactor(transform.position,
                              collision.transform.position,
                              collision.collider.bounds.size.x);

            // Calculate direction, set length to 1
            Vector2 dir = new Vector2(x, 1).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * ballSpeed;
        }
    }

    float hitFactor(Vector2 ballPos, Vector2 playerPosition, float playerWidth)
    {
        // ascii art:
        //
        //
        // 1  -0.5  0  0.5   1  <- x value
        // ===================  <- player
        //
        return (ballPos.x - playerPosition.x) / playerWidth;
    }

    // This is called when the
    // ball goes off the screen. 
    private void OnBecameInvisible()
    {
        gameLogic.GameOver();
    }
}
