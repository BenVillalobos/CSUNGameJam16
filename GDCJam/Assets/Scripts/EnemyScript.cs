using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

    public GameObject Player;
    public float speed = 0.01f;
    public int arms = 0;
	// Use this for initialization
    void Start () {
        //count how many arms an enemy has
        foreach (GameObject child in transform) {
            if (child.tag == "Bar") {
                arms++;
            }
        }
    }

    // Update is called once per frame
    void Update () {
        transform.position = Vector2.MoveTowards (transform.position, Player.transform.position, speed);
        transform.Rotate (Vector3.forward * -1);

        if (arms <= 0) {
            Destroy (gameObject);
        }
	}
}
