using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndDialogueController : MonoBehaviour {

	/** GLOBAL VARIABLES ***************************/

	// Handle UI of end message
	public GameObject ExitTrigger, DialogueContainer, ExitContainer;
	[HideInInspector] public bool Displayed = false;


	/** FUNCTIONS **********************************/

	// Display end message if all required objects interacted with
	void Update () {
		if (ExitTrigger.GetComponent<ExitScript> ().RequiredInteractionsComplete () && !Displayed) {
			GameObject.FindGameObjectWithTag ("Hero").GetComponent<HeroScript> ().InDialogue = true;
			DialogueContainer.SetActive (true);
			ExitContainer.SetActive (true);
			Displayed = true;
		}
	}
}
