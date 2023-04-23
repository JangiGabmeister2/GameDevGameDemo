using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    RaycastHit hitInfo;

    public UnityEvent playerFall;

    [Header("Player Movement")]
    public Transform playerChild;
    [Tooltip("The speed the player moves along the x and z axis.")]
    public float moveSpeed = 10f;
    [Tooltip("The force that the player lifts off the ground when jumping.")]
    public float jumpSpeed = 5f;
    [Tooltip("Inverts character controller's upward and downward movement.")]
    public bool invertUpDown = false;
    [Tooltip("Inverts character controller's left and right movement.")]
    public bool invertLeftRight = false;

    bool speedBoost = false;
    float boostCountDown = 1;

    [Header("Sound Management")]
    public AudioClip bounceSound;
    public AudioClip speedSound;
    public AudioClip pickupSound;
    public AudioClip waterSplash;

    void Start()
    {
        // Assigns rb variable to the rigidbody component that is attached to the model that this script is on
        rb = GetComponent<Rigidbody>();
    }
    public void Move(float inputV, float inputH, bool jump)
    {
        // Get input from user into 'inputDirection' 
        Vector3 inputDirection = new Vector3(inputV, 0, inputH) * moveSpeed;
        // Convert inputDirection from worldspace to localspace and store in 'direction' variable
        Vector3 direction = transform.TransformDirection(inputDirection);
        // Copy rigid.velocity to 'velocity' vector
        Vector3 velocity = rb.velocity;

        //inverts forward and backward movement if true
        if (invertUpDown)
        {
            direction.x = -direction.x;
        }

        //inverts left and right movement if true
        if (invertLeftRight)
        {
            direction.z = -direction.z;
        }

        //returns true if a gameobject is directly below player transform
        bool grounded = Physics.Raycast(transform.position, Vector3.down, out hitInfo, 1f);

        if (velocity.y <= 0 && grounded && jump)
        {
            velocity.y = jumpSpeed * 1.5f;
        }
        else if (!grounded && (!jump || velocity.y < 2f))
        {
            velocity += Vector3.up * -jumpSpeed;
        }

        // Applies velocity to rigid velocity
        rb.velocity = new Vector3(direction.x, velocity.y, direction.z);

        //rotates player transform (the child of this) to rotate according to direction of movement
        if (direction != Vector3.zero)
        {
            playerChild.forward = Vector3.Slerp(playerChild.forward, direction, 720);
        }
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
        bool jump = Input.GetButton("Jump");
        Move(inputV, -inputH, jump);

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

    /// <summary>
    /// Inverts character controller's forward and backward movement.
    /// </summary>
    public void InvertXControls()
    {
        invertUpDown = !invertUpDown;
    }

    /// <summary>
    /// Inverts character controller's left and right movement.
    /// </summary>
    public void InvertZControls()
    {
        invertLeftRight = !invertLeftRight;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "WindArea")
        {
            WindArea windArea = other.GetComponent<WindArea>();
            rb.AddForce(windArea.direction * windArea.fanParent.GetComponent<FanToggle>().speed, ForceMode.Force);
        }

        if (other.tag == "Water")
        {
            playerFall.Invoke();
        }
    }
}
