using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishLineDamage : MonoBehaviour {
    public int damageAmount = 1;

    private FishHealth fish;

	// Use this for initialization
	void Start () {
        fish = GameObject.FindGameObjectWithTag("Fish").GetComponent<FishHealth>();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fish"))
            fish.TakeDamage(damageAmount);
    }
}
