using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RonaldScript_Scene1 : MonoBehaviour {

	public Text DialogueText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<SpriteScript> ().InDialogue) {
			DialogueText.text = "I never really liked any of you in high school. Especially Liz, such a nasty woman.";
		}
	}
}
