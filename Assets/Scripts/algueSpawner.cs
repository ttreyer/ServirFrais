using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class algueSpawner : MonoBehaviour {

    public GameObject algue;
    public GameObject algue1;

    Vector3 position = new Vector3(-5.3f, -4.3f, 0f);
    Vector3 position1 = new Vector3(-6.3f, -4.3f, 0f);
    float s;

    // Use this for initialization
    void Start () { 
        // algue1
		for(int i=0; i < 10;  i++)
        {
            
            GameObject n = Instantiate(algue, position, Quaternion.identity);
            //s = Random.Range(0.5f, 1.3f);
            //n.transform.localScale = new Vector3(s,s,s);
            position += new Vector3(Random.Range(3f, 30.0f), 0, 0);
        }

        // algue2
        for (int i = 0; i < 10; i++)
        {

            GameObject n = Instantiate(algue1, position, Quaternion.identity);
            //s = Random.Range(0.5f, 1.3f);
            //n.transform.localScale = new Vector3(s,s,s);
            position1 += new Vector3(Random.Range(3f, 30.0f), 0, 0);
        }
    }
	
	// Update is called once per frame
	void Update () {
        
	}
}
