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
    private GameObject nextPath;
    
	// Use this for initialization
	void Start ()
    {
        Level level = GameObject.FindGameObjectWithTag("Map").GetComponent<Level>();
        nextPath = level.GetNextPath(level.GetStartPath().transform.position);
        GoForward();
	}
	
	// Update is called once per frame
	void Update () {
        if (nextPath.transform.position.Equals(this.transform.position))
        {
            Level level = GameObject.FindGameObjectWithTag("Map").GetComponent<Level>();
            nextPath = level.GetNextPath(nextPath.transform.position);
            GoForward();
        }
	}

    // Rotate Forward
    private void GoForward()
    {
        double forwardAngle = Mathf.Atan2(nextPath.transform.position.z - transform.position.z, nextPath.transform.position.x - transform.position.x) * 180.0 / Mathf.PI;
        this.transform.localRotation = Quaternion.Euler(10, (float)forwardAngle, 0);
        this.GetComponent<Rigidbody>().velocity = Vector3.Normalize(this.transform.position - nextPath.transform.position)*speed;
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
