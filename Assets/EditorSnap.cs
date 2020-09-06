using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Block))]
public class EditorSnap : MonoBehaviour
{
    Block waypoint;

    private void Awake()
    {
        waypoint = GetComponent<Block>();
    }

    // Update is called once per frame
    void Update()
    {
        GridSnap();
        UpdateLabel();
    }

    private void GridSnap()
    {
        int gridSize = waypoint.GetGridSize();
        transform.position = new Vector3(waypoint.GetGridPos().x * gridSize, 0f, waypoint.GetGridPos().y * gridSize);
    }

    private void UpdateLabel()
    {
        TextMesh coordinatesTextMesh = GetComponentInChildren<TextMesh>();
        int gridSize = waypoint.GetGridSize();
        Vector2Int gridPos = waypoint.GetGridPos();
        string labelText = gridPos.x + ", " + gridPos.y;
        gameObject.name = labelText;
        coordinatesTextMesh.text = labelText;
        
    }
}
