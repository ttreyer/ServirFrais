using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollider : MonoBehaviour {
    CatMovement parentscript;

    // Use this for initialization
    void Start () {
        parentscript = GetComponentInParent<CatMovement>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.tag != "Cat" && coll.gameObject.tag != "Meow Zone" && coll.gameObject.tag != "Fish Line") {
            parentscript.grounded++;
            Debug.Log("grounded!");
        } 
    }

    void OnTriggerExit2D(Collider2D coll) {
        if (coll.gameObject.tag != "Cat" && coll.gameObject.tag != "Meow Zone" && coll.gameObject.tag != "Fish Line") {
            parentscript.grounded--;
            Debug.Log("décollage!");
        }
    }
}
