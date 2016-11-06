using UnityEngine;
using System.Collections;

public class Arcaine : MonoBehaviour {

    // Use this for initialization
    void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
	   
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Picked up Arcaine");
            GameObject.Destroy(this.gameObject);
        }
    }
}
