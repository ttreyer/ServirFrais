using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudsMovement : MonoBehaviour {

    private int nbChild;
    private Transform currentChild;
    private float[] x;
    public float v;

    // Use this for initialization
    void Start () {
		nbChild = this.gameObject.transform.childCount;
        x = new float[nbChild];

        for (int i = 0; i < nbChild; i++)
        {
            x[i] = this.gameObject.transform.GetChild(i).position.x;
        }
    }
	
	// Update is called once per frame
	void Update () {

        for (int i = 0; i < nbChild; i++) {
            currentChild = this.gameObject.transform.GetChild(i);
            currentChild.position = new Vector3(x[i], currentChild.position.y,6f);
            x[i] += v;
        }
    }

}
