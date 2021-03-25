
using GameJolt.API;
using GameJolt.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject hs_text;
    public Text hs_value;
    public GameObject ConfigScreenUI;
    public GameObject WelcomeScreenUI;
 
    // Start is called before the first frame update
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitou do game");
    }
    public void ConfigScreen()
    {
        ConfigScreenUI.SetActive(true);
        WelcomeScreenUI.SetActive(false);

        Debug.Log("Abriu as configs");

    }
    public void ReturnToHome()
    {

        ConfigScreenUI.SetActive(false);
        WelcomeScreenUI.SetActive(true);
    }

    public void ShowLeaderboard()
    {
        GameJoltUI.Instance.ShowLeaderboards();
    }
    public void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "Menu")
        {
            if (PlayerPrefs.GetFloat("HS_Distance") > 0)
            {
                hs_text.SetActive(true);
                hs_value.text = PlayerPrefs.GetFloat("HS_Distance").ToString("0");
            }
           
        }
        // Volume Configs

        if (PlayerPrefs.HasKey("config_volumeMusic"))
        {
            GameObject CameraObj = GameObject.FindGameObjectWithTag("MainCamera");
            CameraObj.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("config_volumeMusic");
            //Debug.Log(CameraObj.GetComponent<AudioSource>().volume);
        }
    }
}
