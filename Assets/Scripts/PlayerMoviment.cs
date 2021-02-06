using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{

    public Rigidbody rb;
    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    public Transform player;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (player.position.y < 2)
        {
            rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        }
        else
        {
            rb.AddForce(0, 0, forwardForce/4 * Time.deltaTime);
        }
        
        if (Input.GetKey("d"))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0,0,ForceMode.VelocityChange);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if(rb.position.y < -1)
        {
            FindObjectOfType<GameManager>().EndGame();
        }

    }
}
