using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManagerBallsBounceOnClick : MonoBehaviour
{
    public GameObject Balls;
    public int Score;
    public int BallsOnScene;
    public static GameManagerBallsBounceOnClick Instance;
    bool OnStartTospawn = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnersBalls", 1.5f, 0.5f);
        Score = 0;
        BallsOnScene = 0;
    }

    // Update is called once per frame
    void Update()
    {
        UnityEngine.Debug.Log("BallsOnScene" + BallsOnScene);

        GameWin();
    }

    void SpawnersBalls() 
    {
        Instantiate(Balls, new Vector3(transform.position.x + Random.Range(-4.0f, 4.0f), transform.position.y, transform.position.z), Quaternion.identity);
        OnStartTospawn=true;
        BallsOnScene++;
    }

    void GameWin() 
    {
        if (OnStartTospawn) 
        {
            if (BallsOnScene <= 0) 
            {
                CancelInvoke("SpawnersBalls");

            }
        }
    }

    public void ScoreUp() 
    {
        Score++;
    }
}
