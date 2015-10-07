using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PoliceController : MonoBehaviour
{

    private Rigidbody rb;
    public float speed;
    public Boundary boundary;
    public AudioSource Acc;
    public AudioSource Fire;

    public GameObject shot;
    public Transform shotSpawn;

    public float fireRate;
    private float nextFire;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Acc = GetComponent<AudioSource>();
    }

    void Update()
    {
        //Accept input from space bar to fire shots
        if (Input.GetKeyDown(KeyCode.Space)
            && Time.time > nextFire
            )
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            Fire.Play();


        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Acc.Play();
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            Acc.Stop();
        }
    }

 


        
        // Used for physics
    void FixedUpdate()
    {

        
    //Accepting input from player to control the police vehicle
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        
       rb.velocity = movement *speed;
        rb.position = new Vector3(

    Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
    0.0f,
    Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)

    
    );

    }
}

