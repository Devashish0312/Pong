using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Transform))]
public class playermovement : MonoBehaviour {

    [Header("KeyCodes")]
    public KeyCode moveUp;
    public KeyCode moveDown;
    public string axisName = "Vertical";

    [Header("Stats")]
    public float speed = 10.0f;
    public float minYPosition;
    public float maxYPosition;

    private Rigidbody2D target;
    private Transform gameobjectTransform;

    private void Start()
    {
        target = gameObject.GetComponent<Rigidbody2D>();
        gameobjectTransform = gameObject.GetComponent<Transform>();
    }

    void Update()
    {
        /* if(Input.GetKey(moveUp))
            target.velocity = Vector2.up * speed * Time.deltaTime;
        else if(Input.GetKey(moveDown))
            target.velocity = Vector2.down * speed * Time.deltaTime;

        if (!Input.GetKey(moveUp) && !Input.GetKey(moveDown))
            target.velocity = Vector2.zero; */

        var moveY = Input.GetAxis(axisName);
        target.velocity = Vector2.up * moveY * speed * Time.deltaTime;

        float yPosition = gameobjectTransform.position.y;
        gameobjectTransform.position = new Vector2(gameobjectTransform.position.x, Mathf.Clamp(yPosition, minYPosition, maxYPosition));
    }
}
