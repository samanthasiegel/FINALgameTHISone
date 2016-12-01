using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SceneControllerScript : MonoBehaviour {

	public string StartQuote;
	public Font StartFont;
	public Text SingleText;
	public GameObject DialogueContainer;
	public GameObject MultiDialogue;

	// Use this for initialization
	void Start () {
		DialogueContainer.SetActive (true);
		SingleText.text = StartQuote;
		SingleText.font = StartFont;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ExitDialogue(){
		DialogueContainer.SetActive (false);
		SingleText.text = "";
		GameObject[] DialogueOptions = MultiDialogue.GetComponentsInChildren<GameObject> ();
		for (int i = 0; i < DialogueOptions.Length; i++) {
			GameObject go = DialogueOptions [i];
			go.SetActive (false);
		}
		MultiDialogue.SetActive (false);
	}
}
