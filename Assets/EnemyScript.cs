using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private int length = 200;
    private int timeToGo;
    private bool goLeft = true;
    Rigidbody2D rb;
    private float x;
    private float v = 3;

    public float offsetX = 0;
    public float offsetY = 0;

    // Use this for initialization
    void Start()
    {
        timeToGo = length;
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(-v, 0f));
        offsetX = rb.position.x;

    }

    // Update is called once per frame
    void Update()
    {

        if (timeToGo < 0)
        {
            x = offsetX;
            goLeft = !goLeft;
            timeToGo = length;
        }
        else
        {
            timeToGo--;
        }
        if (!goLeft)
        {
            rb.transform.position = new Vector2(x, offsetY);
            x+=0.01f;
            transform.localRotation = Quaternion.Euler(0, 0, 0);

        }
        else
        {
            rb.transform.position = new Vector2(x, offsetY);
            x-=0.01f;
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
