using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required when Using UI elements.

public class gameoverScript : MonoBehaviour {

    private CatMovement cat;
    private FishHealth fish;
    private Canvas c;

    // Use this for initialization
    void Start ()
    {
        cat = GameObject.FindGameObjectWithTag("Cat").GetComponent<CatMovement>();
        fish = GameObject.FindGameObjectWithTag("Fish").GetComponent<FishHealth>();
        
        c = GetComponent<Canvas>();
        c.enabled = false;

    }
	
	// Update is called once per frame
	void Update () {
        if (!cat.isAlive() || !fish.IsAlive())
        {
            c.enabled = true;
        }
    }
}
