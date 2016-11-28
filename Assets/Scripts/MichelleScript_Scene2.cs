using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MichelleScript_Scene2 : MonoBehaviour {

	public Text DialogueText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<SpriteScript> ().InDialogue) {
			DialogueText.text = "It's so good to see you Bernie! Do you know if my husband has arrived yet? He always gets really" +
				" uncomfortable around Ronald...";
		}

	}
}
