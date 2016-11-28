using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class InstructionsScript : MonoBehaviour {



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void NextButtonClicked(){
		SceneManager.LoadScene (2);
	}
}
