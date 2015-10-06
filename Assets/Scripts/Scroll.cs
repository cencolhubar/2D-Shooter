using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour {

    public float scrSpeed;
    public float tileSizeZ;

    private Vector3 startPos;
    

    // Use this for initialization
    void Start () {
        startPos = transform.position;
        
    }
	
	// Update is called once per frame
	void Update () {
        float newPos = Mathf.Repeat(Time.time * scrSpeed, tileSizeZ);
        transform.position = startPos + Vector3.back * newPos;



    }
}
