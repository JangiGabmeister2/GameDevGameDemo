using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Player speed
    public float moveSpeed = 10f;
    // Component reference to be able to move and collide 
    public Rigidbody rb;
    // Start is called before the first frame update
    public bool invertXControls = false;
    public bool invertZControls = false;
    public bool speedBoost = false;
    public float boostCountDown = 1;
    public AudioClip bounceSound;
    public AudioClip speedSound;
    public AudioClip pickupSound;

    void Start()
    {
        // Assigns rb variable to the rigidbody component that is attached to the model that this script is on
        rb = GetComponent<Rigidbody>();
    }
    public void Move(float inputV, float inputH)
    {
        // Get input from user into 'inputDirection' 
        Vector3 inputDirection = new Vector3(inputV, 0, inputH) * moveSpeed;
        // Convert inputDirection from worldspace to localspace and store in 'direction' variable
        Vector3 direction = transform.TransformDirection(inputDirection);
        // Copy rigid.velocity to 'velocity' vector
        Vector3 velocity = rb.velocity;

        if (invertXControls)
        {
            direction.x = -direction.x;
        }

        if (invertZControls)
        {
            direction.z = -direction.z;
        }

        // Applies velocity to rigid velocity
        rb.velocity = new Vector3(direction.x, velocity.y, direction.z);
    }
    // Update is called once per frame
    void Update()
    {
        // Get input from user
        // Up and down
        float inputH = Input.GetAxis("Horizontal");
        // Left and right
        float inputV = Input.GetAxis("Vertical");
        // Get character to move
        Move(inputV, -inputH);

        // Is player speedboosting?
        if (speedBoost == true)
        {
            // Boost countdown begins
            boostCountDown -= Time.deltaTime;
        }
        // If player has ended boost
        if (boostCountDown <= 0)
        {
            //Boost stops and speed returns to normal
            speedBoost = false;
            moveSpeed = 10;
        }

        // If player falls below killzone, restart scene
        if (transform.position.y <= -10)
        {
            GameManager.instance.Restart();
        }

    }
    // Player bounce
    public void Bounce(float upSpeed)
    {
        rb.velocity = new Vector3(rb.velocity.x, upSpeed, rb.velocity.z);
        //AudioManager.audioInstance.sfxAudio.PlayOneShot(bounceSound);
    }
    // What happens when the player is boosting?
    public void Speed()
    {
        boostCountDown = 0.5f;
        speedBoost = true;
        moveSpeed = 20;
        //AudioManager.audioInstance.sfxAudio.PlayOneShot(speedSound);
    }
    public void Key()
    {
        //AudioManager.audioInstance.sfxAudio.PlayOneShot(pickupSound);
    }

    public void InvertXControls()
    {
        invertXControls = !invertXControls;
    }
    public void InvertZControls()
    {
        invertZControls = !invertZControls;
    }
}
