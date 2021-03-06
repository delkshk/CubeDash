using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{

    public Rigidbody rb;
    private float forwardForce = 12000f;
    private float sidewaysForce = 150f;
    private float upForce = 350f;
    public Transform player;
    // Update is called once per frame
    private void Start()
    {
        //Fix floating skin
        player.rotation = Quaternion.Euler(0, 0, 0);
    }
    void FixedUpdate()
    {
        if (player.position.y < 2)
        {
            rb.AddForce(0, 0, forwardForce/2 * Time.deltaTime);
        }
        else
        {
            rb.AddForce(0, -upForce * (Time.deltaTime*2), forwardForce/2 * Time.deltaTime);
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
                rb.AddForce(0, -upForce / 10 * Time.deltaTime, 0, ForceMode.Impulse);
            }

        }

        if (rb.position.y < -1)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
        if (Input.GetKey("q"))
        {
            if (rb.position.y < 2)
            {
                player.rotation = Quaternion.Euler(0, 0, 0);
            }
        
        }

    }
    void OnCollisionStay(Collision col )
    {
        if (col.collider.gameObject.tag == "Ground")
        {
            if (Input.GetKey("space")){
                //Debug.Log("No chao");
                rb.AddForce(0, upForce * Time.deltaTime, 0, ForceMode.VelocityChange);
            }

        }
    }
}
