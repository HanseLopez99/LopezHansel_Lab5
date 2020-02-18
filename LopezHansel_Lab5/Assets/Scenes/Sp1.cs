using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sp1 : MonoBehaviour
{
    public static Vector3 spawnPosicion;
    public GameObject playerPrefab;
    public GameObject cameraPrefab;
    public GameObject oldPlayerSphere;
    public GameObject respawnSound;
    public GameObject[] targetsToDestroy;
    public float tiempoVida;

    private Vector3 position;

    public void setPlayer(GameObject player)
    {
        this.playerPrefab = player;
    }

    private void Update()
    {
        spawnPlayer();
        
    }

    public void autoDestroy()
    {
        targetsToDestroy = GameObject.FindGameObjectsWithTag("AutoDestroy");
        foreach (GameObject target in targetsToDestroy)
        {
            Destroy(target.gameObject, tiempoVida);
        }
        
    }

    public void setPosition(Vector3 position)
    {
        this.position = position;
    }


    public void spawnPlayer()
    {
        Colision oldPlayer = oldPlayerSphere.GetComponent<Colision>();
        if (oldPlayer.GetComponent<MeshRenderer>().enabled == false)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                
                GameObject player = Instantiate(playerPrefab, position, Quaternion.identity);
                player.name = "PlayerSphere";
                ThirdPersonCamera thpCamera = cameraPrefab.GetComponent<ThirdPersonCamera>();
                thpCamera.jugador = player.gameObject;
                thpCamera.referencia = player.transform.GetChild(0).gameObject;
                thpCamera.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
                player.gameObject.GetComponent<MeshRenderer>().enabled = true;
                player.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                player.gameObject.GetComponent<SphereCollider>().enabled = true;
                Instantiate(respawnSound);
                //GameObject clone = (GameObject)Instantiate(respawnSound, transform.position, transform.rotation);
                //clone.GetComponent<Sp1>().respawnSound = GetComponent<Sp1>().respawnSound;
                //Destroy(clone.gameObject);
                
                
                
                Destroy(oldPlayer.gameObject);
                oldPlayerSphere = player.gameObject;
            }
        }      
    }
}
