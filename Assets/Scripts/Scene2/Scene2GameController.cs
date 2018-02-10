using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene2GameController : MonoBehaviour
{
    public GameObject hazard;
    public Vector3 spawnValuesUp;
    public Vector3 spawnValuesDown;
    public Vector3 spawnValuesLeft;
    public Vector3 spawnValuesRight;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text scoreText;
    public Text gameOverText;
    public Text restartText;

    private bool gameOver;
    private bool restart;
    private int score;

    private Vector3 spawnPosition;
    private Vector3 direction;

    private int numberOfWave;

    private void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        score = 0;
        numberOfWave = 1;
        UpdateScore ();
        StartCoroutine (SpawnWaves ());
    }

    private void Update()
    {
        UpdateScore();
        if (restart)
        {
            if (Input.GetKeyDown (KeyCode.R))
            {
                Application.LoadLevel (Application.loadedLevel);
            }
        }
    }

    IEnumerator SpawnWaves ()
    {
        yield return new WaitForSeconds(startWait);
        while (!gameOver)
        {
            for (int i = 0; i < (hazardCount + 5 * (numberOfWave - 1)); i++)
            {
                int random;
                if (numberOfWave > 4)
                    random = Random.Range(1, 5);
                else
                    random = Random.Range(1, numberOfWave + 1);
                if (random == 1)
                    spawnPosition = new Vector3(Random.Range(-spawnValuesRight.x, spawnValuesRight.x), spawnValuesRight.y, spawnValuesRight.z);
                if (random == 2)
                    spawnPosition = new Vector3(Random.Range(-spawnValuesLeft.x, spawnValuesLeft.x), spawnValuesLeft.y, spawnValuesLeft.z);
                if (random == 3)
                    spawnPosition = new Vector3(spawnValuesUp.x, spawnValuesUp.y, Random.Range(-1.0f, spawnValuesUp.z));
                if (random == 4)
                    spawnPosition = new Vector3(spawnValuesDown.x, spawnValuesDown.y, Random.Range(-1.0f, spawnValuesDown.z));
                Quaternion spawnRotation = Quaternion.identity;
                GameObject clone = Instantiate(hazard, spawnPosition, spawnRotation) as GameObject;
                Rigidbody cloneRB = clone.GetComponent<Rigidbody>();
                yield return new WaitForEndOfFrame ();
                if (random == 1)
                    direction = new Vector3(0.0f, 0.0f, cloneRB.velocity.z);
                if (random == 2)
                    direction = new Vector3(0.0f, 0.0f, -cloneRB.velocity.z);
                if (random == 3)
                    direction = new Vector3(-cloneRB.velocity.z, 0.0f, 0.0f);
                if (random == 4)
                    direction = new Vector3(cloneRB.velocity.z, 0.0f, 0.0f);
                cloneRB.velocity = direction * (1 + (numberOfWave - 1) / 5);
                if ((numberOfWave - 1) < 10)
                    yield return new WaitForSeconds(spawnWait - ((numberOfWave - 1) / 10));
            }
            numberOfWave = numberOfWave + 1;
            yield return new WaitForSeconds(waveWait);
            if (gameOver)
            {
                restartText.text = "Press 'R' for Restart";
                restart = true;
            }
        }
    }

    public void AddScore (int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore ();
    }

    void UpdateScore ()
    {
        if (Time.time < 3)
            scoreText.text = "Time to start: " + (3 - (int)Time.time);
        else
            scoreText.text = "Time elapsed: " + ((int)Time.time - 3);
        scoreText.text += " | Wave " + numberOfWave + " | Asteroids destroyed: " + score;
    }

    public void GameOver ()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }
}
