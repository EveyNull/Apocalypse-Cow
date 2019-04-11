using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public int score;

    public float levelDurationSeconds = 300f;
    public float spawnCowsEveryNSeconds = 0.2f;

    public GameObject cow;
    public GameObject planet;

    public Text scoreText;

    private float spawnTimer;
    private float levelTimer;
    private bool gameRunning;

    private int numberOfCowsSpawned;

	// Use this for initialization
	void Start () {
        spawnTimer = 0f;
        levelTimer = 0f;
        gameRunning = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (gameRunning)
        {
            spawnTimer += Time.deltaTime;
            levelTimer += Time.deltaTime;
            if (levelTimer >= levelDurationSeconds)
            {
                gameRunning = false;
            }
            if (spawnTimer >= spawnCowsEveryNSeconds)
            {
                numberOfCowsSpawned++;
                int infectedDiceRoller = Random.Range(1, 20);
                GameObject newCow = Instantiate(cow, new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1)), Quaternion.Euler(0, 0, 0));
                newCow.transform.SetParent(planet.transform);
                spawnTimer = 0f;
                if (infectedDiceRoller == 1)
                {
                    newCow.AddComponent<MoveForwardsAndInfect>();
                }
                if (levelTimer % 10 == 0)
                {
                    spawnCowsEveryNSeconds += 0.5f;
                }
            }
        }
        scoreText.text = "SCORE: " + score;
	}
}
