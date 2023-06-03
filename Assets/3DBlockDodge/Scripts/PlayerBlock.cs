using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBlock : MonoBehaviour
{
    Rigidbody rb;
    public float Speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.GetMouseButton(0))
        {
            //GetTouch Position
            //Vector3 TouchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition); 2D Spaces
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 TouchPos = ray.origin;
            if (TouchPos.x < 0) 
            {
                rb.AddForce(Vector3.left * Speed);
            }
            else 
            {
                rb.AddForce(Vector3.right * Speed);
            }
        }
        else 
        {
            rb.velocity = Vector3.zero;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle") 
        {
            SceneManager.LoadScene("3DBlockDodge");
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Obstacle")
    //    {
    //        SceneManager.LoadScene("3DBlockDodge");
    //    }
    //}
}
