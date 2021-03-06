using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCicle : MonoBehaviour
{
    public Transform player;
    public Material GroundMat;
    public Material ObsMaterial;
    public Material RampMaterial;
    public GameObject MainCamera;
    public bool Day = false;
    public bool DayCicleOn = true;


    //=====================
    public Color ObsColor_1 = new Color(0.8175488f, 0f, 1f, 1f);
    public Color ObsColor_2 = new Color(1f, 0f, 0f, 1f);
    // Start is called before the first frame update
    void Start()
    {
        if (DayCicleOn)
        {
            changeDay();
            InvokeRepeating("changeDay", 60f, 60f);
        }

    }
    void changeColors(Color new_Color, Color Obs_Color)
    {
        RenderSettings.fogColor = new_Color;
        MainCamera.GetComponent<Camera>().backgroundColor = new_Color;
        //GroundMat.color = new_Color;
        //ObsMaterial.color = Obs_Color;
        ObsMaterial.SetColor("_EmissionColor", Obs_Color);
        RampMaterial.SetColor("_EmissionColor", Obs_Color);
    }
    void changeDay()
    {
        if (Day)
        {
            changeColors(Color.white, ObsColor_1);
        }
        else
        {
            changeColors(Color.black, ObsColor_2);
        }
        Day = !Day;
    }
}
