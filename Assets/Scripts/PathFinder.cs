using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    Dictionary<Vector2Int, WayPoint> grid = new Dictionary<Vector2Int, WayPoint>();
    Queue<WayPoint> queue = new Queue<WayPoint>();
    List<WayPoint> path = new List<WayPoint>();
    [SerializeField] WayPoint startWayPoint, endWayPoint;
    bool isRunning =true;
    WayPoint searchCenter;

    Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.left,
        Vector2Int.down
    };

    void Start() { 
    }

    public List<WayPoint> GetPath() {
        LoadBlocks();
        ColorStartAndEndWayPoint();
        BreadthFirstSearch();
        CreatePath();

        return path;
    }

    private void CreatePath() {
        path.Add(endWayPoint);
        var previous = endWayPoint.exploredFrom;

        while (previous != startWayPoint) {
             path.Add(previous);
             previous = previous.exploredFrom;
        }
        path.Add(startWayPoint);
        path.Reverse();
    }

    private void BreadthFirstSearch() {
        queue.Enqueue(startWayPoint);

        while(queue.Count > 0 && isRunning) {
            searchCenter = queue.Dequeue();
            HaultIfEndFound();
            ExploreNeighbours();
            searchCenter.isExplored = true;
        }
    }

    private void HaultIfEndFound() {
        if (searchCenter == endWayPoint) {
            isRunning = false;
        }
    }

    private void ColorStartAndEndWayPoint() {
        startWayPoint.SetTopColor(Color.green);
        endWayPoint.SetTopColor(Color.red);
    }

    private void ExploreNeighbours() {
        if (!isRunning) { return; }

        foreach (Vector2Int direction in directions) {
            var neighbourCoordinates = searchCenter.GetGridPosition() + direction;
            QueueNewNeighbours(neighbourCoordinates);
        }
    }

    private void QueueNewNeighbours(Vector2Int neighbourCoordinates) {
        if (grid.ContainsKey(neighbourCoordinates)) {
            var wayPoint = grid[neighbourCoordinates];
            if (!wayPoint.isExplored && !queue.Contains(wayPoint)) {
                wayPoint.exploredFrom = searchCenter;
                queue.Enqueue(wayPoint);
            }
        }
    }

    private void LoadBlocks() {
         var wayPoints = FindObjectsOfType<WayPoint>(); 
         foreach (WayPoint wayPoint in wayPoints) {
             if (!grid.ContainsKey(wayPoint.GetGridPosition())) {
                 grid.Add(wayPoint.GetGridPosition(), wayPoint);
             } else {
                 Debug.LogError("Skipping overlapping block " + wayPoint );
             }
         }
    }
}
