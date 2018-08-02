using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public float speed = 10.0f;
    public Transform[] targets;
    private CatMovement cat;
    private FishHealth fish;

    private void Start()
    {

        cat = GameObject.FindGameObjectWithTag("Cat").GetComponent<CatMovement>();
        fish = GameObject.FindGameObjectWithTag("Fish").GetComponent<FishHealth>();
    }

    // Update is called once per frame
    void Update () {

        if (cat.isAlive() && fish.IsAlive())
        {
            float centerX = 0;
            foreach (Transform target in targets)
                centerX += target.position.x;
            centerX /= targets.Length;

            centerX = Mathf.Clamp(centerX, 2.0f, 250.0f);

            Vector3 center = new Vector3(centerX, transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, center, speed * Time.deltaTime);
        }
    }
}
