using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Game Controller class controlling spawning of coins and hazards and add score and game over functions
/// </summary>
public class GameController : MonoBehaviour {

  
    public AudioSource decel;
    public GameObject hazard;
    public GameObject hazard2;
    public GameObject hazard3;
    public GameObject temphazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;


    public Text scoreText;
    public Text restartText;
    public Text gameOverText;
    public Text Timer;
    public int time;

    private bool gameOver;
    private bool restart;
    private int score;
    private bool coin = false;



    // Use this for initialization
    void Start () {
        		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
		UpdateScore ();
        //decel = GetComponent<AudioSource>();
        StartCoroutine(SpawnWaves());
        // StartCoroutine(SpawnCoins());
        time = 60;
    }
	
	// Update is called once per frame
	void Update () {
// if the R button is pressed then restart the level

        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }

 
    /// This function spawns waves of coins for the police to collect or hazards to avoid randomly
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {

            if (coin == false)
            {

                temphazard = hazard;
                coin = true;
            }
            else if (coin == true)
            {

                temphazard = hazard3;
                coin = false;
            }

            for (int i = 0; i < hazardCount; i++)
            {

 
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);

               // Debug.Log("spawn pos"+spawnPosition.x);
                Quaternion spawnRotation = Quaternion.identity;
 
                    Instantiate(temphazard, spawnPosition, spawnRotation);

                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'R' for Restart";
                restart = true;
                break;
            }
        }
    }


    /*
    IEnumerator SpawnCoins()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {


                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);

                // Debug.Log("spawn pos"+spawnPosition.x);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard3, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'R' for Restart";
                restart = true;
                break;
            }
        }

    
}

*/

        //updates the score
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }


    //Displays the new score to the UI
    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }


    //Sets game as ended
    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }

}
