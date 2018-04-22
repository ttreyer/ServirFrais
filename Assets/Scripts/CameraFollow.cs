using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public float speed = 10.0f;
    public Transform[] targets;
	
	// Update is called once per frame
	void Update () {
        Vector3 center = Vector3.zero;
        foreach (Transform target in targets)
            center += target.position;
        center /= targets.Length;
        center.z = -10.0f;

        transform.position = Vector3.Lerp(transform.position, center, speed * Time.deltaTime);
	}
}
