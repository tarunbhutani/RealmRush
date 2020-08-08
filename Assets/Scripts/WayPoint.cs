using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    public bool isExplored = false;
    public WayPoint exploredFrom;
    const int gridSize = 10;
    Vector2Int gridPosition;
    public bool isPlaceable = true;

    [SerializeField] Tower towerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver() {
        if (Input.GetMouseButtonDown(0) && isPlaceable) {
            Instantiate(towerPrefab, gameObject.transform.position, Quaternion.identity);
            print("Mouse is over "+ gameObject.name);
            isPlaceable = false;
        }
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
}
