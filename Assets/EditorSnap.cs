using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EditorSnap : MonoBehaviour
{
    [Range(1f, 20f)][SerializeField] float gridSize = 6f;

    TextMesh coordinatesTextMesh;

    
    // Start is called before the first frame update
    void Start()
    {
        coordinatesTextMesh = GetComponentInChildren<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        
        

        Vector3 snapPos;
        snapPos.x = Mathf.RoundToInt(Mathf.RoundToInt(transform.position.x / gridSize) * gridSize);
        snapPos.y = 0;
        snapPos.z = Mathf.RoundToInt(Mathf.RoundToInt(transform.position.z / gridSize) * gridSize);

        coordinatesTextMesh.text = snapPos.x / gridSize + ", " + snapPos.z / gridSize;
        transform.position = snapPos;
    }
}
