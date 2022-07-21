using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player: MonoBehaviour
{
    public ball ball;
    public GameObject playerCamera;

    public float ballDistance = 2f;
    public float distanceBetweenBall = 2f;
    
    public float ballThrowingForce = 5f;
 
	public bool holdingBall = false;

    // Use this for initialization
    void Start () {
		ball.GetComponent<Rigidbody>().useGravity = true;
	}
	
	// Update is called once per frame
	void Update ()
    {   distanceBetweenBall= Vector3.Distance(playerCamera.transform.position,ball.transform.position);
        
        if (holdingBall)
        {
            ball.transform.position = playerCamera.transform.position + playerCamera.transform.forward * ballDistance;

            if (Input.GetMouseButtonDown(0))
            {
                holdingBall = false;
                // ball.ActivateTrail();
                ball.GetComponent<Rigidbody>().useGravity = true;
                ball.GetComponent<Rigidbody>().AddForce(playerCamera.transform.forward * ballThrowingForce);
            }
        }else {
            if(Input.GetMouseButtonDown(0) && distanceBetweenBall<4f){
                holdingBall= true;
                ball.GetComponent<Rigidbody>().useGravity= false;
                ball.transform.position = playerCamera.transform.position + playerCamera.transform.forward * ballDistance;
            }
        }


    }
}
