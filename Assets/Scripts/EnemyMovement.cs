using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PathFinder pathFinder = FindObjectOfType<PathFinder>(); 
        var path = pathFinder.GetPath();
        StartCoroutine(followPath(path));
    }

    private IEnumerator followPath(List<WayPoint> path) {
        foreach(WayPoint wayPoint in path) {
            transform.position = wayPoint.transform.position;
            yield return new WaitForSeconds(1f);
        }
    }
}
