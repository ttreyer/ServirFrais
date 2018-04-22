using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class algueSpawner : MonoBehaviour {

    public GameObject algue;
    public GameObject algue1;

    Vector3 position = new Vector3(-5.3f, -4.3f, 0f);
    Vector3 position1 = new Vector3(-4.3f, -4.3f, 0f);
    float s;

    // Use this for initialization
    void Start () { 
        // algue
        
		for(int i=0; i < 20;  i++)
        {
            
            GameObject n = Instantiate(algue, position, Quaternion.identity);
            //s = Random.Range(0.5f, 1.3f);
            //n.transform.localScale = new Vector3(s,s,s);
            position += new Vector3(Random.Range(3f, 40.0f), Random.Range(-0.1f, 0.1f), 0);
        }
        

        // algue1
        for (int i = 0; i < 20; i++)
        {

            GameObject n = Instantiate(algue1, position1, Quaternion.identity);
            //s = Random.Range(0.5f, 1.3f);
            //n.transform.localScale = new Vector3(s,s,s);
            position1 += new Vector3(Random.Range(3f, 40.0f), Random.Range(-0.5f, 0.5f), 0);
        }
    }
	
	// Update is called once per frame
	void Update () {
        
	}
}
