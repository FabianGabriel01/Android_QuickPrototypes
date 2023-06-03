using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeFalls : MonoBehaviour
{

    private void Awake()
    {
        Physics.gravity = new Vector3(0f, -9.81f,0f);    
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ground") 
        {
            GameManagerBlockDodgeGame.Instance.SetScore();
        }

    }
}
