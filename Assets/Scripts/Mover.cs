using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

    public float speed;


    void Start()
    {
        //Allows the coins and hazards to fall
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }
}
