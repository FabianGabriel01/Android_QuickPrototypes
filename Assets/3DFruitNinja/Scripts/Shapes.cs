using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shapes : MonoBehaviour
{
    public float CubesSizes = 0.2f;
    public int CubesInRow = 2;

    float CubesPivotDistance;
    Vector3 CubesPivotOffset;

    float ExplotionRadius = 2.0f;
    float ExplotionForce = 2.0f;
    float Explotionupward = 2.5f;

    public PrimitiveType TypeShape;

    public static Shapes Instance;
    private void Awake()
    {
        if (Instance == null) Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        //Calculate pivot distance
        CubesPivotDistance = CubesSizes * CubesSizes / 2;
        //use this to create pivot
        CubesPivotOffset = new Vector3(CubesPivotDistance, CubesPivotDistance, CubesPivotDistance);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator OnExplode() 
    {
        yield return new WaitForSeconds(2.0f);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Ray")
        {
            Debug.Log("Shapes CollisionEnter");
            Explode();

        }
    }

    public void Explode()
    {
        Destroy(gameObject);
        for (int x = 0; x<CubesInRow;x++) 
        {
            for (int y = 0; y < CubesInRow; y++) 
            {
                for (int z = 0; z < CubesInRow; z++) 
                {
                    CreatePieces(x,y,z);

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

    void CreatePieces(int x, int y, int z) 
    {
        //Create the Piece
        GameObject Piece;
        Piece = GameObject.CreatePrimitive(TypeShape);

        //Set piece position and scale
        Piece.transform.position = transform.position + new Vector3(CubesSizes * x, CubesSizes *y, CubesSizes*z) - CubesPivotOffset;
        Piece.transform.localScale = new Vector3(CubesSizes, CubesSizes, CubesSizes);

        //Add Rigidbody and mass
        Piece.AddComponent<Rigidbody>();
        Piece.GetComponent<Rigidbody>().mass = CubesSizes;

        Destroy(Piece, 1.0f);
    }

}
