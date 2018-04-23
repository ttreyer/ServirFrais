using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CatMovement : MonoBehaviour {
    float maxVelocity = 7.0f;
    int jumplimit = 30;
    float gravity = -10.0f;
    float meowDuration = 0.75f;

    public int grounded;
    public bool meow;

    private Animator animator;
    private Vector2 acceleration;
    private Vector2 speed;
    private Rigidbody2D rigidbody;
    private bool jump;
    private bool falling;
    private int jumpHeight;
    private Vector2 input;
    private bool meowButton;
    private float meowTime;
    private FishermanController fisherman;
    private int waterlayer;
    private bool immobile = false;

    private Vector2 velocity;

    public bool isAlive() {
        return !immobile;

    }


    // Use this for initialization
    void Start() {
        rigidbody = GetComponent<Rigidbody2D>();
        jump = false;
        input = new Vector2(0.0f, 0.0f);
        speed.Set(0.0f, 0.0f);
        acceleration.Set(0.0f, gravity * Time.deltaTime);
        grounded = 0;
        animator = GetComponent<Animator>();
        meowTime = 0.0f;
        meow = false;
        fisherman = null;
        waterlayer = LayerMask.NameToLayer("Water");
    }

    // Update is called once per frame
    void Update() {
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetButton("Jump") ? 1.0f : 0.0f);
        meowButton = Input.GetButton("Fire2");
    }

    void FixedUpdate() {
        float lowerG = 1.0f;

        if(immobile) {
            rigidbody.MovePosition(rigidbody.position+speed);
            return;
        }
        //meow
        if(meowButton && !jump && !falling) {
            animator.SetBool("isMeowing",true);
            meowTime = 0.0f;
            meow = true;
            if(fisherman != null) {
                fisherman.CuteSurprise();
            }
        }

        if(meowDuration <= meowTime*Time.deltaTime) {
            animator.SetBool("isMeowing", false);
            meow = false;
        }

        if(meow) {
            meowTime++;
            rigidbody.MovePosition(rigidbody.position);
            return;
        }
        //walk left and right
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

        //jump triggered
        if (input[1] > 0 && !jump && !falling) {
            animator.SetTrigger("rising");
            jump = true;
            jumpHeight = 0;
            speed.Set(speed[0], 6.0f);
        }
        //variable height for jumps
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

        //check for free fall
        if (speed[1] < -0.01f && !falling) {
            animator.SetBool("isFalling",true);
            falling = true;
        }

        //velocity = rigidbody.velocity;
        speed.Set(speed[0] + acceleration[0], speed[1] + acceleration[1]*lowerG);
        

        //landing of a jump
        if ( (grounded > 0) && falling) {
            jump = false;
            falling = false;
            animator.SetBool("isFalling", false);
        }

        //don't accelerate toward the ground
        if (grounded > 0) {
            speed[1] = Mathf.Max(speed[1], 0.0f);
        }
        rigidbody.MovePosition(rigidbody.position + speed * Time.deltaTime);

    }


    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.tag == "Meow Zone") {
            fisherman = coll.gameObject.GetComponentInParent<FishermanController>();
        }
        if(coll.gameObject.layer == waterlayer) {
            die();
        }
        if (coll.gameObject.tag == "Cat Danger") {
            die();
        }
    }

    void OnTriggerExit2D(Collider2D coll) {
        if (coll.gameObject.tag == "Meow Zone") {
            fisherman = null;
        }
    }

    void die() {
        animator.SetBool("isDead",true);
        GetComponent<Collider2D>().enabled = false;
        speed.Set(0.0f, -0.2f);
        immobile = true;
        Debug.Log(immobile);
    }


}
