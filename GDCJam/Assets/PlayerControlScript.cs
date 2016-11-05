using UnityEngine;
using System.Collections;

public class PlayerControlScript : MonoBehaviour
{
    public Vector2 speed = new Vector2(50, 50);

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

        Vector3 movement = new Vector3(speed.x * inputX, speed.y * inputY, 0);

        movement *= Time.deltaTime;

        transform.Translate(movement);
    }

}