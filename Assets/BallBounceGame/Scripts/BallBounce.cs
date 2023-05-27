using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
    Rigidbody RB;
    public float BounceForce;
    bool GameStarted;


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
        if (!GameStarted) 
        {
            if (Input.anyKeyDown) 
            {
                BeginBounce();
                GameStarted = true;
            }

        }
    }

    void BeginBounce() 
    {
        Vector2 RandomDirection = new Vector2(Random.Range(-1,1),1);

        RB.AddForce(RandomDirection * BounceForce, ForceMode.Impulse);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ground") 
        {
            BallBounceGameManager.instance.Restart();
        }

        if (collision.collider.tag == "Player") 
        {
            BallBounceGameManager.instance.ScoreUp();
        }
    }
}
