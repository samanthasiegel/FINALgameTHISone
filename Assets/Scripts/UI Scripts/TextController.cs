using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

	public Text NotificationText;
	public GameObject NotificationImage;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (NotificationText.text.Length > 0) {
			NotificationImage.SetActive (true);
		} else {
			NotificationImage.SetActive (false);
		}
	
	}
}
