using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    public bool isExplored = false;
    public WayPoint exploredFrom;
    const int gridSize = 10;
    Vector2Int gridPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     public Vector2Int GetGridPosition() {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize), 
            Mathf.RoundToInt(transform.position.z / gridSize)
        );
    }

    public int GetGridSize() {
        return gridSize;
    }

    public void SetTopColor(Color color) {
        var topMeshRender = transform.Find("Top").GetComponent<MeshRenderer>();
        topMeshRender.material.color = color;
    }
}
