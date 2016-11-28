using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LizScript_Scene1 : MonoBehaviour {

	public Text DialogueText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<SpriteScript> ().InDialogue) {
			DialogueText.text = "I'm feeling a little suspicious about this dinnner, something isn't right." +
			" We haven't spoken to any of these people since high school! I think Gary wanted to say hi" +
			" to you before dinner starts...";
		}
	
	}
		
}
