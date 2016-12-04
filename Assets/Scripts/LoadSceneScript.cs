using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadSceneScript : MonoBehaviour {

	public int SceneToLoad;

	public void PlayAgainClicked(){
		SceneManager.LoadScene (SceneToLoad);
	}
}
