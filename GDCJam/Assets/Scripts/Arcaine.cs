using UnityEngine;
using System.Collections;

public class Arcaine : MonoBehaviour {

    Animator animator;

    // Use this for initialization
    void Start ()
    {
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
	   
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            animator.SetBool("death", true);
            //animator.Play("ArcainePickUp");
            //Invoke("ArcainePickedUp", 1);
            //animator.SetTrigger("death");
            //animator.GetBool("death");
            //GetComponent<Animation>().
            GameObject.Destroy(this.gameObject);
        }
    }
}
