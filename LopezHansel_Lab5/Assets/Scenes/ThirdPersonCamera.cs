﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public GameObject jugador;
    public GameObject referencia;
    private Vector3 distancia;
 


    // Start is called before the first frame update
    void Start()
    {
        distancia = transform.position - jugador.transform.position;
    }

    public void setJugador(GameObject jugador)
    {
        this.jugador = jugador;
    }
    public void setReferencia(GameObject referencia)
    {
        this.referencia = referencia;
    }

    // Update is called once per frame
    void Update()
    {
        distancia = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * 2, Vector3.up) * distancia;
        transform.position = jugador.transform.position + distancia;
        transform.LookAt(jugador.transform.position);


        //Controles no cambian
        Vector3 copiaRotacion = new Vector3(0, transform.eulerAngles.y, 0);
        referencia.transform.eulerAngles = copiaRotacion;
    }
}
