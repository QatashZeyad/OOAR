using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    // strength of the Bullet 

    private Vector3 strength;


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

    }

    // when bullet hits AI

    protected virtual void OnHitAI()
    {
       
    }
}
