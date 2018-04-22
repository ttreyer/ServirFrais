using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {
    private int length = 150;
    private int timeToGo;
    private bool goLeft = true;
    Rigidbody2D rb;
    private float x = 0;
    private float v = 3;

	// Use this for initialization
	void Start ()
    {
        timeToGo = length;
        rb = GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
	void Update () {

        if(timeToGo < 0)
        {
            goLeft = !goLeft;
            timeToGo = length;

        }
        else
        {
            timeToGo--;
        }

		if(goLeft)
        {
            rb.velocity = (new Vector2(-v,0));
            transform.localRotation = Quaternion.Euler(0, 0, 0);

        }
        else
        {
            rb.velocity = (new Vector2(v, 0f));
            transform.localRotation = Quaternion.Euler(0, 180, 0);

        }
	}
}
