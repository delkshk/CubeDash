using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    bool gameHasEnded = false;
    public float restartDelay = 2f;
    public GameObject completeLevelUI;
    public GameObject gameOverUI;
    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
    }
    public void EndGame()
    {
        
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            gameOverUI.SetActive(true);
            Invoke("Restart", restartDelay);
        }

    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
