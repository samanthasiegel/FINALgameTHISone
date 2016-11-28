using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DrinksScript : MonoBehaviour {

	public Text DialogueText;
	public Font ItalicFont;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<SpriteScript> ().InDialogue) {
			DialogueText.font = ItalicFont;
			DialogueText.text = "You see a few cups of wine.  It looks like someone drank from the cup on the far right. " +
				"You could really use some wine right now...";
		}

	}
}
