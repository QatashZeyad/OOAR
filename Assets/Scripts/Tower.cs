using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

	// Stats of tower
	private int fireRate;
	private int strength;
	private int fireCooldown;
	private int range;

    // The level
    private Level level;

	// Cost of towers upgrades and the stats
	public int[] upgradeCosts;
	public Vector3[] upgradeStats;
	private int upgradeLevel;

    // The meshes of the tower's upgrades
    public Mesh upgrade1Mesh;
    public Mesh upgrade2Mesh;

    // The prefabs of the tower's projectile
    public GameObject projectile;

	// Property of current towers cost
	public int CurrentCost
	{
		get { return upgradeCosts[upgradeLevel]; }
	}

	// Use this for initialization
	void Start () {

        // Initialize variables
        upgradeLevel = 0;
        fireRate = (int)upgradeStats[upgradeLevel].x;
        strength = (int)upgradeStats[upgradeLevel].y;
        range = (int)upgradeStats[upgradeLevel].z;

    }

	// Update is called once per frame
	void Update () {

	}

	// Shoots a bullet from the tower
	protected virtual void Shoot(GameObject target)
    {

    }

	// Upgrade the current tower
	protected void Upgrade()
	{
		upgradeLevel++;
		fireRate = (int)upgradeStats[upgradeLevel].x;
		strength = (int)upgradeStats[upgradeLevel].y;
		range = (int)upgradeStats[upgradeLevel].z;
	}
}