using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpriteScript : MonoBehaviour{

	/** GLOBAL VARIABLES ***************************/

	// Handle sprite animation
	public bool IsAnimated;
	private Animator SpriteAnimator;

	// Handle UI changes
	public GameObject DialogueContainer;
	public Text NotificationText;

	/** FUNCTIONS *********************************/

	// Initialize animator
	void Start(){
		if(IsAnimated){
			SpriteAnimator = GetComponent<Animator>();
			SpriteAnimator.SetBool("Dialogue", false);
		}
	}

	// Animate sprite and activate UI
	public void StartDialogue(){
		if(IsAnimated){
			SpriteAnimator.SetBool("Dialogue", true);
		}
		NotificationText.text = "";
		if (!this.gameObject.tag.Equals ("Exit")) {
			DialogueContainer.SetActive (true);
		}
		if (GetComponent<MultiDialogueController> () != null) {
			GetComponent<MultiDialogueController> ().DisplayDialogue ();
		} else if (GetComponent<SingleLineController> () != null) {
			GetComponent<SingleLineController> ().DisplayDialogue ();
		}
	}

	// Deactivate animator
	public void ExitDialogue(){
		if(IsAnimated){
			SpriteAnimator.SetBool("Dialogue", false);
		}
	}
}