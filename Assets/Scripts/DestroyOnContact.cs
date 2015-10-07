using UnityEngine;
using System.Collections;
/// <summary>
/// Carrys out various functions on objects when they collide
/// </summary>
public class DestroyOnContact : MonoBehaviour {


    public GameObject explosion;
    public GameObject playerExplosion;
 public AudioSource exp;
    public int scoreValue;
    private GameController gameController;
   
    

    void Start() {
        //Gets a reference to game controller so the score can be updated and gameover can be called
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


        //Dont do anything if there is a boundary collision

        if (other.tag == "Boundary")
        {
            return;
        }

        //If its a collision with the police i.e. the player , then call game over function
        else if (other.tag == "Police")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            exp.Play();
            //gameController.AddScore(scoreValue);
           // Destroy(other.gameObject);
            Destroy(gameObject);
            gameController.GameOver();
        }

        //This does not work...aborted to hand in project.Should destroy other object when shots are fired
        else if (other.tag == "Shot")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);

            gameController.AddScore(scoreValue);

            // gameController.GameOver();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        else return;


       
    }
}
