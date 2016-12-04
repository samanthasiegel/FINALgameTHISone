using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalSceneScript : MonoBehaviour {

	/** GLOBAL VARIABLES ***************************/

	// Detect when player interacted with everyone, displays final prompt
	public string[] RequiredInteractions;
	public GameObject Hero, EndUI, DialogueContainer;
	public AudioSource SoundEffect;

	private bool EndDisplayed = false;

	private string PrevSelection;

	void Update () {
		if (ShowEnd () && !EndDisplayed) {
			DialogueContainer.SetActive (true);
			EndUI.SetActive (true);
			Hero.GetComponent<HeroScript> ().InDialogue = true;
			SoundEffect.PlayOneShot (SoundEffect.clip);
			EndDisplayed = true;
		}
	}

	/** FUNCTIONS **********************************/

	// Returns true if player interacted with everyone, false otherwise
	bool ShowEnd(){
		HashSet<string> VisitedSet = Hero.GetComponent<HeroScript> ().Visited;
		foreach (string tag in RequiredInteractions) {
			if (!VisitedSet.Contains (tag)) {
				return false;
			}
		}
		return true;
	}

	public void FirstSelection(string tag){
		if (tag.Equals ("Newt Gingwealthy")) {
			PrevSelection = "Newt Gingwealthy";
		} else if (tag.Equals ("Chris Bridge")) {
			PrevSelection = "Chris Bridge";
		} else {
			SceneManager.LoadScene (10);
		}
	}

	public void SecondSelection(string tag){
		if (PrevSelection.Equals ("Newt Gingwealthy") && tag.Equals ("Chris Bridge")) {
			SceneManager.LoadScene (11);
		} else if (PrevSelection.Equals ("Chris Bridge") && tag.Equals ("Newt Gingwealthy")) {
			SceneManager.LoadScene (11);
		} else {
			SceneManager.LoadScene (10);
		}
	}
}
