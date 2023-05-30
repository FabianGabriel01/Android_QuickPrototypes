using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shapes : MonoBehaviour
{
    public float CubesSizes = 0.5f;
    public int CubesInRow = 1;

    float CubesPivotDistance;
    Vector3 CubesPivotOffset;

    float ExplotionRadius = 2.0f;
    float ExplotionForce = 1.0f;
    float Explotionupward = 1.0f;

    public PrimitiveType TypeShape;

    public static Shapes Instance;
    public GameObject[] Splashs;

    Rigidbody Rigidbody;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
        float RandForce = UnityEngine.Random.Range(22f,37f);
        UnityEngine.Debug.Log(RandForce);
        Rigidbody.AddForce(Vector3.up* RandForce, ForceMode.Impulse);
        Rigidbody.AddTorque(20f,20f,0f);

        //Calculate pivot distance
        CubesPivotDistance = CubesSizes * CubesSizes / 2;
        //use this to create pivot
        CubesPivotOffset = new Vector3(CubesPivotDistance, CubesPivotDistance, CubesPivotDistance);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Ray")
        {
            //Debug.Log("Shapes CollisionEnter");
            Explode();

        }
    }

    public void Explode()
    {
        GameObject ASplash = Instantiate(Splashs[UnityEngine.Random.Range(0, Splashs.Length - 1)], transform.position, Quaternion.identity);
        ASplash.transform.LookAt(Camera.main.transform.position, -Vector3.up);
        Destroy(gameObject);
        for (int x = 0; x<CubesInRow;x++) 
        {
            for (int y = 0; y < CubesInRow; y++) 
            {
                for (int z = 0; z < CubesInRow; z++) 
                {
                    CreatePieces(x,y,z, ASplash);

                }
            }
        }



        //Explotion posisition
        Vector3 ExploionPos = transform.position;
        //get colliders 
        Collider[] colliders = Physics.OverlapSphere(ExploionPos, ExplotionRadius);
        //add force
        foreach(Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null )
            {
                rb.AddExplosionForce(ExplotionForce, transform.position, ExplotionRadius, Explotionupward, ForceMode.Impulse);
            }
        }
    }

    void CreatePieces(int x, int y, int z, GameObject SplashS) 
    {
        //Create the Piece
        GameObject Piece;
        Piece = GameObject.CreatePrimitive(TypeShape);

        //Set piece position and scale
        Piece.transform.position = transform.position + new Vector3(CubesSizes * x, CubesSizes *y, CubesSizes*z) - CubesPivotOffset;
        Piece.transform.localScale = new Vector3(CubesSizes, CubesSizes, CubesSizes);

        //Add Rigidbody and mass
        Piece.AddComponent<Rigidbody>();
        //Piece.GetComponent<Rigidbody>().mass = CubesSizes;
        Piece.GetComponent<Rigidbody>().mass = 0.1f;

        Destroy(SplashS, 1.0f);
        Destroy(Piece, 1.0f);
    }

}
