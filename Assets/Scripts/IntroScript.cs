using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroScript : MonoBehaviour {

	public Button NextButton, LoadButton;
	public GameObject Text1, Text2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void NextButtonClicked(){
		Text1.SetActive (false);
		Text2.SetActive (true);
	}

	public void LoadButtonClicked(){
		SceneManager.LoadScene (1);
	}
}
