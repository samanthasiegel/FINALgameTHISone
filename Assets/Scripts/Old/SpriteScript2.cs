using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpriteScript2 : MonoBehaviour {

	/* Used to present dialogue with sprite */
	public GameObject DialogueBox;
	public Text NotificationText;

	public GameObject Hero;
	private bool Animated = false;

	/* Set UI based on user proximity and state */
	[HideInInspector] public bool InDialogue;

	// Use this for initialization
	void Start () {
		if (GetComponent<Animator> () != null) {
			Animated = true;
			GetComponent<Animator> ().SetBool ("Dialogue", false);
		}
	}
		
	
	// Update is called once per frame
	void Update () {
//		if (Hero.GetComponent<HeroScript> ().InDialogue) {
//			if (Animated) {
//				GetComponent<Animator> ().SetBool ("Dialogue", true);
//			}
//			NotificationText.text = "";
//			InDialogue = true;
//			DialogueBox.SetActive (true);
//		} else {
//			if (Animated) {
//				GetComponent<Animator> ().SetBool ("Dialogue", false);
//			}
//			DialogueBox.SetActive (false);
//			Button[] buttons = DialogueBox.GetComponentsInChildren<Button> ();
//			for (int i = 0; i < buttons.Length; i++) {
//				buttons [i].GetComponentInChildren<Text> ().text = "";
//			}
//			InDialogue = false;
//		}
//		if (Hero.GetComponent<HeroScript>().hit == this.GetComponent<Collider2D>()) {
//			if (Input.GetKey (KeyCode.Space)) {
//				if (Animated) {
//					GetComponent<Animator> ().SetBool ("Dialogue", true);
//				}
//				NotificationText.text = "";
//				Hero.GetComponent<HeroScript> ().InDialogue = true;
//				InDialogue = true;
//				DialogueBox.SetActive (true);
//			} else if (Input.GetKey (KeyCode.X)) {
//				if (Animated) {
//					GetComponent<Animator> ().SetBool ("Dialogue", false);
//				}
//				DialogueBox.SetActive (false);
//				Button[] buttons = DialogueBox.GetComponentsInChildren<Button> ();
//				for (int i = 0; i < buttons.Length; i++) {
//					buttons [i].GetComponentInChildren<Text> ().text = "";
//				}
//				Hero.GetComponent<HeroScript> ().InDialogue = false;
//				InDialogue = false;
//				if (!this.gameObject.tag.Equals ("Exit")) {
//					Hero.GetComponent<HeroScript> ().visited.Add (this.gameObject.tag);
//				}
//			}
//		}
	}


}
