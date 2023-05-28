using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManagerTappyBallGame : MonoBehaviour
{
    public static UIManagerTappyBallGame Instance;
    public GameObject MainMenu, GameOverPanel;
    public Animator Anims;
    public Text TextScore, ScoreGameOver;
    public Text HishScoreTappyBall;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        MainMenu.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        TextScore.text = ScoreManagerTappyBall.Instance.SCORE.ToString();
    }

    public void Play()
    {
        MainMenu.SetActive(false);
    }

    public void GameOver() 
    {
        HishScoreTappyBall.text = "HighScore: " + PlayerPrefs.GetInt("HighScoreTappyBall").ToString();
        ScoreGameOver.text = "Score: " + PlayerPrefs.GetInt("ScoreTappyBall").ToString();
        GameOverPanel.SetActive(true);
        GameOverPanel.GetComponent<Animator>().Play("GameOverAnim");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("TappyBallGameScene");
    }
}
