using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeskin_animations : MonoBehaviour
{
    public Vector3 oldEulerAngles;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

        oldEulerAngles = new Vector3(Player.transform.rotation.x, 0, Player.transform.rotation.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (oldEulerAngles == Player.transform.rotation.eulerAngles)
        {
            //NO ROTATION
        }
        else
        {
            //oldEulerAngles = Player.transform.rotation.eulerAngles;
            //DO WHATEVER YOU WANT
            //Debug.Log("Lets Roolll");
        }
    }
}
