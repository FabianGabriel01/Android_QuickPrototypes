using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BallBounceGameManager : MonoBehaviour
{
    public static BallBounceGameManager instance;
    public Text textScore;
    public int SCORE = 0;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart() 
    {
        SceneManager.LoadScene("BallBounceGame");
    }

    public void ScoreUp() 
    {
        SCORE++;
        textScore.text = SCORE.ToString();
    }
}
