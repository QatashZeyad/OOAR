using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOETower : Tower
{
    // Tower Stats
    private static int[] UPGRADE_COSTS = new int[] { };
    private static Vector3[] UPGRADE_STATS = new Vector3[] { };

    // Create a AOE Tower
    public AOETower() : base(UPGRADE_COSTS, UPGRADE_STATS)
    {

    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Hurts the neartest AI
    protected override void Shoot()
    {

    }

}
