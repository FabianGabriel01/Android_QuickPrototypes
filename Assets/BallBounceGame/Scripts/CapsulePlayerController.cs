using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsulePlayerController : MonoBehaviour
{
    Rigidbody RB;
    public float Speed;
    public Vector3 screen, worldPos;


    private void Awake()
    {
        RB = GetComponent<Rigidbody>(); 
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    void Movement() 
    {
        //Vector3 clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //float XPositive = clickPos.x;

        screen = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(screen);
        float Xpos = ray.origin.x; 
        //Debug.Log(ray);


        if (Input.GetMouseButton(0)) 
        {
            

            if (Xpos > 0)
            {
                RB.velocity = -Vector3.left * Speed;
            }
            else
            {
                RB.velocity = Vector3.left * Speed;
            }
        }
        else 
        {
            RB.velocity = Vector3.zero;
        }


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            RB.velocity = Vector3.left * Speed;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            RB.velocity = -Vector3.left * Speed;
        }
        else 
        {
            RB.velocity = Vector3.zero;
        }

    }

}
