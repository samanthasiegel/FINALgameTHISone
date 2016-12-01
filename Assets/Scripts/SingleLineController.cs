using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SingleLineController : MonoBehaviour {

	/** GLOBAL VARIABLES ***************************/

	// Handle changes to UI
	public GameObject SingleDialogue;
	public string Quote;
	public Font QuoteFont;

	/** FUNCTIONS **********************************/

	// Display single text quote in UI
	public void DisplayDialogue(){
		SingleDialogue.SetActive (true);
		Text SingleText = SingleDialogue.GetComponentInChildren<Text> ();
		SingleText.font = QuoteFont;
		SingleText.text = Quote;
	}
}
