using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfigController : MonoBehaviour
{
    public GameObject VolumeSlider;
    // Start is called before the first frame update


    void Start()
    {
        if (PlayerPrefs.HasKey("config_volumeMusic"))
        {
            VolumeSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("config_volumeMusic");
        }
    }
    public void SalvaConfigs()
    {
        PlayerPrefs.SetFloat("config_volumeMusic", VolumeSlider.GetComponent<Slider>().value);
    }
    public void ResetaHS()
    {
        Debug.Log("Resetou HS");
        PlayerPrefs.SetFloat("HS_Distance", 0);
    }
}
