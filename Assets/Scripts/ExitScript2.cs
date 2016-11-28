using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;
public class ExitScript2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public Text DialogueText;

	void Update () {
		if (GetComponent<SpriteScript> ().InDialogue) {
			HashSet<string> visited = GameObject.FindGameObjectWithTag("Hero").GetComponent<HeroScript>().Visited;
			if (!visited.Contains ("Michelle")) {
				DialogueText.text = "It's rude not to say hello to your old high school friend Michelle before exiting the room!";
				return;
			} else if (!visited.Contains ("Gob")) {
				DialogueText.text = "Who's that strange man in the pink sweater over there? You should talk to him before moving on.";
				return;
			}
			if (visited.Count < 5) {
				DialogueText.text = "I can't leave yet, I haven't talked to everyone! I'm feeling a little thirsty too...";
				return;
			}
			SceneManager.LoadScene (3);

		}

	}
}
