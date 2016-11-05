using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public delegate void GenerateEnemyDelegate ();
public delegate void KillEnemyDelegate (GameObject enemy);

public class Game : MonoBehaviour {

    EnemyTimer timer;
    public GameObject Player;
    public GameObject [] SpawnPoints;
    public GameObject BasicEnemy;
    public GameObject player;
    public Text scoreLabel;
    int score = 0;
    int multiplier = 1;

	// Use this for initialization
	void Start () {
        timer = GetComponentInParent<EnemyTimer> ();
        timer.generateAnEnemy = GenerateEnemy;
        Player.GetComponent<PlayerHitDetection> ().killEnemy = KillEnemy;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void KillEnemy (GameObject enemy)
    {
        EnemyScript eScript = enemy.transform.GetComponentInParent<EnemyScript> ();
        eScript.arms--;
        score += eScript.score * multiplier;
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
    }
}
