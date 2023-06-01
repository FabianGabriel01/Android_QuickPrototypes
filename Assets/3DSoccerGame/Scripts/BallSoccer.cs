using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSoccer : MonoBehaviour
{
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = new Vector3(0f,-9.81f,0f);

        rb= GetComponent<Rigidbody>();

        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
