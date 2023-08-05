using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PipeSpawner : MonoBehaviour
{
    public GameObject PipeOBJ;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnPipe", 1.0f, 3.0f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnPipe() 
    {
        Instantiate(PipeOBJ, new Vector3(transform.position.x, Random.Range(-2.5f, 4.0f), transform.position.z), Quaternion.identity);
    }

    public void CancelInvokeSpawnPipe() 
    {
        CancelInvoke("SpawnPipe");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
