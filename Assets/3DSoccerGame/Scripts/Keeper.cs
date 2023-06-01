using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class Keeper : MonoBehaviour
{
    enum ChangeDirections 
    {
        MaxX,
        MinX
    }

    ChangeDirections ChangesX = ChangeDirections.MaxX;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        SwitchDirections();
        Comparations();
    }

    void SwitchDirections() 
    {
        switch (ChangesX) 
        {
            case ChangeDirections.MaxX:
                transform.position += new Vector3(1f, 0f, 0f) * Time.deltaTime;
            break;
        
            case ChangeDirections.MinX:
                transform.position += new Vector3(-1f, 0f, 0f) * Time.deltaTime;
            break;

            default:
            break;
        }
    }

    void Comparations() 
    {
        if (transform.position.x <=-1f) 
        {
            ChangesX = ChangeDirections.MaxX;
        }
        else if (transform.position.x >= 1f) 
        {
            ChangesX = ChangeDirections.MinX;
        }
    }

}
