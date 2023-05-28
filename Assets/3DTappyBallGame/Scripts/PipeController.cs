using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PipeController : MonoBehaviour
{
    Rigidbody RB;
    public float Speed, UpDownSpeed;

    private void Awake()
    {
        RB = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        MovementPipe();
        InvokeRepeating("SwitchUpDown", 0.1f, 1.0f);

    }

    // Update is called once per frame
    void Update()
    {
   
    }

    void MovementPipe() 
    {
        RB.velocity = new Vector3(Speed, UpDownSpeed);
        
    }

    void SwitchUpDown() 
    {
        UpDownSpeed = -UpDownSpeed;
        RB.velocity = new Vector3(Speed, UpDownSpeed);
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Remover") 
        {
            Destroy(gameObject);
        }
    }

}
