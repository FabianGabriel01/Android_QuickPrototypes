using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    [SerializeField] Transform PlayerLoc;

    Vector3 Offset;
    public float SmoothRate;

    // Start is called before the first frame update
    void Start()
    {
        Offset = PlayerLoc.position - transform.position;
    }
    private void FixedUpdate()
    {
        Vector3 CurrentPosition = transform.position;
        Vector3 newPosition = PlayerLoc.position - Offset;

        transform.position = Vector3.Lerp(CurrentPosition, newPosition, SmoothRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
