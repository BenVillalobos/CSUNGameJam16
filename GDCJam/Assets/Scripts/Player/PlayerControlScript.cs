using UnityEngine;
using System.Collections;

public delegate void PlayDashDelegate();

public class PlayerControlScript : MonoBehaviour
{
    public float speed = 0.08f;
    public float dashSpeed = 0.4f;
    public float elapsedTime = 0.4f;
    public float dashCooldown = 1f;
    float dashTimer = 0;
    private float time;
    public PlayDashDelegate playDash;
    public GameObject rotatingPart;

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
        dashTimer += Time.deltaTime;
        if (state != PlayerStates.Dying && state != PlayerStates.Dead)
        {
            float inputX = Input.GetAxisRaw ("Horizontal");
            float inputY = Input.GetAxisRaw ("Vertical");

            Vector3 movement = new Vector3 (inputX, inputY, 0);

            if (movement != Vector3.zero) {
                rotatingPart.transform.rotation = Quaternion.LookRotation (Vector3.forward, -movement);
            }

            transform.position = Vector3.MoveTowards (transform.position, transform.position + movement, speed);

            if (Time.time <= time + elapsedTime)
            {
                transform.position = Vector3.MoveTowards (transform.position, transform.position + movement, dashSpeed);
            } else if (state == PlayerStates.Dashing && Time.time >= time + elapsedTime) {
                state = PlayerStates.Normal;
            }

            if ((Input.GetButtonDown("Xbox Right Shoulder Button") || Input.GetButtonDown("Xbox Left Shoulder Button") || Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire3")) && state != PlayerStates.Dashing && dashTimer >= dashCooldown)
            {
                Dash();
                time = Time.time;
                dashTimer = 0;
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