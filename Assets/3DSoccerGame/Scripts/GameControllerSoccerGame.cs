using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerSoccerGame : MonoBehaviour
{
    public GameObject BallSoccer;
    Vector3 MouseStart, MouseEnd;
    GameObject BallInstance;

    public Rigidbody RB;


    public float MinimunDistance = 15.0f;
    float zDepth = 25f, BallForce = 15f;

    // Start is called before the first frame update
    void Start()
    {
        //RB = GetComponent<Rigidbody>();
        CreateBall();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MouseStart = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            MouseEnd = Input.mousePosition;

            if (Vector3.Distance(MouseStart, MouseEnd) > MinimunDistance) 
            {
                ////throw ball
                Vector3 HitPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, zDepth);
                HitPosition = Camera.main.ScreenToWorldPoint(HitPosition);
                
                BallInstance.transform.LookAt(HitPosition);
                BallInstance.GetComponent<Rigidbody>().AddRelativeForce(BallInstance.transform.forward * BallForce, ForceMode.Impulse);

                Invoke("CreateBall",2f);
            }
        }

    }

    void CreateBall() 
    {
        BallInstance = Instantiate(BallSoccer, transform.position, Quaternion.identity) as GameObject;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
