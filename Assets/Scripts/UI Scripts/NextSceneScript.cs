using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NextSceneScript : MonoBehaviour {

	public int NextScene;

	// Loads first scene
	public void NetxSceneClicked(){
		SceneManager.LoadScene (NextScene);
	}
}

