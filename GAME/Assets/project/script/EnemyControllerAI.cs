using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerAI : MonoBehaviour {
	public ball ball;
	public GameObject enemy;

	public float ballDistance = 2f;
	
	public float speed = 2f;

    public float distanceBetweenBall = 2f;
    
    public float ballThrowingForce = 5f;
 
	public bool holdingBall =false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		distanceBetweenBall= Vector3.Distance(enemy.transform.position,ball.transform.position);
        if(distanceBetweenBall>1f) holdingBall=false;
        if (holdingBall)
        {
            // ball.transform.position = playerCamera.transform.position + playerCamera.transform.forward * ballDistance;

            // if (Input.GetMouseButtonDown(0))
            // {
            //     holdingBall = false;
            //     // ball.ActivateTrail();
            //     ball.GetComponent<Rigidbody>().useGravity = true;
            //     // ball.GetComponent<Rigidbody>().AddForce(playerCamera.transform.forward * ballThrowingForce);
            // }
        }else {
            if(distanceBetweenBall<2f){
                holdingBall= true;
                ball.GetComponent<Rigidbody>().useGravity= true;
                ball.transform.position = enemy.transform.position;
            }else{
				Vector3 af= enemy.transform.position;
				Vector3 bf= ball.transform.position;
				enemy.transform.position= Vector3.Lerp(af,bf,speed);	
			}
        }
	}
}
