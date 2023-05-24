using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody RB;
    public float JumpForce;
    public bool CanJump;
    Animator AnimPlayer;

    

    private void Awake()
    {
        RB = GetComponent<Rigidbody>();
        AnimPlayer = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!CanJump) return;

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) 
        {
            //JUMPING
            RB.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            AnimPlayer.SetBool("Jump", true);

        }
        else 
        {
            AnimPlayer.SetBool("Jump", false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ground") 
        {
            CanJump = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Ground") 
        {
            CanJump = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            SceneManager.LoadScene("3DRunnerGameScene");
        }
    }
}
