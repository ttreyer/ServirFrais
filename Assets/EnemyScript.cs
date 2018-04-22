using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private int length = 150;
    private int timeToGo;
    private bool goLeft = true;
    Rigidbody2D rb;
    private float x;
    private float v = 0.05f;

    private float offsetX = 0;
    private float offsetY = 0;

    // Use this for initialization
    void Start()
    {
        timeToGo = length;
        rb = GetComponent<Rigidbody2D>();
        offsetX = rb.position.x;
        offsetY = rb.position.y;
        x = offsetX;

        v += Random.Range(-0.02f,0.02f);
        length += Random.Range(-10, 10);
    }

    // Update is called once per frame
    void Update()
    {

        if (timeToGo < 0)
        {
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
            x-=v;
            transform.localRotation = Quaternion.Euler(0, 0, 0);

        }
        else
        {
            rb.transform.position = new Vector2(x, offsetY);
            x+=v;
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
