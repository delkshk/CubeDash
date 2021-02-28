using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public Transform player;
    public Text scoreText;
    public GameObject HS_Distance__text;
    private float HS_Distance;
    void Start()
    {
        HS_Distance = PlayerPrefs.GetFloat("HS_Distance");
    }
    void Update()
    {
        scoreText.text = player.position.z.ToString("0");
        if (player.position.z >= HS_Distance)
        {
            PlayerPrefs.SetFloat("HS_Distance", player.position.z);
            HS_Distance__text.SetActive(true);
        }

    }
}
