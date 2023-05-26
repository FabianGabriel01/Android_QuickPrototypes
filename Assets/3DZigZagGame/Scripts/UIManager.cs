using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject ZigZagPanel, GameOverPanel, TapText;
    public Text Score, HighScore1, HighScore2;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        HighScore1.text = "HighScore: " + PlayerPrefs.GetInt("HighScore").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStart() 
    {
        
        TapText.SetActive(false);
        ZigZagPanel.GetComponent<Animator>().Play("PanelAnim");

    }

    public void GameOver() 
    {
        Score.text = PlayerPrefs.GetInt("Score").ToString();
        HighScore2.text = PlayerPrefs.GetInt("HighScore").ToString();
        GameOverPanel.SetActive(true);
    }

    public void ResetGame() 
    {
        SceneManager.LoadScene("3DZigZagGame");
    }

}
