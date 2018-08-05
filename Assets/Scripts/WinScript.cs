using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required when Using UI elements.

public class WinScript : MonoBehaviour {
    private Canvas c;

    // Use this for initialization
    void Start() {
        c = GetComponent<Canvas>();
        c.enabled = false;
    }


    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Cat"))
            c.enabled = true;
    }
}
