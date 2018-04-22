using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required when Using UI elements.

public class gameoverScript : MonoBehaviour {

    private CatMovement cat;
    private FishMovement fish;
    private Canvas c;

    // Use this for initialization
    void Start ()
    {
        cat = GameObject.FindGameObjectsWithTag("Cat")[0].GetComponent<CatMovement>();
        fish = GameObject.FindGameObjectsWithTag("Fish")[0].GetComponent<FishMovement>();
        
        c = GetComponent<Canvas>();
        c.enabled = false;

    }
	
	// Update is called once per frame
	void Update () {
        if (!cat.isAlive())
        {
            c.enabled = true;
        }
    }
}
