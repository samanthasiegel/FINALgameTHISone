using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BarryScript_Scene1 : MonoBehaviour {

	public Text DialogueText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<SpriteScript> ().InDialogue) {
			DialogueText.text = "I... am so honored... to be... here!";
		}
	
	}
}
