using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour {

    public delegate void GenerateEnemyDelegate ();
    EnemyTimer timer;
    public GameObject Player;
    public GameObject [] SpawnPoints;
    public GameObject BasicEnemy;
    public GameObject player;

	// Use this for initialization
	void Start () {
        timer = GetComponentInParent<EnemyTimer> ();
        timer.generateAnEnemy = GenerateEnemy;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void GenerateEnemy ()
    {
        GameObject newEnemy = (GameObject)Instantiate (BasicEnemy, SpawnPoints [UnityEngine.Random.Range (0, SpawnPoints.Length)].transform.position, Quaternion.identity);

        EnemyScript newScript = newEnemy.GetComponent<EnemyScript> ();
        newScript.Player = player;
    }
}
