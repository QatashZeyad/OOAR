using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeTower : Tower {

	// Tower Stats
	private static int[] UPGRADE_COSTS = new int[] { };
	private static Vector3[] UPGRADE_STATS = new Vector3[] { };

	// Create a Melee Tower
	public MeleeTower() : base(UPGRADE_COSTS, UPGRADE_STATS)
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
				this.HIT(closestEnemy);

				this.fireCooldown = this.fireRate;
			}
		}
		else
		{
			this.fireCooldown--;
		}
	}

}