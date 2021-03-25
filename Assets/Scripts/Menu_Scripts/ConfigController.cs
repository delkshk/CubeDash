using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ConfigController : MonoBehaviour
{
    public GameObject VolumeSlider;
    public GameObject SkinSlider;
    // Start is called before the first frame update


    void Start()
    {
        StartConfig(VolumeSlider, "config_volumeMusic");
        StartConfig(SkinSlider, "skin_atual");
    }
    void StartConfig(GameObject Slider,string Key)
    {
        if (PlayerPrefs.HasKey(Key))
        {
            Slider.GetComponent<Slider>().value = PlayerPrefs.GetFloat(Key);
        }
    }
    void SaveConfigs(GameObject Slider, string Key)
    {
        PlayerPrefs.SetFloat(Key, Slider.GetComponent<Slider>().value);
    }
    public void SalvaConfigs()
    {
        SaveConfigs(VolumeSlider, "config_volumeMusic");
        SaveConfigs(SkinSlider, "skin_atual");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ResetaHS()
    {
        Debug.Log("Resetou HS");
        PlayerPrefs.DeleteAll();
    }
}
