using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CatMovement : MonoBehaviour {
    float maxVelocity = 5.0f;

    Vector2 acceleration;
    Vector3 speed;
    Rigidbody2D rigidbody;

	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate() {
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"),0 , Input.GetAxis("Vertical"));
        if(input[0] < 0) {
            speed.Set(-maxVelocity*Time.deltaTime, 0,0);
        } else if(input[0] > 0) {
            speed.Set(maxVelocity*Time.deltaTime, 0,0);
        } else {
            speed.Set(0,0,0);
        }
        
        rigidbody.MovePosition(transform.position + speed);
    }



}
