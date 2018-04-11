using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBot : MonoBehaviour {

    // Stats of AI bot
    public int health;
    public int speed;
    public int strength;
    public int killValue;


    // Margin of error for positions
    private float marginError = 0.00000000001f;

    // Variable used for path finding
    private GameObject nextPath;
    
	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update () {

        // Make sure the bot has a path
        if (nextPath == null)
        {
            Level level = GameObject.FindGameObjectWithTag("Map").GetComponent<Level>();
            nextPath = level.GetNextPath(level.GetStartPath().transform.position);
            RotateForward();
        }
        print((this.transform.position - nextPath.transform.position).sqrMagnitude);
        print(marginError);
        print((this.transform.position - nextPath.transform.position).sqrMagnitude <= marginError);

        // Move and rotate the bot
        if ((this.transform.position - nextPath.transform.position).sqrMagnitude <= marginError)
        {
            Level level = GameObject.FindGameObjectWithTag("Map").GetComponent<Level>();
            nextPath = level.GetNextPath(nextPath.transform.position);
            RotateForward();
        }
        else
        {
            Vector3 newPostion = Vector3.MoveTowards(GetComponent<Rigidbody>().position, nextPath.transform.position, Time.deltaTime / speed);
            GetComponent<Rigidbody>().MovePosition(newPostion);
        }
	}

    // Rotate Forward
    private void RotateForward()
    {
        double forwardAngle = Mathf.Atan2(nextPath.transform.position.z - transform.position.z, nextPath.transform.position.x - transform.position.x) * 180.0 / Mathf.PI;
        gameObject.transform.localRotation = Quaternion.Euler(10, (float)forwardAngle, 0);
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
