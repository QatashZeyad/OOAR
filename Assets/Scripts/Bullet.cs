using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    // strength of the Bullet 

    private int strength;


    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    // bullets come out from the tower toward the enemy and destroyed them.
    void OnCollisionEnter(Collision collision)
    {
        // TODO: CHECK FOR AI AND HANDLE 
        GameObject objectHit = collision.collider.gameObject;
        if ( objectHit.GetComponent<AIBot>()!= null)
            OnHitAI(objectHit);
    }

    // when bullet hits AI

    protected virtual void OnHitAI(GameObject aIHit)
    {

        aIHit.GetComponent<AIBot> ().Hurt(strength);
        Destroy(gameObject);

    }
}
