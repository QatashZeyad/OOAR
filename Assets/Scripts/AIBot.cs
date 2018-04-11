using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBot : MonoBehaviour {

    // Stats of AI bot
    public int health;
    public int speed;
    public int strength;

    // Variable used for path finding
    private Vector3 nextPoint;
    
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Hurt the AI bot by the given amount
    public void Hurt(int damage)
    {

    }
}
