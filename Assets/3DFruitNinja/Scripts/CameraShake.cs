using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Shake(float Duration, float magnitude) 
    {
        Vector3 OriginalPos = transform.localPosition;
        float Elapsed = 0.0f;

        while (Elapsed < Duration) 
        {
            float X = Random.Range(-1f, 1f) * magnitude;
            float Y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(X, Y, OriginalPos.z);
            Elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = OriginalPos;

    }
}
