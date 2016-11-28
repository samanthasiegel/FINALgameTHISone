using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class HeroScript : MonoBehaviour{

	/* Handles player movement */
	public float playerSpeed = 200f;
	private Rigidbody2D rb2d;

	/* List of sprites and objects Player must interact with in scene */
	public List<string> SpriteTags = new List<string>();
	public List<string> ObjectTags = new List<string>();
	[HideInInspector] public HashSet<string> Visited = new HashSet<string>();
	public LayerMask layerMask;

	/* Name of next room in story */
	public string NextRoom;

	/* Text in lower left of screen to indicate when Player can interact with objects in scene */
	public Text NotificationText;

	/* Handles when player in dialogue with another scene object */
	private string CollidedTag;
	private bool InDialogue = false;

	void Start(){
		rb2d = GetComponent<Rigidbody2D>();
	}

	void Update(){
		// Start or stop dialogue if we're colliding with another scene object
		if(CollidedTag != null){
			GameObject CollidedObject = GameObject.FindGameObjectWithTag(CollidedTag);
			if(Input.GetKey(KeyCode.Space)){
				InDialogue = true;
				CollidedObject.GetComponent<SpriteScript>().StartDialogue();
			}
			else if(Input.GetKey(KeyCode.X)){
				InDialogue = false;
				CollidedObject.GetComponent<SpriteScript>().ExitDialogue();
			}
		}
	}

	void FixedUpdate(){
		// Player movement
		rb2d.velocity = new Vector2(0,0);
		if (!InDialogue) {
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


	/* Moves player based on input from keyboard arrow keys */
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

	/* Sends raycast to detect sprites or objects in the scene, and sets notification text accordingly */
	bool SendRaycast(Vector2 vector){
		Collider2D hit = Physics2D.OverlapCircle (transform.position, 1.5f, layerMask);
		if(hit != null ){
			string tag = hit.gameObject.tag;

			// If collided object is a sprite, set notification
			if(SpriteTags.Contains(tag)){
				NotificationText.text = "Talk to " + tag;
				CollidedTag = tag;
				return true;
			}
			// If collided object is a scene object, set notification
			if(ObjectTags.Contains(tag)){
				NotificationText.text = "Look at " + tag.ToLower();
				CollidedTag = tag;
				return true;
			}
			// If collided object is the exit, set notification
			if(tag.Equals("Exit")){
				NotificationText.text = "Move to " + NextRoom;
				CollidedTag = tag;
				return true;
			}
		}
		// If no collided object, reset notification to be empty
		NotificationText.text = "";
		CollidedTag = null;
		return false;
	}

}