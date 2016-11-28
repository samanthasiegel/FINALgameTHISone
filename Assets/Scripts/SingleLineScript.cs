using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SingleLineScript : MonoBehaviour {

	public Text DialogueText;
	public string Quote;
	public Font font;

	// Update is called once per frame
	void Update () {
		if (GetComponent<SpriteScript> ().InDialogue) {
			DialogueText.font = font;
			DialogueText.text = Quote;
		}
	}
}
