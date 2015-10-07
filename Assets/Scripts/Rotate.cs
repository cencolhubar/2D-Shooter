using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour
{

    public float tumble;

    // Use this for initialization
    void Start()
    {

        //rotates the coins as they fall
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
    }


}