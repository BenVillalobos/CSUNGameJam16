using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public delegate void GenerateEnemyDelegate ();
public delegate void KillEnemyDelegate (GameObject enemy);

public class Game : MonoBehaviour {
    public static float enemySpeed = 0.1f;
    public static float rotationSpeed = 1;

    EnemyTimer timer;
    public GameObject Player;
    public GameObject BasicEnemy;
    public GameObject player;
    public Canvas gameOverCanvas;
    public Canvas gameCanvas;
    public Text scoreLabel;
    public Text livesLabel;
    EnemySpawner spawner;
    public readonly List<GameObject> allEnemies = new List<GameObject> ();
    public int lives = 3;
    public int score = 0;
    int multiplier = 1;
    PlayerHitDetection playerHitScript;
    public PlayerControlScript playerControlScript;
	// Use this for initialization
	void Start () {
        timer = GetComponentInParent<EnemyTimer> ();
        timer.generateAnEnemy = GenerateEnemy;
        playerHitScript = Player.GetComponent<PlayerHitDetection> ();
        playerHitScript.killEnemy = KillEnemy;
        playerControlScript = Player.GetComponent<PlayerControlScript> ();
        gameOverCanvas.enabled = false;

        spawner = GetComponent<EnemySpawner> ();

	}
	
	// Update is called once per frame
	void Update () {
        Camera.main.transform.position = new Vector3 (player.transform.position.x, player.transform.position.y, Camera.main.transform.position.z);

        if (Input.GetKeyDown (KeyCode.R)) {
            ResetGame ();
        }
        if (playerControlScript.state == PlayerControlScript.PlayerStates.Dead) {
            player.transform.position = Vector3.zero;
            lives--;
            livesLabel.text = string.Format ("Lives: {0}", lives);
            DeleteAllEnemies ();
            if (lives <= 0) {
                gameCanvas.enabled = false;
                gameOverCanvas.enabled = true;
            } else {
                playerControlScript.state = PlayerControlScript.PlayerStates.Normal;
                multiplier = 1;
                updateScore ();
            }
        } else if (playerControlScript.state == PlayerControlScript.PlayerStates.DogWeed) {
            enemySpeed = 0.01f;
            rotationSpeed = 0.01f;
        } else {
            enemySpeed = 0.09f;
            rotationSpeed = 1f;
        }
	}

    public void ResetGame ()
    {
        SceneManager.LoadScene (3, LoadSceneMode.Single);
    }

    void DeleteAllEnemies ()
    {
        foreach (GameObject enemy in allEnemies) {
            Destroy (enemy);
        }
        allEnemies.Clear ();
    }

    public void KillEnemy (GameObject enemy)
    {
        EnemyScript eScript = enemy.transform.GetComponentInParent<EnemyScript> ();
        eScript.arms--;
        score += eScript.score * multiplier;
        if (allEnemies.Contains (enemy.transform.parent.gameObject)) {
            allEnemies.Remove (enemy.transform.parent.gameObject);
        }
        Destroy (enemy.transform.parent.gameObject);
        multiplier++;
        updateScore ();
    }

    void updateScore ()
    {
        scoreLabel.text = string.Format ("Score: {0}\nMultiplier:{1}x", score, multiplier);
    }

    public void GenerateEnemy ()
    {
        //GameObject newEnemy = (GameObject)Instantiate (BasicEnemy, SpawnPoints [UnityEngine.Random.Range (0, SpawnPoints.Length)].transform.position, Quaternion.identity);
        //EnemyScript newScript = newEnemy.GetComponent<EnemyScript> ();
        //newScript.Player = player;
        //allEnemies.Add (newEnemy);
        spawner.GenerateRandomEnemy ();
    }
}
