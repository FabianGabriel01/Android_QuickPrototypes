using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class LineCreator : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;

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
        if (Input.GetMouseButtonDown(0)) 
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
            }
        }
        
    }
}
