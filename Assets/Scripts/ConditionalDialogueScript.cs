using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ConditionalDialogueScript : MonoBehaviour {
	public Text DialogueText;
	public string Quote1, Quote2;
	private string CurrQuote;
	public Font font;
	public GameObject Trigger;

	void Start(){
		CurrQuote = Quote1;
	}

	// Update is called once per frame
//	void Update () {
//		if (GetComponent<SpriteScript> ().InDialogue) {
//			
//			if (Trigger.activeSelf) {
//				CurrQuote = Quote2;
//			}
//			DialogueText.text = CurrQuote;
//			DialogueText.font = font;
//		}
//	}
}
