﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBreath : MonoBehaviour {
    public float breathDuration = 5.0f;
    public GameObject bar;

    private float breathTimer = 0.0f;
    private float maxX;
    private Vector3 offset;

    private FishMovement movement;
    private FishHealth health;

	// Use this for initialization
	void Start () {
        movement = GetComponent<FishMovement>();
        health = GetComponent<FishHealth>();

        maxX = bar.transform.localScale.x;
        offset = bar.transform.position - transform.position;

        breathTimer = breathDuration;
	}
	
	// Update is called once per frame
	void Update () {
        bar.transform.position = transform.position + offset;

		if (movement.inWater > 0) {
            breathTimer = breathDuration;
            bar.SetActive(false);
        } else {
            breathTimer -= Time.deltaTime;
            if (breathTimer < (breathDuration * 0.95f))
                bar.SetActive(true);

            float x = Mathf.Max(0.0f, maxX * breathTimer / breathDuration);
            float y = bar.transform.localScale.y, z = bar.transform.localScale.z;
            bar.transform.localScale = new Vector3(x, y, z);

            if (breathTimer < 0.0f) {
                health.TakeDamage(health.maxHealth);
                this.enabled = false;
            }
        }
	}

    /*
    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 200, 200), "Breath Duration: " + breathDuration, GUIStyle.none);
        GUI.Label(new Rect(10, 30, 200, 200), "Breath Timer: " + breathTimer, GUIStyle.none);
        GUI.Label(new Rect(10, 50, 200, 200), "Breath Display: " + (breathDuration * 0.95f), GUIStyle.none);
    }
    */
}
