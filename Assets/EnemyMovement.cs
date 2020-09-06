using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<Block> path;
    Vector3 blockOffset = new Vector3(0, 4.5f, 2.5f);
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Waypoints());
    }

    IEnumerator Waypoints()
    {
        foreach (Block waypoint in path)
        {
            transform.position = waypoint.transform.position + blockOffset;
            yield return new WaitForSeconds(1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
