using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public player player;
    public float resetTimer = 10f;

	

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(player.holdingBall == false)
        {
            resetTimer -= Time.deltaTime;
            if(resetTimer <= 0)
            {
                SceneManager.LoadScene("game");
            }
        }
        else{
            resetTimer=10f;
        }

    }
}
