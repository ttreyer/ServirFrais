using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public float speed = 10.0f;
    public Transform[] targets;
    private CatMovement cat;
    private FishMovement fish;

    private void Start()
    {

        cat = GameObject.FindGameObjectsWithTag("Cat")[0].GetComponent<CatMovement>();
        fish = GameObject.FindGameObjectsWithTag("Fish")[0].GetComponent<FishMovement>();
    }

    // Update is called once per frame
    void Update () {

        if (cat.isAlive())
        {
            float centerX = 0;
            foreach (Transform target in targets)
                centerX += target.position.x;
            centerX /= targets.Length;

            Vector3 center = new Vector3(centerX, transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, center, speed * Time.deltaTime);
        }
    }
}
