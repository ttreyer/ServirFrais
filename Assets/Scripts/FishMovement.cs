using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour {
    public float waterSpeed = 20.0f;
    public float airSpeed = 10.0f;
    public float boostSpeed = 200.0f;
    public float rotationSpeed = 6.0f;
    public int inWater = 0;

    private Rigidbody2D rbody;
    private Animator animator;

    private int waterLayer;
    private float lookAtAnglePrev = 0.0f;
    private bool doBoost = false;

	// Use this for initialization
	void Start () {
        waterLayer = LayerMask.NameToLayer("Water");
        rbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
	}

    private void FixedUpdate() {
        Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 playerToMouse = Vector3.ClampMagnitude(target - transform.position, 1.0f);

        // Rotate before dead zone
        Rotate(playerToMouse);

        // Set a dead zone for the fish movements
        playerToMouse.z = 0.0f;
        if (playerToMouse.sqrMagnitude > 0.25f) {
            animator.SetBool("isSwimming", true);
        } else {
            playerToMouse = Vector3.zero;
            animator.SetBool("isSwimming", false);
        }
        
        Move(playerToMouse);

        if (doBoost) {
            doBoost = false;
            Boost(playerToMouse);
        }   
    }

    private void Move(Vector3 playerToMouse)
    {
        float movementSpeed = waterSpeed;

        if (inWater == 0) {
            movementSpeed = airSpeed;
            playerToMouse.y = 0.0f;
        }

        rbody.AddForce(playerToMouse * movementSpeed);
    }

    private void Rotate(Vector3 playerToMouse)
    {
        float targetAngle = Mathf.Atan2(playerToMouse.y, playerToMouse.x) * Mathf.Rad2Deg;
        float lookAtAngle = Mathf.LerpAngle(lookAtAnglePrev, targetAngle, rotationSpeed * Time.deltaTime);
        lookAtAngle = (lookAtAngle + 360.0f) % 360.0f;
        rbody.MoveRotation(lookAtAngle);
        lookAtAnglePrev = lookAtAngle;

        // Flip fish when facing backward
        float x = transform.localScale.x;
        float y = transform.localScale.y;
        float z = transform.localScale.z;
        if (90.0f < lookAtAngle && lookAtAngle <= 270.0f)
            transform.localScale = new Vector3(x, -Mathf.Abs(y), z);
        else
            transform.localScale = new Vector3(x, Mathf.Abs(y), z);
    }

    private void Boost(Vector3 playerToMouse)
    {
        if (inWater > 0) {
            rbody.AddForce(playerToMouse.normalized * boostSpeed);
            animator.SetTrigger("boost");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            doBoost = true;

        if (inWater > 0) {
            rbody.gravityScale = 0.0f;
            rbody.drag = 20.0f;
        } else {
            rbody.gravityScale = 10.0f;
            rbody.drag = 1.0f;
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == waterLayer)
            inWater++;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == waterLayer)
            inWater--;
    }
}
