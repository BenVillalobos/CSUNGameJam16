using UnityEngine;
using System.Collections;

public class PlayerControlScript : MonoBehaviour
{
    public float speed = 0.3f;
    int number = 0;
    // Use this for initialization
    void Start()
    {
    }

// Update is called once per frame
    void Update()
    {
   //     movementVector.x = Input.GetAxis("LeftJoystickX")*movementSpeed;
   //     movementVector.z = Input.GetAxis("LeftJoystickY")*movementSpeed;
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(inputX, inputY, 0);

        if (movement != Vector3.zero) {
            transform.rotation = Quaternion.LookRotation (Vector3.forward, movement);
        }


        transform.position = Vector3.MoveTowards (transform.position, transform.position + movement, speed);
    }

}