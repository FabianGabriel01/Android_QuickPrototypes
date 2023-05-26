using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject Platform;
    public GameObject Diamonds;
    Vector3 LastPosition;
    float Size;
    public bool GameOver;


    // Start is called before the first frame update
    void Start()
    {
        LastPosition = Platform.transform.position;
        Size = Platform.transform.localScale.x;

        for(int i = 0; i < 25; i++) 
        {
            SpawnPlatforms();
        }

        InvokeRepeating("SpawnPlatforms", 2.0f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameOver) CancelInvoke("SpawnPlatforms");
    }

    void SpawnPlatforms()
    {
        

        int Randomize = Random.Range(0, 6);
        if (Randomize < 3)
        {
            SpawnX();
        }
        else if (Randomize >= 3) 
        {
            SpawnZ();
        }
    }

    void SpawnX() 
    {
        Vector3 Position = LastPosition;
        Position.x += Size;
        LastPosition = Position;
        Instantiate(Platform, Position, Quaternion.identity);

        int Randomize = Random.Range(0,4);
        if (Randomize < 1)
        {
            Instantiate(Diamonds, new Vector3(Position.x, Position.y + 1.5f, Position.z), Diamonds.transform.rotation);
        }
    }

    void SpawnZ() 
    {
        Vector3 Position = LastPosition;
        Position.z += Size;
        LastPosition = Position;
        Instantiate(Platform, Position, Quaternion.identity);

        int Randomize = Random.Range(0, 4);
        if (Randomize < 1)
        {
            Instantiate(Diamonds, new Vector3(Position.x, Position.y + 1.5f, Position.z), Diamonds.transform.rotation);
        }
    }

}
