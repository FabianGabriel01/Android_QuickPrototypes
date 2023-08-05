using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaneSpawner : MonoBehaviour
{
    public GameObject Plane;
    Vector3 LastPosition;
    float Size;

    // Start is called before the first frame update
    void Start()
    {
        LastPosition = Plane.transform.position;
        Size = Plane.transform.localScale.z;

        for (int i = 0; i < 5; i++)
        {
            SpawnPlatforms();
        }

        InvokeRepeating("SpawnPlatforms", 2.0f, 2f);

    }

    private void SpawnPlatforms()
    {
        SpawnZ();
    }

    private void SpawnZ()
    {
        Vector3 Position = LastPosition;
        Position.z += Size *10;
        LastPosition = Position;
        Instantiate(Plane, Position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
