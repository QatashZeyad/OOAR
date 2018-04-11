using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeTower : Tower {

	// Hurts the neartest AI
	protected override void Shoot(GameObject target)
	{/*
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
		}*/
	}

}