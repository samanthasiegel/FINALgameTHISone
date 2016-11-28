using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


// Dialogue node used to construct tree
public class DialogueNode{
	public string DialogueText;
	public string Choice1, Choice2;
	public DialogueNode Left, Right;

	public DialogueNode(){
	}

	public DialogueNode(string text, string choice1, string choice2){
		this.DialogueText = text;
		this.Choice1 = choice1;
		this.Choice2 = choice2;
		this.Left = null;
		this.Right = null;
	}
}
	


//What do I want to eat? C1: Apple, C2: Orange
//IF APPLE --> scenario 1 --> What do I want to drink? C1: Coke, C2: Sprite
//IF ORANGE --> scenario 2 --> What do I want to wear? C1: Dress, C2: Skirt
//IF COKE --> scenario 3 --> Yay!
//IF SPRITE --> scenario 4 --> OK!
//IF DRESS --> scenario 5 --> BEAUTIFUL
//IF SKIRT --> scenario 6 --> LOVELY

public class DialogueScript : MonoBehaviour {

	public Text MainText;
	public Button Choice1, Choice2;
	private DialogueNode CurrentDialogue;
	private DialogueNode[] list;

	// Use this for initialization
	void Start () {

		DialogueNode root = new DialogueNode ("What do you want to eat?", "Apple", "Orange");
		DialogueNode d0 = new DialogueNode ("What do you want to drink?", "Coke", "Sprite");
		DialogueNode d1 = new DialogueNode("What do you want to wear?", "Dress", "Skirt");
		DialogueNode d2 = new DialogueNode ("Yay!", null, null);
		DialogueNode d3 = new DialogueNode ("Ok!", null, null);
		DialogueNode d4 = new DialogueNode ("Beautiful.", null, null);
		DialogueNode d5 = new DialogueNode ("Lovely.", null, null);

		root.Left = d0;
		root.Right = d1;
		d0.Left = d2;
		d0.Right = d3;
		d1.Left = d4;
		d1.Right = d5;

		this.CurrentDialogue = root;
		SetText ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void ClickChoice1(){
		if (CurrentDialogue.Left != null) {
			CurrentDialogue = CurrentDialogue.Left;
			SetText ();
		}
	}

	public void ClickChoice2(){
		if (CurrentDialogue.Right != null) {
			CurrentDialogue = CurrentDialogue.Right;
			SetText ();
		}
	}

	void SetText(){
		MainText.text = CurrentDialogue.DialogueText;
		if (CurrentDialogue.Choice1 == null) {
			Choice1.GetComponentInChildren<Text> ().text = "";
			Choice1.GetComponent<Button> ().interactable = false;
		} else {
			Choice1.GetComponentInChildren<Text> ().text = CurrentDialogue.Choice1;
		}
		if (CurrentDialogue.Choice2 == null) {
			Choice2.GetComponent<Button> ().interactable = false;
			Choice2.GetComponentInChildren<Text> ().text = "";
		} else {
			Choice2.GetComponentInChildren<Text> ().text = CurrentDialogue.Choice2;
		}
	}
}
