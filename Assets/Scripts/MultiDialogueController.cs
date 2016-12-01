using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MultiDialogueController : MonoBehaviour {

	/** GLOBAL VARIABLES ***************************/

	// Handle UI changes
	public GameObject MultiDialogue;
	public GameObject RootDialogue;


	/** FUNCTIONS **********************************/

	// Enables multi dialogue UI
	public void DisplayDialogue(){
		MultiDialogue.SetActive (true);
		RootDialogue.SetActive (true);
	}
}
