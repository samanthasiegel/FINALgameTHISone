using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InteractionGraph{
	public InteractionNode CurrentNode;
	public InteractionNode[] CurrentList, OriginalList;

	public InteractionGraph(InteractionNode[] list){
		this.CurrentList = list;
		this.OriginalList = list;
	}

	public InteractionGraph(InteractionNode curr, InteractionNode[] origList){
		this.CurrentNode = curr;
		this.CurrentList = origList;
		this.OriginalList = origList;
	}

	public void UpdateUI(Text JustText, GameObject ButtonContainer){
		JustText.text = "";
		Button[] buttons = ButtonContainer.GetComponentsInChildren<Button> ();
		int i = 0;
		for (int j = 0; j < CurrentList.Length; j++) {
			buttons [i++].GetComponentInChildren<Text> ().text = CurrentList [j].Question;
		}
	}

	public bool FindUserInput(string clicked, GameObject ButtonContainer, Text JustText, GameObject NextButton){
		for (int i = 0; i < CurrentList.Length; i++) {
			if (CurrentList [i].Question.Equals (clicked)) {
				// show answer
				ButtonContainer.SetActive(false);
				CurrentList [i].Asked = true;
				JustText.text = CurrentList [i].Answer;
				CurrentNode = CurrentList [i];
				NextButton.SetActive (true);
				// wait until click next
				return false;
			}
		}
		return true;
	}

	public void Next(Text JustText, GameObject NextButton, GameObject ButtonContainer){
		JustText.text = "";
		NextButton.SetActive (false);
		ButtonContainer.SetActive (true);
		if (CurrentNode.Adj.Length > 0) {
			CurrentList = CurrentNode.Adj;
		} else {
			CurrentList = OriginalList;
		}
	}






}
