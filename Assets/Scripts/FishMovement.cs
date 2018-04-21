using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour {
    public float waterSpeed = 20.0f;
    public float airSpeed = 10.0f;
    public float boostSpeed = 200.0f;
    public float rotationSpeed = 6.0f;
    public bool inWater = true;

    private Rigidbody2D rbody;
    private SpriteRenderer sprite;

    private int waterLayer;
    private float lookAtAnglePrev = 0.0f;
    private bool doBoost = false;

	// Use this for initialization
	void Start () {
        waterLayer = LayerMask.NameToLayer("Water");
        rbody = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
	}

    private void FixedUpdate() {
        Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 playerToMouse = Vector3.ClampMagnitude(target - transform.position, 1.0f);

        // Rotate before dead zone
        Rotate(playerToMouse);

        // Set a dead zone for the fish movements
        playerToMouse.z = 0.0f;
        if (playerToMouse.sqrMagnitude < 0.0005f)
            playerToMouse = Vector3.zero;

        Move(playerToMouse);

        if (doBoost) {
            doBoost = false;
            Boost(playerToMouse);
        }   
    }

    private void Move(Vector3 playerToMouse)
    {
        float movementSpeed = waterSpeed;

        if (!inWater) {
            movementSpeed = airSpeed;
            playerToMouse.y = 0.0f;
        }

        rbody.AddForce(playerToMouse * movementSpeed);
    }

    private void Rotate(Vector3 playerToMouse)
    {
        float targetAngle = Mathf.Atan2(playerToMouse.y, playerToMouse.x) * Mathf.Rad2Deg;
        float lookAtAngle = Mathf.LerpAngle(lookAtAnglePrev, targetAngle, rotationSpeed * Time.deltaTime);
        rbody.MoveRotation(lookAtAngle);
        lookAtAnglePrev = lookAtAngle;
    }

    private void Boost(Vector3 playerToMouse)
    {
        if (inWater) {
            rbody.AddForce(playerToMouse.normalized * boostSpeed);
        }
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown(0))
            doBoost = true;

        if (inWater) {
            rbody.gravityScale = 0.0f;
            rbody.drag = 20.0f;
            sprite.color = new Color(0.3f, .4f, 1.0f);
        } else {
            rbody.gravityScale = 10.0f;
            rbody.drag = 1.0f;
            sprite.color = new Color(0.2f, 0.2f, 0.2f);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == waterLayer)
            inWater = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == waterLayer)
            inWater = false;
    }
}
