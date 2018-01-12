using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour {

    public string ballTag = "Ball";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Collison Occurred");
        Rigidbody2D target = collision.GetComponent<Rigidbody2D>();
        if (!target || !collision.CompareTag(ballTag))
            return;

        collision.GetComponent<BallMovement>().ballLaunched = false;
        target.velocity = Vector2.zero;
        target.position = Vector2.zero;
        
    }
}
