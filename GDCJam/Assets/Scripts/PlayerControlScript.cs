using UnityEngine;
using System.Collections;

public delegate void PlayDashDelegate();

public class PlayerControlScript : MonoBehaviour
{
    public float speed = 0.08f;
    public float dashSpeed = 0.1f;
    public float elapsedTime = 0.4f;
    private float time;
    public PlayDashDelegate playDash;

    public enum PlayerStates
    {
        Normal,
        Dashing,
        Dying,
        Dead,
        DogWeed,
        Arcaine
    };

    public PlayerStates state = PlayerStates.Normal;

    // Use this for initialization
    void Start()
    {
        time = Time.time;
        Debug.Log ("Start");
    }

    // Update is called once per frame
    void Update()
    {
        if (state != PlayerStates.Dying && state != PlayerStates.Dead)
        {
            float inputX = Input.GetAxis ("Horizontal");
            float inputY = Input.GetAxis ("Vertical");

            Vector3 movement = new Vector3 (inputX, inputY, 0);

            if (movement != Vector3.zero) {
                transform.rotation = Quaternion.LookRotation (Vector3.forward, movement);
            }

            transform.position = Vector3.MoveTowards (transform.position, transform.position + movement, speed);

            if (Time.time <= time + elapsedTime)
            {
                transform.position = Vector3.MoveTowards (transform.position, transform.position + movement, dashSpeed);
            } else if (state == PlayerStates.Dashing && Time.time >= time + elapsedTime) {
                state = PlayerStates.Normal;
            }

            if ((Input.GetButtonDown("Xbox Right Shoulder Button") || Input.GetButtonDown("Xbox Left Shoulder Button")) && state != PlayerStates.Dashing)
            {
                Dash();
                time = Time.time;
            }

        } else if (state == PlayerStates.Dying) {
            //TODO: Insert death animation here
            state = PlayerStates.Dead;
        }

        Debug.Log (state.ToString ());
    }

    public void Dash()
    {
        playDash();
        state = PlayerStates.Dashing;
    }
}