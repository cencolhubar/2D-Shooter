using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

  
    public AudioSource decel;
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;


    public GUIText scoreText;
    public GUIText restartText;
    public GUIText gameOverText;

    private bool gameOver;
    private bool restart;
    private int score;



    // Use this for initialization
    void Start () {
        	//	gameOver = false;
		//restart = false;
		//restartText.text = "";
		//gameOverText.text = "";
		//score = 0;
		//UpdateScore ();
        decel = GetComponent<AudioSource>();
        StartCoroutine(SpawnWaves());
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            decel.Stop();
        }
    }
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {

                
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);

               // Debug.Log("spawn pos"+spawnPosition.x);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }

}
