using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

public class ExitScript : MonoBehaviour {

	public GameObject DialogueContainer;
	public Text DialogueText;
	public Font font;

	/* Loads next seen if all Player has completed objectives in current scene */
	void Update () {
		if (GetComponent<SpriteScript> ().InDialogue) {
			DialogueText.font = font;
			HashSet<string> visited = GameObject.FindGameObjectWithTag("Hero").GetComponent<HeroScript>().Visited;
			if (!visited.Contains ("Liz Battleon")) {
				DialogueContainer.SetActive (true);
				DialogueText.text = "You should talk to Liz before leaving the room.";
				return;
			} else if (!visited.Contains ("Gary Williams")) {
				DialogueContainer.SetActive (true);
				DialogueText.text = "Didn't Liz say Gary wanted to speak with you?";
				return;
			}
			if (visited.Count < 3) {
				DialogueContainer.SetActive (true);
				DialogueText.text = "I have this nagging feeling like I'm forgetting something in this room..."
				+ "Did I talk to everyone? That bookshelf looks interesting too.";
				return;
			}
			DialogueContainer.SetActive (false);
			SceneManager.LoadScene (3);
		}

	}
}
