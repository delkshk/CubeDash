using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinSystem : MonoBehaviour
{
    
    public List<GameObject> Skins;
    private GameObject player;
    private GameObject CurrentSkin;
    private float Select_Skin;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("skin_atual"))
        {
            Select_Skin = PlayerPrefs.GetFloat("skin_atual");
        }
        else
        {
            Select_Skin = 0;
        }

        player = GameObject.FindWithTag("Player");
        CurrentSkin = player.transform.GetChild(0).gameObject;
        ChangeSkin();
    }
    void ChangeSkin()
    {
        GameObject NovaSkin = Instantiate(Skins[(int)Select_Skin], new Vector3(0,0,0), transform.rotation) as GameObject;
        NovaSkin.name = "SKIN";
        Destroy(CurrentSkin);
        NovaSkin.transform.parent = player.transform;
        NovaSkin.transform.localPosition = new Vector3(0, 0, 0);
        CurrentSkin = NovaSkin;
    }

}
