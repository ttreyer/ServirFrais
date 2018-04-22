using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishermanController : MonoBehaviour {
    public float surpriseDuration = 4.0f;

    private Animator animator;
    private Collider2D fishLineCollider;

    private float surpriseTimer = 0.0f;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();

        Collider2D[] colliders = GetComponentsInChildren<Collider2D>();
        foreach (Collider2D collider in colliders) {
            if (collider.CompareTag("Fish Line")) {
                fishLineCollider = GetComponentInChildren<Collider2D>();
                break;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (surpriseTimer < 0.0f) {
            fishLineCollider.enabled = true;
            animator.SetBool("isSurprised", false);
        } else {
            surpriseTimer -= Time.deltaTime;
            fishLineCollider.enabled = false;
            animator.SetBool("isSurprised", true);
        }
	}

    public void CuteSurprise()
    {
        surpriseTimer = surpriseDuration;
    }
}
