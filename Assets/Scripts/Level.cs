using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

    // The bots of the level
    public GameObject basicBot;

    // The players money
    private int money;

    // The Health of the colony
    private int colonyHealth;

    // The AIBots on the current field
    private List<GameObject> bots;

    // The Points of the path of the level
    private GameObject[] pathPoints;

    // Property Money
    public int Money
    {
        get { return money; }
        set { money = value; }
    }

	// Use this for initialization
	void Start () {

        // Get all the path points
        GameObject[] paths = GameObject.FindGameObjectsWithTag("Path");
        pathPoints = new GameObject[paths.Length];
        foreach (GameObject path in paths)
            pathPoints[path.GetComponent<Path>().pathNumber] = path;
        
        // Initialize variables
        bots = new List<GameObject>();
	}


    private int counter = 0;
	// Update is called once per frame
	void Update () {
        if (++counter % 120 == 0 && counter < 200)
        {
            GameObject bot = Instantiate(basicBot, pathPoints[0].transform.position, pathPoints[0].transform.rotation);
            bot.transform.SetParent(GameObject.FindGameObjectWithTag("Map").transform);
            bot.transform.Rotate(180, 0, 0);
        }
    }

    // Gets the starting point
    public GameObject GetStartPath()
    {
        return pathPoints[0];
    }

    // Gets the next point on the path given the previous one
    public GameObject GetNextPath(Vector3 prePoint)
    {
        for (int i = 0; i < pathPoints.Length - 1; i++)
            if (pathPoints[i].transform.position.x == prePoint.x && pathPoints[i].transform.position.y == prePoint.y && prePoint.z == pathPoints[i].transform.position.z)
                return pathPoints[i + 1];
        return pathPoints[pathPoints.Length - 1];
    }

    // Gets the closest AI bot to the given point in the given range (null if none)
    public GameObject GetClosestAI(Vector3 center, float radius)
    {
        float closestDistance = -1;
        GameObject closestBot = null;
        foreach (GameObject bot in bots)
        {
            float currentDistance = Mathf.Abs(Vector3.Distance(bot.transform.position, center));
            if (closestBot == null || currentDistance < closestDistance)
            {
                closestBot = bot;
                closestDistance = currentDistance;
            }
        }
        if (closestDistance <= radius)
            return closestBot;
        else
            return null;
        
    }


    // Gets the AI with in the given circle
    public GameObject[] GetAllAIWithin(Vector3 center, float radius)
    {
        List<GameObject> foundAI = new List<GameObject>();
        foreach (GameObject bot in bots)
        {
            float distance = Mathf.Abs(Vector3.Distance(bot.transform.position, center));
            if (distance <= radius)
                foundAI.Add(bot);
        }
        return foundAI.ToArray();
    }

    // Hurts the colony by the given damage
    public void HurtColony(int damage)
    {
        if (colonyHealth > 0)
            colonyHealth--;
        else
        {
            // TODO: GAME OVER
        }
    }
}
