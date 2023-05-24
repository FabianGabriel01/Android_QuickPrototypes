using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [Header("Settings")]
    Rigidbody RB;
    [SerializeField] private float Speed;

    enum ChangeDirection 
    {
        OnX,
        OnZ
    }
    ChangeDirection changeDirection = ChangeDirection.OnX;

    private void Awake()
    {
        RB = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
        
        RB.velocity = new Vector3(Speed, 0,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) 
        {
            if (changeDirection == ChangeDirection.OnX)
            {
                changeDirection = ChangeDirection.OnZ;
            }
            else 
            {
                changeDirection = ChangeDirection.OnX;
            }

            SwitchDirection();
        }
    }

    void SwitchDirection() 
    {
        switch (changeDirection) 
        {
            case ChangeDirection.OnX:
                RB.velocity = new Vector3(Speed, 0, 0);
                break;

            case ChangeDirection.OnZ:
                RB.velocity = new Vector3(0, 0, Speed);
                break;

            default:
            break;
        }

        //if (RB.velocity.z > 0)
        //{
        //    RB.velocity = new Vector3(Speed, 0, 0);
        //}
        //else if (RB.velocity.x > 0) 
        //{
        //    RB.velocity = new Vector3(0, 0, Speed);
        //}
    }
}
