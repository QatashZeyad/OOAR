using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tower : MonoBehaviour {

	// Stats of tower
	private int fireRate;
	private int strength;
	private int fireCooldown;
	private int range;

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
		fireRate = (int)upgradeStats[upgradeLevel].x;
		strength = (int)upgradeStats[upgradeLevel].y;
		range = (int)upgradeStats[upgradeLevel].z;

		fireCooldown = fireRate; //INSERT VALUE HERE

	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		Shoot();
	}

	// Shoots a bullet from the tower
	protected abstract void Shoot();

	// Upgrade the current tower
	protected void Upgrade()
	{
		upgradeLevel++;
		fireRate = (int)upgradeStats[upgradeLevel].x;
		strength = (int)upgradeStats[upgradeLevel].y;
		range = (int)upgradeStats[upgradeLevel].z;
	}
}