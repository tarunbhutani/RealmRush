using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(WayPoint))]
public class CubeEditor : MonoBehaviour {
    WayPoint wayPoint;
    
    private void Awake() {
        wayPoint = GetComponent<WayPoint>();
    }

    // Update is called once per frame
    void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }

    private void SnapToGrid() {
        var gridSize = wayPoint.GetGridSize();
        Vector2Int gridPos = wayPoint.GetGridPosition(); 
        transform.position = new Vector3(
            gridPos.x * gridSize, 
            0f, 
            gridPos.y * gridSize
        );
    }

    private void UpdateLabel() {
        var gridSize = wayPoint.GetGridSize();
        Vector2Int gridPos = wayPoint.GetGridPosition(); 

        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        var labelText = gridPos.x + ","+ gridPos.y;
        textMesh.text = labelText;
        gameObject.name = labelText;
    }
}
