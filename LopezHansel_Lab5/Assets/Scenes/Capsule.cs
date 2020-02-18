using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule : MonoBehaviour
{
    public Rigidbody RB;
    public Transform[] posiciones;
    public float speed;

    private int actualPosicion = 0;
    private int proximaPosicion = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movePlatform();
    }

    void movePlatform()
    {
        RB.MovePosition(Vector3.MoveTowards(RB.position, posiciones[proximaPosicion].position, speed * Time.deltaTime));

        if (Vector3.Distance(RB.position,posiciones[proximaPosicion].position) <= 0)
        {
            actualPosicion = proximaPosicion;
            proximaPosicion++;

            if(proximaPosicion > posiciones.Length - 1)
            {
                proximaPosicion = 0;
            }
        }
    }
}
