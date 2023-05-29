using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBouncer : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = new Vector3(0.0f, -9.81f, 0.0f);

        rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(Random.Range(10.0f, 15.0f), Random.Range(10.0f, 15.0f), 0.0f), ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        GameManagerBallsBounceOnClick.Instance.BallsOnScene -= 1;
        GameManagerBallsBounceOnClick.Instance.ScoreUp();
        Destroy(gameObject);
    }
}
