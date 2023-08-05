using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject Obstacle;
    public Transform transformSpawnPoints;
    int Score;
    public Text ScoreTxt;
    public GameObject Button;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        GameStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStart() 
    {
        Player.SetActive(true);
        Button.SetActive(false);
        StartCoroutine(SpawnTimesIE());
        InvokeRepeating("Scoreupdate", 2f, 1f);
    }

    public void Scoreupdate() 
    {
        Score += 1;
        ScoreTxt.text = Score.ToString();
    }
    IEnumerator SpawnTimesIE()
    {
        while(true)
        {
            float WaitTime = Random.Range(0.5f, 2.0f);
            yield return new WaitForSeconds(WaitTime);
            Instantiate(Obstacle, transformSpawnPoints.position, Quaternion.identity);
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
