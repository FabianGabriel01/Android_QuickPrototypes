using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class BallController : MonoBehaviour
{
    [Header("Settings")]
    Rigidbody RB;
    [SerializeField] private float Speed;
    bool Started;
    bool GameOver;
    public GameObject DiamondParticle;

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
        Started = false;
        GameOver = false;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Started) 
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) 
            {
                RB.velocity = new Vector3(Speed, 0, 0);
                Started = true;

                GameMAangerZigZagGame.Instance.StartGame();
            }
        }


        if (!Physics.Raycast(transform.position, Vector3.down, 1.0f)) 
        {
            GameOver = true;
            RB.velocity = new Vector3(0, -25.0f, 0);
            Camera.main.GetComponent<CameraFollow>().GameOver = true;

            GameMAangerZigZagGame.Instance.GameOver();

        }
        Debug.DrawRay(transform.position, Vector3.down, Color.white);

        if (GameOver) return;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Diamond") 
        {
            GameObject ParticleOBJ = Instantiate(DiamondParticle, other.gameObject.transform.position, Quaternion.identity) as GameObject;

            Destroy(other.gameObject);
            Destroy(ParticleOBJ, 1.0f);
        }
    }
}
