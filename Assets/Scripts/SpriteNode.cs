using UnityEngine;
using System.Collections;
using System;

public class SpriteNode: IEquatable<string>{

	public string tag;
	public bool interactedWith;

	public SpriteNode(string tag){
		this.tag = tag;
		this.interactedWith = false;
	}

	public bool Equals(string other){
		Debug.Log (other);
		return other.Equals (this.tag);
	}

}
