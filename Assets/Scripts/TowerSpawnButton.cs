using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerSpawnButton : MonoBehaviour {

    // The tower to spawn
    public GameObject tower;

    // Adds the listener for the button
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(CreateSingleTargetTower);
    }
    
    // Creates a single target tower on click
    void CreateSingleTargetTower()
    {
        GameObject spawned = Instantiate(tower, Level.GetLookAt().transform.position, Quaternion.Euler(0, 0, 0));
        spawned.transform.SetParent(GameObject.FindGameObjectWithTag("Map").transform);
    }


}
