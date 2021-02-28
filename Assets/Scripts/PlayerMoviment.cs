using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{

    public Rigidbody rb;
    private float forwardForce = 10000f;
    private float sidewaysForce = 150f;
    private float upForce = 600f;
    public Transform player;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (player.position.y < 2)
        {
            rb.AddForce(0, 0, forwardForce/2 * Time.deltaTime);
            rb.AddForce(0, 0, player.position.y,ForceMode.Force);
        }
        else
        {
            rb.AddForce(0, -upForce * (Time.deltaTime*2), forwardForce/3 * Time.deltaTime);
        }
        
        if (Input.GetKey("d"))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0,0,ForceMode.VelocityChange);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("s"))
        {
            if (player.position.y > 2)
            {
                rb.AddForce(0, -upForce / 12 * Time.deltaTime, 0, ForceMode.Impulse);
            }

        }
        if (rb.position.y < -1)
        {
            FindObjectOfType<GameManager>().EndGame();
        }

    }
    void OnCollisionStay(Collision col )
    {
        if (col.collider.gameObject.tag == "Ground" && Input.GetKey("space"))
        {
            //Debug.Log("No chao");
            rb.AddForce(0, upForce * Time.deltaTime, 0, ForceMode.VelocityChange);

        }
    }
}
