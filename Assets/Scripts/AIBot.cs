using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIBot : MonoBehaviour {

    // Stats of AI bot
    private int health;
    private int speed;
    private int strength;

    // Variable used for path finding
    private Vector3 nextPoint;

    // Create a tower
    public AIBot(int health, int speed, int strength)
    {
        this.health = health;
        this.speed = speed;
        this.strength = strength;
    }
    
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
