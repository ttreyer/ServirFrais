using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CatMovement : MonoBehaviour {
    float maxVelocity = 5.0f;
    int jumplimit = 6000;

    public int grounded;

    private Animator animator;
    private Vector2 acceleration;
    private Vector2 speed;
    private Rigidbody2D rigidbody;
    private bool jump;
    private bool falling;
    private int jumpHeight;
    private Vector2 input;

    private Vector2 velocity;


    // Use this for initialization
    void Start() {
        rigidbody = GetComponent<Rigidbody2D>();
        jump = false;
        input = new Vector2(0.0f, 0.0f);
        speed.Set(0.0f, 0.0f);
        acceleration.Set(0.0f, -10f * Time.deltaTime);
        grounded = 0;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetButton("Jump") ? 1.0f : 0.0f);
    }

    void FixedUpdate() {
        float lowerG = 1.0f;

        if (input[0] < 0) {
            speed.Set(-maxVelocity, speed[1]);
            animator.SetBool("isWalking", true);
            animator.SetBool("Left", true);
        } else if (input[0] > 0) {
            speed.Set(maxVelocity, speed[1]);
            animator.SetBool("isWalking", true);
            animator.SetBool("Left", false);
        } else {
            speed.Set(0, speed[1]);
            animator.SetBool("isWalking",false);
        }

        if (input[1] > 0 && !jump) {
            animator.SetTrigger("rising");
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
        if (speed[1] < 0.0f && !falling && jump) {
            animator.SetTrigger("falling");
            falling = true;
        }

        //velocity = rigidbody.velocity;
        speed.Set(speed[0] + acceleration[0], speed[1] + acceleration[1]*lowerG);
        

        //landing of a jump
        if ( (grounded > 0) && jump && falling) {
            jump = false;
            falling = false;
            animator.SetTrigger("landing");
        }

        //don't accelerate toward the ground
        if (grounded > 0) {
            speed[1] = Mathf.Max(speed[1], 0.0f);
        }
        rigidbody.MovePosition(rigidbody.position + speed * Time.deltaTime);

    }



}
