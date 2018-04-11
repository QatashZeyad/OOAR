using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LookingAt : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    int counter = 0;
	// Update is called once per frame
	void Update () {
        if (GetLookAt() != null)
            GetComponent<Text>().text = "Looking at: "+GetLookAt().name+":"+counter++;
        else
            GetComponent<Text>().text = "Looking at: "+ counter++;
    }

    // Get what the camera is looking at
    public GameObject GetLookAt()
    {
        RaycastHit hit;
        Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit);
        if (hit.collider != null)
            return hit.collider.gameObject;
        else
            return null;
    }
}
