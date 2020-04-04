using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public bool minimumLimit = false;
    public int seed;
    public float maxRadius = 1f,minRadius = 0.5f;
    public float regionSize = 10f;
    public int iterationsPerCell = 10;

    private List<RandomSampling.Point> points;

    void OnValidate()
    {
        if (minimumLimit)
            points = RandomSampling.GeneratePoints(seed, maxRadius, minRadius, regionSize, iterationsPerCell);
        else
            points = RandomSampling.GeneratePoints(seed, maxRadius, regionSize, iterationsPerCell);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(new Vector3(regionSize/2,regionSize/2,0.5f),new Vector3(regionSize,regionSize,1f));
        if (points != null)
        {
            foreach (RandomSampling.Point point in points)
            {
                Gizmos.color = Color.Lerp(Color.yellow, Color.green, (point.radius-minRadius)/(maxRadius-minRadius));
                Gizmos.DrawSphere(new Vector3(point.x,point.y,0.5f), point.radius);
            }
        }
    }
}
