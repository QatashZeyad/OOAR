using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTargetTower : Tower
{
	// Stats of tower
	private int fireRate;
	private int strength;
	private int fireCooldown;
	private int range;

	// Cost of towers upgrades and the stats
	private int[] upgradeCosts;
	private Vector3[] upgradeStats;
	private int upgradeLevel;

	// Tower Stats
	private static int[] UPGRADE_COSTS = new int[] { };
	private static Vector3[] UPGRADE_STATS = new Vector3[] { };

	// Create a Single Target Tower
	public SingleTargetTower() : base(UPGRADE_COSTS, UPGRADE_STATS)
	{

	}

	// Hurts the neartest AI
	protected override void Shoot()
	{
		if (this.fireCooldown == 0)
		{
			double closestDistance = int.MaxValue;
			Actor closestEnemy = null;
			for (Actor n:Enemies)
			{
				double currentDistance = Math.Abs(Vector3.Distance(this.transform.position, n.transform.position));
				if (currentDistance < closestDistance)
				{
					closestEnemy = n;
					closestDistance = currentDistance;
				}
			}
			if (closestEnemy != null && closestDistance <= this.range)
			{
				Vector3 launchVector = this.transform.position - closestEnemy.transform.position;
				this.launchBullet(launchVector);

				this.fireCooldown = this.fireRate;
			}
		}
		else
		{
			this.fireCooldown--;
		}

	}

}