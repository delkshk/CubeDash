using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    bool gameHasEnded = false;
    public float restartDelay = 2f;
    public GameObject completeLevelUI;
    public GameObject gameOverUI;
    public GameObject PauseUI;

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
    public void ResumeGame()
    {
        Debug.Log("Resume Game");
        GameObject.FindWithTag("PauseScreen").SetActive(false);
        Time.timeScale = 1;
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (PauseUI == null)
            {
                Debug.LogError("No PauseScreen found.");
            }
            else
            {
                    PauseUI.SetActive(true);
                    Time.timeScale = 0;
            }
        }
    }
}
