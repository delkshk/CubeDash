using UnityEngine;
using UnityEngine.UI;
using GameJolt.API;
public class DistanceScore : MonoBehaviour
{
    public Transform player;
    public Text scoreText;
    public GameObject HS_Distance__text;
    private float HS_Distance;
    void Start()
    {
        HS_Distance = PlayerPrefs.GetFloat("HS_Distance");
        PublishHs();



    }
    private void PublishHs()
    {
        if (HS_Distance > 0)
        {
            var isSignedIn = GameJoltAPI.Instance.CurrentUser != null;

            int scoreValue = (int)HS_Distance; // The actual score.
            string scoreText = scoreValue + " m"; // A string representing the score to be shown on the website.
            int tableID = 602954; // Set it to 0 for main highscore table.
            string extraData = ""; // This will not be shown on the website. You can store any information.
           

            if (isSignedIn)
            {
                GameJolt.API.Scores.Add(scoreValue, scoreText, tableID, extraData, (bool success) => {
                    Debug.Log(string.Format("Score Add {0}.", success ? "Successful" : "Failed"));
                });
            }
            else
            {
                string guestName = PlayerPrefs.GetString("User_NickName") + "_" + PlayerPrefs.GetInt("User_Tag");
                GameJolt.API.Scores.Add(scoreValue, scoreText, guestName, tableID, extraData, (bool success) => {
                    Debug.Log(string.Format("Score Add {0}.", success ? "Successful" : "Failed"));
                });
            }


        }
    }
    void Update()
    {
        scoreText.text = player.position.z.ToString("0") + " m";
        if (player.position.z >= HS_Distance)
        {
            PlayerPrefs.SetFloat("HS_Distance", player.position.z);
            HS_Distance__text.SetActive(true);
        }

    }
}
