using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreArea : MonoBehaviour {

	public GameObject effectObject;

	// Use this for initialization
	void Start () {
		effectObject.SetActive(false);		
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider otherCollider) {
		if(otherCollider.GetComponent<ball> () != null)
        {
			effectObject.SetActive(true);
        }

		// effectObject.SetActive(false);	
	}
}
