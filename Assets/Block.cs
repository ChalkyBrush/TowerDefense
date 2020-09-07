using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public bool isExplored = false;
    public Block exploredFrom;

    Vector3 towerPlacementOffset = new Vector3(0f, 2.5f, 2f);
    const int gridSize = 6;
    Vector2Int gridPos;

    public bool isPlaceable = true;
    private bool isMousedOver = true;


    private Color mouseOverColor = new Color(0.5f, 0.5f, 0.5f, 1f);
    private Color baseColor;

    [SerializeField] GameObject towerPrefab;
    private bool hasTower = false;

    private void Start()
    {
        MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        baseColor = topMeshRenderer.material.color;
    }
    private void Update()
    {
        
    }
    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize),
            Mathf.RoundToInt(transform.position.z / gridSize)
        );
    }

    public void SetTopColor(Color color)
    {
        MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        topMeshRenderer.material.color = color;
        baseColor = topMeshRenderer.material.color;
    }

    public void SetHighlightColor(Color color)
    {
        MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        topMeshRenderer.material.color = color;
    }

    private void OnMouseOver()
    {
        //SetHighlightColor(mouseOverColor);
        if (Input.GetMouseButtonDown(0))
        {
            if (isPlaceable)
            {
                PlaceTower();
            }
        }
    }

    private void PlaceTower()
    {
        if (!hasTower)
        {
            Instantiate(towerPrefab, transform.position + towerPlacementOffset, Quaternion.identity);
            hasTower = true;
        }
    }

    private void OnMouseExit()
    {
        //SetHighlightColor(baseColor);
    }
}
