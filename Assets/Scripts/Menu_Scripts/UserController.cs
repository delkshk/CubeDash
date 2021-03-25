using GameJolt.API;
using GameJolt.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserController : MonoBehaviour
{
    public GameObject CreateUserMsg;
    public GameObject LoggedMsg;
    public GameObject LoginBtn;
    public GameObject PlayButton;
    public Text LOGADO_Username;
    public Image LOGADO_AVATAR;
    public InputField NickNameInput;
    public Text NickTag;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("MontaSistemaLogin", 1);//this will happen after 2 seconds

        //PlayerPrefs.SetString("User_NickName", NickNameInput.text);
    }

    [System.Obsolete]
    void MontaSistemaLogin()
    {
        var isSignedIn = GameJoltAPI.Instance.CurrentUser != null;

        PlayButton.SetActive(true);
        if (!isSignedIn)
        {
            CreateUserMsg.SetActive(true);
            LoggedMsg.SetActive(false);
            LoginBtn.SetActive(true);
            //Cria a TAG
            if (!PlayerPrefs.HasKey("User_Tag"))
            {
                PlayerPrefs.SetInt("User_Tag", (int)Random.Range(1000, 9999));
            }
            //NickEditavel
            if (!PlayerPrefs.HasKey("User_NickName"))
            {
                NickNameInput.text = "Guest";
                PlayerPrefs.SetString("User_NickName", "Guest");
                NickTag.text = "#" + PlayerPrefs.GetInt("User_Tag").ToString("0");
            }
            else
            {
                NickNameInput.text = PlayerPrefs.GetString("User_NickName");
                NickTag.text = "#" + PlayerPrefs.GetInt("User_Tag").ToString("0");
            }
        }
        else
        {
            CreateUserMsg.SetActive(false);
            LoggedMsg.SetActive(true);
            LoginBtn.SetActive(false);
            LOGADO_Username.text = GameJoltAPI.Instance.CurrentUser.Name;
            StartCoroutine(loadSpriteImageFromUrl(GameJoltAPI.Instance.CurrentUser.AvatarURL, LOGADO_AVATAR));
        }


    }

    [System.Obsolete]
    IEnumerator loadSpriteImageFromUrl(string URL,Image imageToDisplay)
    {
        GameJoltAPI.Instance.CurrentUser.DownloadAvatar();
        WWW www = new WWW(URL);
        while (!www.isDone)
        {
            //Debug.Log("Download image on progress" + www.progress);
            yield return null;
        }

        if (!string.IsNullOrEmpty(www.error))
        {
            Debug.Log("Download profile picture failed");
        }
        else
        {
            Debug.Log("Download profile picture succes");
            Texture2D texture = new Texture2D(1, 1);
            www.LoadImageIntoTexture(texture);

            Sprite sprite = Sprite.Create(texture,
                new Rect(0, 0, texture.width, texture.height), Vector2.zero);

            imageToDisplay.sprite = sprite;
        }
    }
    // Update is called once per frame
    void Update()
    {
    }

    public void NickNameSaver()
    {
        string NameString = NickNameInput.text;
        PlayerPrefs.SetString("User_NickName", NameString);
    }

    [System.Obsolete]
    public void CreateAccount()
    {
        GameJoltUI.Instance.ShowSignIn(
         (bool signInSuccess) => {
             Debug.Log(string.Format("Sign-in {0}", signInSuccess ? "successful" : "failed or user's dismissed the window"));
             if (signInSuccess)
             {
                 CreateUserMsg.SetActive(false);
                 LoggedMsg.SetActive(true);
                 LoginBtn.SetActive(false);
             }
         },
         (bool userFetchedSuccess) => {
             Debug.Log(string.Format("User details fetched {0}", userFetchedSuccess ? "successfully" : "failed"));
             if (userFetchedSuccess)
             {
                 LOGADO_Username.text = GameJoltAPI.Instance.CurrentUser.Name;
                 StartCoroutine(loadSpriteImageFromUrl(GameJoltAPI.Instance.CurrentUser.AvatarURL, LOGADO_AVATAR));
             }

         });
    }

    [System.Obsolete]
    public void Loggof()
    {
        var isSignedIn = GameJoltAPI.Instance.CurrentUser != null;
        if (isSignedIn)
        {
            GameJoltAPI.Instance.CurrentUser.SignOut();
            MontaSistemaLogin();
        }
    }
}
