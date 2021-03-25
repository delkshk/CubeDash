using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    bool gameHasEnded = false;
    public float restartDelay = 2f;
    public GameObject completeLevelUI;
    public GameObject gameOverUI;
    public GameObject PauseUI;
    public Slider VolumeSlider;
    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
    }
    void Start()
    {
        VolumeSlider.onValueChanged.AddListener(delegate { ChangeVolumeInGame(); });
        if (PlayerPrefs.HasKey("config_volumeMusic"))
        {
            GameObject CameraObj = GameObject.FindGameObjectWithTag("MainCamera");
            CameraObj.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("config_volumeMusic");
            //Debug.Log(CameraObj.GetComponent<AudioSource>().volume);
        }
    }
    public void EndGame()
    {
        
        if(gameHasEnded == false)
        {
            //AddPoinst();
            gameHasEnded = true;
            gameOverUI.SetActive(true);

            Invoke("Restart", restartDelay);
        }

    }
    public void AddPoinst()
    {
        if (PlayerPrefs.HasKey("Total_Money"))
        {
            PlayerPrefs.SetInt("Total_Money", PlayerPrefs.GetInt("Total_Money") + (int)Points.Score);
        }
        else
        {
            PlayerPrefs.SetInt("Total_Money", (int)Points.Score);
        }

        //Debug.Log(PlayerPrefs.GetInt("Total_Money"));
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
                    VolumeSlider.value = PlayerPrefs.GetFloat("config_volumeMusic");
            }
        }
    }
    public void ChangeVolumeInGame()
    {

        float volume = VolumeSlider.value;
        //Debug.Log(volume);
        PlayerPrefs.SetFloat("config_volumeMusic", volume);
        GameObject CameraObj = GameObject.FindGameObjectWithTag("MainCamera");
        CameraObj.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("config_volumeMusic");
    }
}
