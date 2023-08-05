using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAJ : MonoBehaviour
{
    Rigidbody rb;
    public float Speed, JumpForce;
    Animator Anims;
    public bool CanJump = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0f, -9.81f,0f);
        Anims = GetComponent<Animator>();

        rb.velocity = Vector3.forward * Speed;

    }

    // Update is called once per frame
    void Update()
    {
        bool HIT = Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 0.15f);
        if (HIT)
        {
            CanJump = true;
        }
        else 
        {
            CanJump = false;
        }

        if (HIT) 
        {
            hit.collider.GetComponent<Plane>().DESTROYPLANES();
        }



        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) 
        {
            if (CanJump) 
            {
                Anims.SetTrigger("OnJump");
                rb.AddForce(Vector3.up*JumpForce, ForceMode.Impulse);
            }

        }
        
    }
}
