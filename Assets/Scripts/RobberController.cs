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
    public GameObject AItarget;
    public Transform AItransform;
   private bool targetAcquired=false;

    // Use this for initialization
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        Acc = GetComponent<AudioSource>();
        target = Random.Range(boundary.xMin, boundary.xMax);
        //target = Random.Range(-4.0f, 4.0f);
        Instantiate(AItarget, new Vector3(

        Mathf.Clamp(AItarget.GetComponent<Transform>().position.x, boundary.xMin, boundary.xMax),
        0.0f,
       rb.position.z

        ), AItransform.rotation);
        Debug.Log("Target"+ AItarget.GetComponent<Transform>().position.x);

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

        //  rb.GetComponent<Transform>().LookAt(AItarget.transform);

        /*
        if (Vector3.Distance(rb.GetComponent<Transform>().position, AItarget.transform.position) > 1f&& targetAcquired == false) {
            rb.GetComponent<Transform>().Translate(new Vector3(speed*Time.deltaTime,0,0));

            Debug.Log("Tracking Target "+ rb.GetComponent<Transform>().position.x+" "+ AItarget.GetComponent<Transform>().position.x);
        }
        if (Vector3.Distance(rb.GetComponent<Transform>().position, AItarget.transform.position) <= 1f)
        {
            targetAcquired = true;
            Debug.Log("TargetAcquired");

            resetTarget();
            
        }
       
        */

    }

    // Used for physics
    void FixedUpdate()
    {

    }

    void  resetTarget()
    {

        target = Random.Range(boundary.xMin, boundary.xMax);
        AItarget.transform.position = new Vector3(

    Mathf.Clamp(target, boundary.xMin, boundary.xMax),
    0.0f,
    Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)


    );

        Debug.Log("New Target "+ AItarget.GetComponent<Transform>().position.x);
        targetAcquired = false;
    }

}
