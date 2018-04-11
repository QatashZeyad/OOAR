using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

    // The Health of the colony
    private int colonyHealth;

    // The AIBots on the current field
    private AIBot[] bots;

    // The Points of the path of the level
    private Vector3[] pathPoints;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Gets the next point on the path given the previous one
    public Vector3 GetNextPoint(Vector3 prePoint)
    {
        return new Vector3(0, 0, 0);
    }

    // Gets the closest AI bot to the given point in the given range
    public AIBot GetClosestAI(Vector3 center, Vector3 radius)
    {
        return null;
    }

    // Hurts the colony by the given damage
    public void HurtColony(int damage)
    {
        
    }
}
