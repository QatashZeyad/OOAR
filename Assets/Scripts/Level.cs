using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

    // The bots of the level
    public GameObject basicBot;

    // The coords of the path of the level
    public Vector3[] pathCoords;

    // The objects of the paths and other tiles
    public GameObject pathObject;
    public GameObject tileObject;

    // The size of the tiles and the map
    public int mapWidth;
    public int mapHeight;
    public float tileSize;
    public Vector3 mapOffset;

    // The players money
    private int money;

    // The Health of the colony
    private int colonyHealth;

    // The AIBots on the current field
    private List<GameObject> bots;

    // The Points of the path of the level
    private List<GameObject> pathPoints;

    // Property Money
    public int Money
    {
        get { return money; }
        set { money = value; }
    }

	// Use this for initialization
	void Start () {

        // Create a parent of all the paths at the offset
        GameObject pathParent = new GameObject("Path Parent");
        pathParent.transform.SetParent(GameObject.FindGameObjectWithTag("Map").transform);
		pathParent.transform.position = mapOffset;

        // Get all the path points
        List<Vector2> points = new List<Vector2>();
        pathPoints = new List<GameObject>();
        GameObject path;
        for (int i=0;i<pathCoords.Length-1;i++)
        {
            // Find the width height and length of the current segment
            float width = pathCoords[i+1].x - pathCoords[i].x,
                    height = pathCoords[i+1].z - pathCoords[i].z,
                    length = Mathf.Sqrt(width*width+height*height);

            // Loop until reach the end of the segment getting all the points
            float curX = pathCoords[i].x,
                    curZ = pathCoords[i].z;
            for (int j = 0; j < length / tileSize; j++)
            {
                points.Add(new Vector2(curX, curZ));
                path = Instantiate(pathObject, new Vector3(curX, 0, curZ), Quaternion.Euler(0, 0, 0));
                pathPoints.Add(path);
                path.transform.SetParent(pathParent.transform);
                curX += tileSize * width / length;
                curZ += tileSize * height / length;
            }
        }
        // Do the final Point
        points.Add(new Vector2(pathCoords[pathCoords.Length - 1].x, pathCoords[pathCoords.Length - 1].z));
        path = Instantiate(pathObject, new Vector3(pathCoords[pathCoords.Length - 1].x, 0, pathCoords[pathCoords.Length - 1].z), Quaternion.Euler(0, 0, 0));
        pathPoints.Add(path);
        path.transform.SetParent(pathParent.transform);

        // Create all the tiles
        for (int x = 0; x < mapWidth; x += (int)tileSize)
        {
            for (int z = 0; z < mapHeight; z += (int)tileSize)
            {
                // Check if the current point is a path
                bool isPath = false;
                for (int i = 0; i < points.Count && !isPath; i++)
                    if (points[i] == new Vector2(x, z))
                        isPath = true;

                // Place the apporiate tile
                if (!isPath)
                {
                    GameObject tile = Instantiate(tileObject, new Vector3(x, 0, z), Quaternion.Euler(0, 0, 0));
                    tile.transform.SetParent(pathParent.transform);
                }

            }
        }
        
        // Initialize variables
        bots = new List<GameObject>();
	}


    private int counter = 0;
	// Update is called once per frame
	void Update () {
        if (++counter % 120 == 0)
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
        for (int i = 0; i < pathPoints.Count - 1; i++)
            if (pathPoints[i].transform.position.x == prePoint.x && pathPoints[i].transform.position.y == prePoint.y && prePoint.z == pathPoints[i].transform.position.z)
                return pathPoints[i + 1];
        return null;
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
