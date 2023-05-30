using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class LineCreator : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    public GameObject BombSplash;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        MovementMouse();
    }


    void MovementMouse() 
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButton(0)) 
        {
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                UnityEngine.Debug.DrawRay(hit.point, Vector3.forward);
                transform.position = hit.point;
                UnityEngine.Debug.Log(hit.collider.name);
                if (hit.collider.tag == "Fruit")
                {
                    hit.collider.gameObject.GetComponent<Shapes>().Explode();
                }
                else if (hit.collider.tag == "Bomb") 
                {
                    StartCoroutine(mainCamera.GetComponent<CameraShake>().Shake(0.15f, 0.4f));
                    GameObject Splash = Instantiate(BombSplash, hit.collider.transform.position, Quaternion.identity) as GameObject;
                    //Splash.transform.LookAt(Camera.main.transform.position, -Vector3.up);
                    Splash.gameObject.transform.localScale = new Vector3(5f,5f,0f);
                    Destroy(hit.transform.gameObject);
                    Destroy(Splash, 1f);
                    
                }
            }
        }
    }
}
