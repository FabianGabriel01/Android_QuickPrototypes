using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManagerTappyBall : MonoBehaviour
{
    public static ScoreManagerTappyBall Instance;
    public int SCORE;


    private void Awake()
    {
        if (Instance == null) Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        SCORE = 0;
        PlayerPrefs.SetInt("ScoreTappyBall", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncrementScore() 
    {
        SCORE++;
        Debug.Log(SCORE);
    }

    public void StopScore()
    {
        PlayerPrefs.SetInt("ScoreTappyBall", SCORE);

        if (PlayerPrefs.HasKey("HighScoreTappyBall")) 
        {
            if (SCORE > PlayerPrefs.GetInt("HighScoreTappyBall")) 
            {
                PlayerPrefs.SetInt("HighScoreTappyBall", SCORE);
            }
        }
        else
        {
            PlayerPrefs.SetInt("HighScoreTappyBall", SCORE);
        }
    }
}
