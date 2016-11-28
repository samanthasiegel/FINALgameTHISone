using UnityEngine;
using System.Collections;

public class InteractionNode{
	public string Question;
	public string Answer;
	public InteractionNode[] Adj;
	public bool Asked;

	public InteractionNode(string Q, string A, int i){
		this.Question = Q;
		this.Answer = A;
		this.Adj = new InteractionNode[i];
		this.Asked = false;
	}

}

