using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public delegate void GenerateEnemyDelegate ();
public delegate void KillEnemyDelegate (GameObject enemy);

public class Game : MonoBehaviour {

    EnemyTimer timer;
    public GameObject Player;
    public GameObject [] SpawnPoints;
    public GameObject BasicEnemy;
    public GameObject player;
    public Text scoreLabel;
    public Text livesLabel;
    List<GameObject> allEnemies = new List<GameObject> ();
    int lives = 3;
    int score = 0;
    int multiplier = 1;
    PlayerHitDetection playerHitScript;
    PlayerControlScript playerControlScript;

	// Use this for initialization
	void Start () {
        timer = GetComponentInParent<EnemyTimer> ();
        timer.generateAnEnemy = GenerateEnemy;
        playerHitScript = Player.GetComponent<PlayerHitDetection> ();
        playerHitScript.killEnemy = KillEnemy;
        playerControlScript = Player.GetComponent<PlayerControlScript> ();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown (KeyCode.R)) {
            SceneManager.LoadScene (2, LoadSceneMode.Single);
        }
        if (playerControlScript.state == PlayerControlScript.PlayerStates.Dead) {
            player.transform.position = Vector3.zero;
            lives--;
            livesLabel.text = string.Format ("Lives: {0}", lives);
            if (lives <= 0) {
                //switch off screens
                playerControlScript.state = PlayerControlScript.PlayerStates.Dying;
            } else {
                playerControlScript.state = PlayerControlScript.PlayerStates.Normal;
                multiplier = 1;
                foreach(GameObject enemy in allEnemies) {
                    Destroy (enemy);
                }
                allEnemies.Clear ();
            }
        }
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
        GameObject newEnemy = (GameObject)Instantiate (BasicEnemy, SpawnPoints [UnityEngine.Random.Range (0, SpawnPoints.Length)].transform.position, Quaternion.identity);
        EnemyScript newScript = newEnemy.GetComponent<EnemyScript> ();
        newScript.Player = player;
        allEnemies.Add (newEnemy);
    }
}
