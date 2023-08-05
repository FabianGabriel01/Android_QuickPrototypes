using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerBlockDodgeGame : MonoBehaviour
{
    public GameObject CubeFall;
    public float MaxX, SpawnRate;
    public Transform SpawnPoint;
    bool GameStarted = false;

    public GameObject Title;
    public Text ScoreTxt;
    public int Score;

    public static GameManagerBlockDodgeGame Instance;
    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Title.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !GameStarted) 
        {
            StartSpawning();
            GameStarted = true;
        }

        UIUpdates();

    }

    void UIUpdates() 
    {
        if (GameStarted) 
        {
            Title.SetActive(false);
        }
    }

    void SpawnCubes() 
    {
        Vector3 SpawnPos = SpawnPoint.position;
        SpawnPos.x = Random.Range(MaxX, -MaxX);

        GameObject Ins = Instantiate(CubeFall, SpawnPos, Quaternion.identity) as GameObject;
        Ins.GetComponent<Rigidbody>().AddTorque(Vector3.up, ForceMode.Impulse);
    }

    void StartSpawning() 
    {
        InvokeRepeating("SpawnCubes", 1f, SpawnRate);
    }

    public void SetScore() 
    {
        Score++;
        ScoreTxt.text = Score.ToString();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
