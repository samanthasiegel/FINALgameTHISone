using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

//TODO: Make this cleaner and versatile to fit other situations
//TODO: Make conditions so Bernie can't exit room until talks to everyone/interacts with everything

public class GaryScript_Scene1 : MonoBehaviour {


	public GameObject ButtonContainer;
	public GameObject NextButton;
	public Text JustText;
	[HideInInspector] public bool ShowQuestions = true;
	public InteractionGraph Graph;

	void Start(){
		InteractionNode n0 = new InteractionNode ("What brings you to Foxville Estates?", "Um, what is Foxville Estates?", 2);
		InteractionNode n1 = new InteractionNode ("Are you serious?", "Oh, it's where we are now, right... I'm here for the dinner party.", 0);
		InteractionNode n2 = new InteractionNode ("Jon Hannity's house? Where we are now?", "Oh, it's where we are now, right... I'm here for the dinner party.", 0);
		InteractionNode n3 = new InteractionNode ("Have you stayed in contact with Jon?", "No, I haven't spoken to him since high school." +
		          " I was surprised by the invitation too!", 0);
		n0.Adj [0] = n1;
		n0.Adj [1] = n2;
		InteractionNode[] OriginalList = new InteractionNode[2];
		OriginalList[0] = n0;
		OriginalList [1] = n3;
		Graph = new InteractionGraph (OriginalList);
	}

	void Update(){
		if (GetComponent<SpriteScript>().InDialogue && ShowQuestions) {
			Graph.UpdateUI (JustText, ButtonContainer);
		}
	}

	public void Option1Clicked(){
		string clicked = ButtonContainer.GetComponentsInChildren<Button> () [0].GetComponentInChildren<Text> ().text;
		FindUserInput (clicked);
	}

	public void Option2Clicked(){
		string clicked = ButtonContainer.GetComponentsInChildren<Button> () [1].GetComponentInChildren<Text> ().text;
		FindUserInput (clicked);
	}

	void FindUserInput(string clicked){
		ShowQuestions = Graph.FindUserInput (clicked, ButtonContainer, JustText, NextButton);
	}

	public void NextClicked(){
		Graph.Next (JustText, NextButton, ButtonContainer);
		ShowQuestions = true;
	}

}
