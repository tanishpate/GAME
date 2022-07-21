using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerAI : MonoBehaviour {
	public ball ball;
	public GameObject enemy;
	public GameObject throwPosition;
	public GameObject floor;
	public GameObject enemyTarget;

	public float throwTimer= 1.5f;

	public float ballDistance = 2f;
	
	public float speed;
	public float halfSpeed;
    public float distanceBetweenBall = 2f;
	
    public float distanceBetweenThrowPostion = 2f;
    
    public float ballThrowingForce = 5f;
 
	public bool holdingBall =false;
	public bool thrown =false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(thrown)
			throwTimer-=Time.deltaTime;
		if(throwTimer<0)
			thrown=false;
		halfSpeed= speed/2;
		Vector3 ballY= ball.transform.position;
		distanceBetweenBall= Vector3.Distance(enemy.transform.position,ball.transform.position);
        distanceBetweenThrowPostion= Vector3.Distance(enemy.transform.position,throwPosition.transform.position);
        
		if(distanceBetweenBall>3f) holdingBall=false;
        if (holdingBall)
        {			
                ball.GetComponent<Rigidbody>().useGravity= false;
				Vector3 ep= enemy.transform.position;
				Vector3 fp= throwPosition.transform.position;
				enemy.transform.position= Vector3.Lerp(ep,fp,halfSpeed);
				ball.transform.position= enemy.transform.position;	
				if(distanceBetweenThrowPostion<6f && !thrown){
					holdingBall = false;
					ball.GetComponent<Rigidbody>().useGravity = true;
					ball.GetComponent<Rigidbody>().AddForce((enemyTarget.transform.position-ball.transform.position)*ballThrowingForce);
					thrown=true;
					throwTimer=3f;
				}
        }else {
            if(distanceBetweenBall<5f && ballY.y<3f){
                holdingBall= true;
                ball.GetComponent<Rigidbody>().useGravity= true;
                ball.transform.position = enemy.transform.position;
            }else if(ballY.y<4f){
				Vector3 af= enemy.transform.position;
				Vector3 bf= ball.transform.position;
				enemy.transform.position= Vector3.Lerp(af,bf,speed);
			}
        }
	}
}
