using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMAangerZigZagGame : MonoBehaviour
{
    public static GameMAangerZigZagGame Instance;
    public bool bGameOver;


    private void Awake()
    {
        if (Instance == null) Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        bGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame() 
    {
        UIManager.Instance.GameStart();
        ScoreManager.instance.StartScore();
    }

    public void GameOver() 
    {
        UIManager.Instance.GameOver();
        ScoreManager.instance.StopScore();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }


}
