using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour {
	public GameObject trailObject;

	// Use this for initialization
	void Start () {
		trailObject.SetActive(false);
		
	}
	
	public void ActivateTrail()
    {
		trailObject.SetActive(true);
    }
}
