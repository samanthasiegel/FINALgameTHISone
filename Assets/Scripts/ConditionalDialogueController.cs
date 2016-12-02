using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ConditionalDialogueController: MonoBehaviour {
	public GameObject ConditionalDialogue, RootDialogue, Canvas;

	public void DisplayDialogue(){
		ConditionalDialogue.SetActive (true);
		RootDialogue.SetActive (true);
	}

}
