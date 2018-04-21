using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CatMovement : MonoBehaviour {
    float maxVelocity = 5.0f;
    int jumplimit = 6000;

    public int grounded;
    private Vector2 acceleration;
    private Vector2 speed;
    private Rigidbody2D rigidbody;
    private bool jump;
    private int jumpHeight;
    private Vector2 input;
    private Vector2 previousPos;
    private Vector2 velocity;


    // Use this for initialization
    void Start() {
        rigidbody = GetComponent<Rigidbody2D>();
        jump = false;
        input = new Vector2(0.0f, 0.0f);
        speed.Set(0.0f, 0.0f);
        acceleration.Set(0.0f, -0.1f * Time.deltaTime);
        previousPos = rigidbody.position;
        grounded = 0;
    }

    // Update is called once per frame
    void Update() {
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetButton("Jump") ? 1.0f : 0.0f);
    }

    void FixedUpdate() {
        float lowerG = 1.0f;

        if (input[0] < 0) {
            speed.Set(-maxVelocity, speed[1]);
        } else if (input[0] > 0) {
            speed.Set(maxVelocity, speed[1]);
        } else {
            speed.Set(0, speed[1]);
        }

        if (input[1] > 0 && !jump) {
            jump = true;
            jumpHeight = 0;
            speed.Set(speed[0], 6.0f);
        }
        if (input[1] > 0 && jumpHeight<jumplimit) {
            jumpHeight++;
            lowerG = 0.2f;
            if (jumpHeight == jumplimit)
                Debug.Log("MAX JUMP!");
        }
        if (!(input[1] > 0) && jump) {
            jumpHeight = jumplimit;
        }
        if(jump && jumpHeight >= jumplimit) {
            lowerG = 2.0f;
        }

        //velocity = rigidbody.velocity;
        speed.Set(speed[0] + acceleration[0], speed[1] + acceleration[1]*lowerG);

        if (grounded > 0) {
            speed[1] = Mathf.Max(speed[1], 0.0f);
            jump = false;
        }
        rigidbody.MovePosition(rigidbody.position + speed * Time.deltaTime);

    }



}
