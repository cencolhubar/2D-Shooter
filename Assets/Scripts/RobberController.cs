using UnityEngine;
using System.Collections;

[System.Serializable]
public class RobberBoundary
{
    public float xMin, xMax, zMin, zMax;
}

public class RobberController : MonoBehaviour
{

    private Rigidbody rb;
    public float speed;
    public Boundary boundary;
    public AudioSource Acc;
    private float target;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Acc = GetComponent<AudioSource>();
       // target = Random.Range(boundary.xMin, boundary.xMax);
        target = Random.Range(-4.0f, 4.0f);
        Debug.Log("Target"+target);
     }

    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Acc.Play();
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            Acc.Stop();
        
            */
    }

    // Used for physics
    void FixedUpdate()
    {

        // float moveHorizontal = Input.GetAxis("Horizontal");
        // float moveVertical = Input.GetAxis("Vertical");
        Debug.Log("Target" + target);
        Debug.Log("rb.position.x" + rb.position.x);
        Debug.Log("boundary.xMin" + boundary.xMin);
        Debug.Log("boundary.xMax" + boundary.xMax);
        if ((float)rb.position.x > -4)
        {
            // float moveHorizontal = Random.Range(0.0f, -1.0f);
            float moveHorizontal = 0.1f;
            float moveVertical = 0.0f;
           

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            //rb.AddForce(movement * speed);

            rb.velocity = movement * speed;
            rb.position = new Vector3(

        Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
        0.0f,
        Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)


        );
            /*
              if (rb.position.x <= target)
            {
                target = Random.Range(-4.0f, 4.0f);
            }
              */

        }
        else if ((float)rb.position.x < 4) {
            //float moveHorizontal = Random.Range(0.0f, 1.0f);
            float moveHorizontal = 1.0f;
            float moveVertical = 0.0f;
           

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            //rb.AddForce(movement * speed);

            rb.velocity = movement * speed;
            rb.position = new Vector3(

        Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
        0.0f,
        Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)


        );

            /*
            if (rb.position.x > target)
            {
                target = Random.Range(-4.0f, 4.0f);
            }
             */

        }

        if ((float)rb.position.x == (float)target)
        {
            target = Random.Range(-4.0f, 4.0f);
        }
    }
}
