using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class Keeper : MonoBehaviour
{
    public float MaxX = 1f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Move", 1f,1f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Right(bool T) 
    {
        if (T)
            transform.Translate(Vector3.right * 1f * Time.deltaTime);
        else 
        {
            transform.Translate(-Vector3.right * 1f * Time.deltaTime);
        }
    }

    IEnumerator Move() 
    {
        Right(true);
        yield return new WaitForSeconds(1f);
        Right(false);
    }
}
