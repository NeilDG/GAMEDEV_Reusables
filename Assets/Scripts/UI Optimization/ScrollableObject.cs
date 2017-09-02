using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollableObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	/// <summary>
	/// Moves this oject to its last index
	/// </summary>
	public void MoveToLast() {
		this.transform.SetSiblingIndex (this.transform.parent.childCount - 1);
	}


	/// <summary>
	/// Moves this object to its first index
	/// </summary>
	public void MoveToFirst() {
		this.transform.SetSiblingIndex (0);
	}

}
