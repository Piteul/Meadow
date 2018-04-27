using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;
    public GameManager gm;
    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    public float saut = 200f;

    bool isGrounded = false;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        gm = FindObjectOfType<GameManager>();

    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground") isGrounded = true;
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Ground") isGrounded = false;
    }

    void FixedUpdate()
    {
        rb.freezeRotation = true;
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (Input.GetKey(KeyCode.D))
        {   //right	
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey(KeyCode.Q))
        {   //left
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey(KeyCode.Space) && isGrounded == true)
        {	//jump
            rb.AddForce(0, saut, 0);
        }

        if (rb.position.y < -1f)
        {
            gm.EndGame();
        }
    }

}



