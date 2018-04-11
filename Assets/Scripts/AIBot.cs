using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBot : MonoBehaviour {

    // Stats of AI bot
    public int health;
    public int speed;
    public int strength;
    public int killValue;

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
        Level level = GameObject.FindGameObjectWithTag("Map").GetComponent<Level>();
         if ( health <= 0)
         { 
            level.Money += killValue;
            Destroy(gameObject);
         }
    }
}
