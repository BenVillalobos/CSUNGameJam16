using UnityEngine;
using System.Collections;

public class PlayerControlScript : MonoBehaviour
{
    public float speed = 0.1f;
    private float time;

    // Use this for initialization
    void Start()
    {
        time = Time.time;
        Debug.Log ("Start");
    }

    void OnTriggerEnter2D (Collider2D coll)
    {
        if (coll.tag == "Bar") {
            Destroy (coll.gameObject.transform.parent.gameObject);
            Debug.Log ("Delete item");
        }
    }

// Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        float dashSpeed = 0.2f;
        float translation = Time.deltaTime*10;

        Vector3 movement = new Vector3(inputX, inputY, 0);

        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation (Vector3.forward, movement);
        }

        transform.position = Vector3.MoveTowards (transform.position, transform.position + movement, speed);

        if (Input.GetButtonDown ("Fire1")) {
            if (Time.time >= time + 1f) {
                //code something
                time = Time.time;
            }
        }
    }
}