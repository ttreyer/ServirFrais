using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScript : MonoBehaviour {

	// Use this for initialization
	public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
