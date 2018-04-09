using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tower : MonoBehaviour {

    // Stats of tower
    private int fireRate;
    private int strength;
    private int fireCooldown;

    // Cost of towers upgrades and the stats
    private int[] upgradeCosts;
    private Vector3[] upgradeStats;
    private int upgradeLevel;

    // Property of current towers cost
    public int CurrentCost
    {
        get { return upgradeCosts[upgradeLevel]; }
    }

    // Create a tower
    public Tower(int[] upgradeCosts, Vector3[] upgradeStats)
    {
        upgradeLevel = 0;
        this.upgradeCosts = upgradeCosts;
        this.upgradeStats = upgradeStats;
    }
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Shoots a bullet from the tower
    protected abstract void Shoot();

    // Upgrade the current tower
    protected void Upgrade()
    {

    }
}
