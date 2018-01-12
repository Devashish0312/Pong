using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {

    [Header("Attributes")]
    public float minXForce = 15;
    public float minYForce = 15;

    [Header("Ball Velocity")]
    public float minXVelocity = 20;
    public float maxXVelocity = 30;
    public float minYVelocity = 10;
    public float maxYVelocity = 15;

    [HideInInspector]
    public bool ballLaunched = false;

    private Rigidbody2D target;

    // Use this for initialization
    void Start () {
        target = gameObject.GetComponent<Rigidbody2D>();
        ballLaunched = false;
	}

    // Update is called once per frame
    void Update () {
	    if(Input.GetKeyDown(KeyCode.Space) && !ballLaunched)
        {
            ballLaunched = true;
            target.AddForce(new Vector2(
                Random.Range(-minXForce, minXForce), 
                Random.Range(-minYForce, minYForce)), 
                ForceMode2D.Impulse
                );
        }

        Vector2 velocity = target.velocity;
        if ((Mathf.Abs(velocity.x) < minXVelocity || Mathf.Abs(velocity.x) > maxXVelocity) && ballLaunched) {
            float xVelocity = Mathf.Clamp(velocity.x, minXVelocity, maxXVelocity) * Mathf.Sign(velocity.x);
            target.velocity = new Vector2(xVelocity, velocity.y);
        }

        if ((Mathf.Abs(velocity.y) < minYVelocity || Mathf.Abs(velocity.y) > minYVelocity) && ballLaunched)
        {
            float yVelocity = Mathf.Clamp(velocity.y, minYVelocity, maxYVelocity) * Mathf.Sign(velocity.y);
            target.velocity = new Vector2(velocity.x, yVelocity);
        }
    }
}
