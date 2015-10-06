using UnityEngine;
using System.Collections;

public class DestroyOnContact : MonoBehaviour {


    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    private GameController gameController;


    void Start() {

        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' Script");
        }
    }

    void OnTriggerEnter(Collider other) {
        //Debug.Log()

        
        if (other.tag=="Boundary")
        {
            return;
        }
        

        if (other.tag == "Police")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            //gameController.AddScore(scoreValue);
            gameController.GameOver();
        }
        Destroy(other.gameObject);
        Destroy(gameObject);
       
    }
}
