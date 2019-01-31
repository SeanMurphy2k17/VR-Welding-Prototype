using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class MovingTest : MonoBehaviour
{
    [SerializeField]
    private float Speed;
    [SerializeField]
    private GameObject[] Path;
    private int PathPoint;

    // Update is called once per frame
    void Update()
    {
        if (Application.isPlaying)
        {
            
            if (Vector3.Distance(transform.position, Path[PathPoint].transform.position) < 0.02f)
            {
                if (PathPoint < Path.Length - 1)
                {
                    PathPoint++;
                }
                else
                {
                    PathPoint = 0;
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, Path[PathPoint].transform.position, Time.deltaTime * Speed);
            }
        }
        if (Path != null && Path.Length != 0)
        {
            for (int i = 0; i < Path.Length; i++)
            {
                if (i == Path.Length - 1)
                {
                    Debug.DrawLine(Path[i].transform.position, Path[0].transform.position, Color.green);
                }
                else
                {
                    Debug.DrawLine(Path[i].transform.position, Path[i + 1].transform.position, Color.green);
                }
                
            }
        }
    }
}
