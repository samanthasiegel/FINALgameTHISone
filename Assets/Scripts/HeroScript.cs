using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class HeroScript : MonoBehaviour{

	/** GLOBAL VARIABLES ***************************/

	// Handles player movement
	public float playerSpeed = 200f;
	private Rigidbody2D rb2d;

	// Handles interaction with other scene objects
	[HideInInspector] public HashSet<string> Visited = new HashSet<string>();
	public LayerMask layerMask;
	private string CollidedTag;

	// Detects type of object player collides with
	private int SpriteLayer = 10;
	private int ObjectLayer = 11;
	private int ExitLayer = 12;

	// Sets/disables UI
	public Text NotificationText;
	public GameObject DialogueContainer, SingleDialogue, MultiDialogue;
	public Font StartFont;

	// Detects if player in dialogue 
	private bool InDialogue = true;

	// Initial quote displayed in each scene
	public string StartQuote;



	/** FUNCTIONS *********************************/

	// Display start text
	void Start(){
		rb2d = GetComponent<Rigidbody2D>();
		DialogueContainer.SetActive (true);
		Text SingleText = SingleDialogue.GetComponentInChildren<Text> ();
		SingleText.text = StartQuote;
		SingleText.font = StartFont;
	}

	void Update(){
		// Start dialogue if we're colliding with another scene object
		if(CollidedTag != null){
			GameObject CollidedObject = GameObject.FindGameObjectWithTag(CollidedTag);
			if(Input.GetKey(KeyCode.Space)){
				InDialogue = true;
				if (CollidedObject.gameObject.layer == ExitLayer) {
					CollidedObject.GetComponent<ExitScript> ().CheckConditionsToExit ();
				} 
				CollidedObject.GetComponent<SpriteScript> ().StartDialogue ();
			}
		}
	}

	void FixedUpdate(){
		rb2d.velocity = new Vector2(0,0);
		if (!InDialogue) {
			// Player movement
			MoveHero ();
			// Raycast detection of other game objects
			Vector2[] VectorList = { Vector2.left, Vector2.right, Vector2.up };
			for (int i = 0; i < VectorList.Length; i++) {
				bool foundObject = SendRaycast (VectorList [i]);
				if (foundObject) { // If we hit another game object, break out of loop
					break;
				}
			}
		}
	}


	// Moves player based on input from keyboard arrow keys
	void MoveHero(){
		if(Input.GetKey("up")){
			rb2d.AddForce(Vector2.up * playerSpeed);
		}

		if(Input.GetKey("down")){
			rb2d.AddForce(Vector2.down * playerSpeed);
		}

		if(Input.GetKey("left")){
			rb2d.AddForce(Vector2.left * playerSpeed);
		}

		if(Input.GetKey("right")){
			rb2d.AddForce(Vector2.right * playerSpeed);
		}
	}

	// Sends raycast to detect collisions
	bool SendRaycast(Vector2 vector){
		Collider2D hit = Physics2D.OverlapCircle (transform.position, 2.5f, layerMask);
		if(hit != null ){
			string tag = hit.gameObject.tag;

			// If collided object is a sprite, set notification
			if(hit.gameObject.layer == SpriteLayer){
				NotificationText.text = "Talk to " + tag;
				CollidedTag = tag;
				return true;
			}

			// If collided object is a scene object, set notification
			if(hit.gameObject.layer == ObjectLayer){
				NotificationText.text = "Look at " + tag.ToLower();
				CollidedTag = tag;
				return true;
			}

			// If collided object is the exit, set notification
			if(hit.gameObject.layer == ExitLayer){
				NotificationText.text = "Move to the " + hit.gameObject.GetComponent<ExitScript>().Room;
				CollidedTag = tag;
				return true;
			}
		}
		// If no collided object, reset notification to be empty
		NotificationText.text = "";
		CollidedTag = null;
		return false;
	}

	// Reset dialogue UI on exit
	public void ExitDialogueClicked(){
		InDialogue = false;
		if(CollidedTag != null){
			GameObject CollidedObject = GameObject.FindGameObjectWithTag (CollidedTag);
			CollidedObject.GetComponent<SpriteScript> ().ExitDialogue ();
			if (!CollidedTag.Equals ("Exit")) {
				Visited.Add (CollidedTag);
			}
		}

	}


}