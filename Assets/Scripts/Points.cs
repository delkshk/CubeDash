using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    public Text scoreText;
    float Score = 0;
    private void Start()
    {
        scoreText = GameObject.FindWithTag("PointsUI").GetComponent<Text>() as Text;
    }
    private void OnTriggerEnter(Collider other)
    {
        Score = float.Parse(scoreText.text) + 10;
        scoreText.text = Score.ToString("0");
        Destroy(gameObject);
    }


}
