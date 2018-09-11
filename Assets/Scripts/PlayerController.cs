using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMax;
    public float xMin;
    public float zMax;
    public float zMin;
    
}

public class PlayerController : MonoBehaviour {
    public float speed;
    public float tilt;
    public Boundary boundary;
    // Update is called once per frame
    public GameObject shot;
    public Transform shotSpawn;

    public float fireRate;
    private float nextFire;

    private void Update()
    { 
           if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation) ;
            GetComponent<AudioSource>().Play();  
        }
    }
    void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal,0.0f,moveVertical) ;
        GetComponent<Rigidbody>().velocity = speed*movement;

        GetComponent<Rigidbody>().position = new Vector3(
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
            );
        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0,0, GetComponent<Rigidbody>().velocity.x * (-tilt) );
    }
}
 