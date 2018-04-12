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
        if (Level.GetLookAt() != null)
            GetComponent<Text>().text = "Looking at: "+Level.GetLookAt().name+":"+counter++;
        else
            GetComponent<Text>().text = "Looking at: "+ counter++;
    }
}
