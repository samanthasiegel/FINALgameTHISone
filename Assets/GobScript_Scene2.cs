using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GobScript_Scene2 : MonoBehaviour {

	public GameObject ButtonContainer;
	public GameObject NextButton;
	public Text JustText;
	[HideInInspector] public bool ShowQuestions = true;
	public InteractionGraph Graph;

	void Start(){
		InteractionNode n0 = new InteractionNode ("Have we met before?", "I don't know...have we!?!?!", 2);
		InteractionNode n1 = new InteractionNode (".............", "Just kidding, we've never met. I'm Gob -- you may recognize me from the cover of " +
			"Poof magazine.  I'm a ~magician~", 0);
		InteractionNode n2 = new InteractionNode ("Oh...right, hey, um, you!", "Just kidding, we've never met. I'm Gob -- you may recognize me from the cover of " +
			"Poof magazine.  I'm a ~magician~", 0);
		InteractionNode n3 = new InteractionNode ("How do you know Jon Hannity?", "We worked together for a while after college, but have sort of lost" +
			" touch since then. I hope I haven't made a huge mistake by coming here tonight...", 0);
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
