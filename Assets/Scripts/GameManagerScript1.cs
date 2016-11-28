using UnityEngine;
using System.Collections;

public class GameManagerScript1 : MonoBehaviour {

	// Scene 0, objective 0
	// ProgressNode() --> scene number, objective number
	// each scene manager contains functions per objective number
	// each game manager contains functions per scene number

	public string[] SpriteTags;
	public string[] ObjectTags;

	void Start(){
	}














//	public GameObject Scene1, SceneTemp;
//	[HideInInspector] public ProgressNode progressNode;


	// Use this for initialization
//	void Start () {
//		int SceneProgress = PlayerPrefs.GetInt ("SceneProgress");
//		int ObjectiveProgress = PlayerPrefs.GetInt ("ObjectiveProgress");
//		if (SceneProgress == null) {
//			SceneProgress = 1;
//			Scene1.SetActive (true);
//		} else if(SceneProgress > 1){
//			Scene1.SetActive (false);
//			SceneTemp.SetActive (true);
//		}
//
//		if (ObjectiveProgress == null) {
//			ObjectiveProgress = 1;
//		}
//		progressNode = new ProgressNode (SceneProgress, ObjectiveProgress);
//	}
//	
//	// Update is called once per frame
//	void Update () {
//	
//	}
//
//	public ProgressNode getProgressNode(){
//		return progressNode;
//	}
}
