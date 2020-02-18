using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colision : MonoBehaviour
{
    public GameObject spawnObject;
    public GameObject camera;
    public GameObject[] obstacles;
    private Vector3 sp0 = new Vector3(13.68f, 19.9f, -10.84f);
    private Vector3 sp1 = new Vector3(-12.88f, 19.94f, -2.410001f);
    private Vector3 sp2 = new Vector3(13.91f, 19.85f, -1.3f);
    private Vector3 sp3 = new Vector3(-13.963f, 19.7f, -0.471f);
    private Vector3 sp4 = new Vector3(13.77f, 19.84f, 12.49f);
    
    public void haGanado()
    {
        if (GameObject.FindWithTag("Coin") == null) 
        {
            ThirdPersonCamera thpc = camera.GetComponent<ThirdPersonCamera>();
            thpc.transform.GetChild(1).GetComponent<MeshRenderer>().enabled = true;
            obstacles = GameObject.FindGameObjectsWithTag("Obstaculo");

            foreach (GameObject obstacle in obstacles)
            {
                obstacle.tag = "obstaculoMuerto"; 
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Sp1 spawn = spawnObject.GetComponent<Sp1>();
        if (other.tag == "Coin")
        {
            haGanado();
            ScoreSystem.coinAmount += 1;
            Destroy(other.gameObject);
            haGanado();
        }
       
        if (other.tag == "Obstaculo")
        {
            haGanado();
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            gameObject.GetComponent<SphereCollider>().enabled = false;
            ScoreSystem2.deathAmount += 1;
            spawn.setPlayer(this.gameObject);
            ThirdPersonCamera thpc = camera.GetComponent<ThirdPersonCamera>();
            thpc.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
        }

        if (other.tag == "firstSpawn")
        {
            spawn.setPosition(sp0);
        }else if(other.tag == "Spawnpoint")
        {
            spawn.setPosition(sp1);
        }else if(other.tag == "Spawnpoint1")
        {
            spawn.setPosition(sp2);
        }else if(other.tag == "Spawnpoint2")
        {
            spawn.setPosition(sp3);
        }else if(other.tag == "Spawnpoint3")
        {
            spawn.setPosition(sp4);
        }
    }
}
