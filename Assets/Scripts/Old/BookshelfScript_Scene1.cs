using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BookshelfScript_Scene1 : MonoBehaviour {

	public Text DialogueText;
	public Font ItalicFont;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<SpriteScript> ().InDialogue) {
			DialogueText.font = ItalicFont;
			DialogueText.text = "You see a small collection of Jon's books, including titles like "+ 
				"'Why Fossil Feuls Are The Best' and 'Global Warming Was a Hoax Started by the Chinese.'";
		}
	}
}
