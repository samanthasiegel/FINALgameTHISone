using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndDialogueController : MonoBehaviour {

	/** GLOBAL VARIABLES ***************************/

	// Handle UI of end message
	public GameObject ExitTrigger, DialogueContainer, ExitContainer;
	[HideInInspector] public bool Displayed = false;
	public AudioSource SoundEffect;


	/** FUNCTIONS **********************************/

	// Display end message if all required objects interacted with
	void Update () {
		if (ExitTrigger.GetComponent<ExitScript> ().RequiredInteractionsComplete () && !Displayed) {
			GameObject Hero = GameObject.FindGameObjectWithTag ("Hero");
			Hero.GetComponent<HeroScript> ().InDialogue = true;
			DialogueContainer.SetActive (true);
			ExitContainer.SetActive (true);
			Displayed = true;
			SoundEffect.PlayOneShot (SoundEffect.clip);
		}
	}
}
