using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FruitSpawner : MonoBehaviour
{
    public GameObject[] Fruits;
    public float MaxX;
    public GameObject Bomb;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("StartSpawning", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnFruits() 
    {
        for (int i = 0; i < 5; i++) 
        {
            float Rand = UnityEngine.Random.Range(-MaxX, MaxX);
            Vector3 Pos = new Vector3(Rand, transform.position.y , 0.0f);
            GameObject Ins = Instantiate(Fruits[UnityEngine.Random.Range(0, Fruits.Length-1)], Pos, Quaternion.identity) as GameObject;
            yield return new WaitForSeconds(1.0f);

        }

    }

    public void SpawnFruitGroups() 
    {
        StartCoroutine(SpawnFruits());
        int F = UnityEngine.Random.Range(0, 6);
        Debug.Log(F);
        if (F > 3) 
        {
            SpawnBombs();
        }

    }

    public void StartSpawning() 
    {
        InvokeRepeating("SpawnFruitGroups", 1.0f, 6f);
    }

    public void StopSpawining() 
    {
        CancelInvoke("SpawnFruitGroups");
        StopCoroutine(SpawnFruits());
    }

    public void SpawnBombs() 
    {
        float Rand = UnityEngine.Random.Range(-MaxX, MaxX);
        Vector3 Pos = new Vector3(Rand, transform.position.y, 0.0f);
        GameObject Ins = Instantiate(Bomb, Pos, Quaternion.identity) as GameObject;
        Ins.GetComponent<Rigidbody>().AddForce(Vector3.up*35, ForceMode.Impulse);
        Ins.GetComponent<Rigidbody>().AddTorque(-40f,40f,0f);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
