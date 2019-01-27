using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GGJSplash : MonoBehaviour {

	void EndSplash () {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
