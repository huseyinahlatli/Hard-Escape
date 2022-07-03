using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleControl : MonoBehaviour
{
    public float turtleSpeed;
    public Transform[] movePoints;
    private int randomPosition;

    void Start()
    {
        randomPosition = Random.Range(0, movePoints.Length);    
    }

    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            movePoints[randomPosition].position,
            turtleSpeed * Time.deltaTime
        );

        if(Vector3.Distance(transform.position, movePoints[randomPosition].position) < 0.2f)
        {
            randomPosition = Random.Range(0, movePoints.Length);
        }
    }
}
