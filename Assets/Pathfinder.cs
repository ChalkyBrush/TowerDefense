using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    // Start is called before the first frame update
    Dictionary<Vector2Int, Block> grid = new Dictionary<Vector2Int, Block>();

    [SerializeField] Block startPoint, endPoint;

    Queue<Block> queue = new Queue<Block>;
    bool isRunning = true;

    Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    void Start()
    {
        LoadBlocks();
        ColorStartAndEnd();
        FindPath();
    }

    private void FindPath()
    {
        queue.Enqueue(startPoint);

        while (queue.Count > 0)
        {
            var searchCenter = queue.Dequeue();
            HaltIfEndFound(searchCenter);
        }
    }

    private void HaltIfEndFound(Block searchCenter)
    {
        if (searchCenter == endPoint)
        {
            print("Found End");
            isRunning = false;
        }
    }

    private void ExploreNeighbours()
    {
        foreach (Vector2Int direction in directions)
        {
            Vector2Int explorationCoordinates = startPoint.GetGridPos() + direction;
            if (grid.ContainsKey(explorationCoordinates))
            {
                grid[explorationCoordinates].SetTopColor(Color.black);
            }
        }
    }

    private void ColorStartAndEnd()
    {
        startPoint.SetTopColor(Color.green);
        endPoint.SetTopColor(Color.red);
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Block>();
        foreach (Block waypoint in waypoints)
        {
            var gridPos = waypoint.GetGridPos();
            bool isOverlapping = grid.ContainsKey(gridPos);
            if (isOverlapping)
            {
                Debug.LogWarning("Overlapping Block: " + waypoint);
            }
            else
            {
                grid.Add(gridPos, waypoint);
            }
        }
        //print("Loaded " + grid.Count + " blocks");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
