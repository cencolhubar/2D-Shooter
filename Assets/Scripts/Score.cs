using UnityEngine;
using System.Collections;


/// <summary>
/// This class updates the score when coins are collected
/// </summary>
public class Score : MonoBehaviour {



 public AudioSource exp;
    public int scoreValue;
    private GameController gameController;
   
   

    void Start() {
        //Gets a reference to game controller so the score can be updated 
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


        //If the police collects the coin then score is updated
        if (other.tag == "Police")
        {
            
            exp.Play();
            gameController.AddScore(scoreValue);
           // Destroy(gameObject);
        }


       
    }
}
