using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour {
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount ;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    private int score;
    public Text scoreText;
    public Text RestartText;
    public Text gameOverText;
    private bool restart;
    private bool gameOver;
    void Start()
    {
        score = 0;
        restart = false;
        gameOver = false;
        RestartText.text = "";
        gameOverText.text = "";
        StartCoroutine (SpawnWaves ());
        UpdateScore();
    }

    private void Update()
    {
        if(restart ==true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
    
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);

        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0,hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);

            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                RestartText.text = "Press R for restart";
                restart = true;
                break;
            }
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

