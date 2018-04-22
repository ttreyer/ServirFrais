using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisabeSprinkler : MonoBehaviour {
    GameObject parent;
    Collider2D dangerZone;
    ParticleSystem ps;

    // Use this for initialization
    void Start() {
        parent = transform.parent.gameObject;
        ps = parent.GetComponentInChildren<ParticleSystem>();
        Collider2D[] colliders = parent.GetComponentsInChildren<Collider2D>();
        foreach (Collider2D collider in colliders) {
            if (collider.gameObject.CompareTag("Cat Danger")) {
                dangerZone = collider;
                break;
            }
        }
    }

    // Update is called once per frame
    void Update() {

    }

    void OnTriggerEnter2D(Collider2D coll) {
        Debug.Log("Jeremy");
        if (coll.gameObject.tag == "Fish") {
            Debug.Log("Mariano");
            dangerZone.enabled = false;
            ps.Stop();
        }
    }

    void OnTriggerExit2D(Collider2D coll) {
        if (coll.gameObject.tag == "Fish") {
            dangerZone.enabled = true;
            ps.Play();
        }
    }
}
