using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBallController : MonoBehaviour
{
    Rigidbody RB;
    public float UpSpeed;
    bool Started;
    bool GameOver;

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = new Vector3(0.0f, -9.81f, 0.0f);

        RB = GetComponent<Rigidbody>();
        Started = false;
        GameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Started)
        {

            if (Input.GetMouseButtonDown(0))
            {
                RB.isKinematic = false;
                Started = true;
            }
        }
        else 
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) 
            {
                RB.velocity = Vector3.zero;
                RB.AddForce(new Vector3(0.0f, UpSpeed));
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (GameOver) return;

        if (other.tag == "Ground")
        {
            Debug.Log("GROUND COLLIDES");
            GameOver = true;
            RB.isKinematic = false;
            ScoreManagerTappyBall.Instance.StopScore();
            UIManagerTappyBallGame.Instance.GameOver();
        }

        if (other.tag == "Obstacle") 
        {
            Debug.Log("OBSTAV}CLE COLLIDES");
            ScoreManagerTappyBall.Instance.IncrementScore();
        }
    }
}
