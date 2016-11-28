using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class HeroScript3 : MonoBehaviour {

	public float playerSpeed = 100f;
	[HideInInspector] public bool InDialogue = false;
	[HideInInspector] public Rigidbody2D rb2d;

	[HideInInspector] public Collider2D hit;

	private List<string> PeopleTags = new List<string>();
	private List<string> ObjectTags = new List<string>();

	public Text NotificationText;
	public string NextRoom;

	[HideInInspector] public HashSet<string> visited = new HashSet<string>();

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		PeopleTags.Add ("Chris Bridge");
		PeopleTags.Add ("Ronald Rump");
		PeopleTags.Add ("Barry Oh");
		PeopleTags.Add ("Liz Battleon");
		PeopleTags.Add ("Gary Williams");
		PeopleTags.Add ("Michelle");
		PeopleTags.Add ("Gob");
		PeopleTags.Add ("Newt");
		PeopleTags.Add ("Kellyanne");

		ObjectTags.Add ("Bookshelf");
		ObjectTags.Add ("Exit");
		ObjectTags.Add ("Drinks");
	}

	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate(){
		rb2d.velocity = new Vector2 (0, 0);
		if (!InDialogue) {
			MoveSprite ();
			Vector2[] list = { Vector2.left, Vector2.right, Vector2.up};
			for (int i = 0; i < list.Length; i++) {
				bool marked = SendRaycast (list [i]);
				if (marked) {
					break;
				}
			}
		}
	}
		
	void MoveSprite(){
		if (Input.GetKey ("up")) {//Press up arrow key to move forward on the Y AXIS
			rb2d.AddForce(Vector2.up * playerSpeed);
		}
		if (Input.GetKey ("down")) {//Press up arrow key to move forward on the Y AXIS
			rb2d.AddForce(Vector2.down * playerSpeed);
		}
		if (Input.GetKey ("left")) {//Press up arrow key to move forward on the Y AXIS
			rb2d.AddForce(Vector2.left * playerSpeed);
		}
		if (Input.GetKey ("right")) {//Press up arrow key to move forward on the Y AXIS
			rb2d.AddForce(Vector2.right * playerSpeed);
		}
	}

	bool SendRaycast(Vector2 vector){
		RaycastHit2D cast = Physics2D.Raycast (transform.position, vector, 2.5f);
		if (cast.collider != null) {
			string tag = cast.collider.gameObject.tag;
			Debug.Log (tag);
			if (PeopleTags.Contains (tag)) {
				NotificationText.text = "Talk to " + tag;
				hit = cast.collider;
				return true;
			} 
			if (tag.Equals ("Exit")) {
				NotificationText.text = "Move to " + NextRoom;
				hit = cast.collider;
				return true;
			} 
			if (ObjectTags.Contains (tag)) {
				NotificationText.text = "Look at " + tag;
				hit = cast.collider;
				return true;
			} 
		}
		NotificationText.text = "";
		hit = null;
		return false;
	}


}
