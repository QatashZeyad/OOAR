using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerSpawnButton : MonoBehaviour {

    // The tower to spawn
    //public GameObject tower;
	public GameObject menuPanel;

	private bool menuOut = false;

    // Adds the listener for the button
    void Start()
    {
		print ("Hi");
		this.GetComponent<Button>().onClick.AddListener(LoadNewPanel);
    }
    
    // Creates a single target tower on click
    /*void CreateSingleTargetTower()
    {
		GameObject tile = Level.GetLookAt ();
		GameObject spawned = Instantiate(tower, tile.transform.position, tile.transform.rotation);
        spawned.transform.SetParent(GameObject.FindGameObjectWithTag("Map").transform);
    }*/

	void LoadNewPanel()
	{
		print ("Hi2");
		if (menuOut)
			menuPanel.transform.position += new Vector3(240, 0, 0);
		else
			menuPanel.transform.position += new Vector3(-240, 0, 0);
		menuOut = !menuOut;
	}
}
