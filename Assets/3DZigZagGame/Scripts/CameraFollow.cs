using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject Ball;
    Vector3 Offset;
    public float LerpRate;
    public bool GameOver;

    // Start is called before the first frame update
    void Start()
    {
        Offset = Ball.transform.position - transform.position;
        GameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameOver) 
        {
            Follow();
        }
    }

    void Follow() 
    {
        Vector3 Position = transform.position;
        Vector3 TargetPosition = Ball.transform.position - Offset;
        Position = Vector3.Lerp(Position, TargetPosition, LerpRate * Time.deltaTime);
        transform.position= Position;
    }
}
