using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gameplay_UiControl : MonoBehaviour
{
    public Transform Player;
    public GameObject QButton;
    public GameObject SPACEButton;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (Player.position.y < 2)
        {
            QButton.SetActive(true);
            SPACEButton.SetActive(true);
        }
        else
        {
            QButton.SetActive(false);
            SPACEButton.SetActive(false);
        }
    }
}
