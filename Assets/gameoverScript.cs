using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameoverScript : MonoBehaviour {

    private CatMovement cat;
    private FishMovement fish;

    // Use this for initialization
    void Start ()
    {
        cat = GameObject.FindGameObjectsWithTag("Cat")[0].GetComponent<CatMovement>();
        fish = GameObject.FindGameObjectsWithTag("Fish")[0].GetComponent<FishMovement>();

        this.GetComponent<Renderer>().enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
        

        if (!cat.isAlive())
        {
            this.GetComponent<Renderer>().enabled = true;


            Vector3 pos = GameObject.FindGameObjectsWithTag("MainCamera")[0].GetComponent<GameObject>().transform.position;//new Vector3(10, 0, 0);

            this.transform.position = pos;
        }
    }
}
