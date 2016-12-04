using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayAgainScript : MonoBehaviour {

	public void PlayAgainClicked(){
		SceneManager.LoadScene (0);
	}
}
