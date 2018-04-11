using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LookingAt : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Text>().text = "Looking at: "+GetLookAt().name;
    }

    // Get what the camera is looking at
    public GameObject GetLookAt()
    {
        RaycastHit hit;
        Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit);
        print(hit.collider.gameObject.name);
        return hit.collider.gameObject;
    }
}
