using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    public Vector3 direccion;
    public float speed = 2f;

    public GameObject objeto;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(objeto.transform.position, direccion, speed * Time.deltaTime);
    }
}
