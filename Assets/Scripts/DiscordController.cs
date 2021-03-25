using UnityEngine;
using System;
public class DiscordController : MonoBehaviour
{
    public Discord.Discord discord;
    // Start is called before the first frame update
    void Start()
    {
        Inicialize();
    }
   void Inicialize()
    {
        //Debug.Log("Discord Status Started ");
        discord = new Discord.Discord(816815784432107540, (UInt64)Discord.CreateFlags.Default);
        var activityManager = discord.GetActivityManager();
        var activity = new Discord.Activity
        {
            State = "Running Infinite",
        };
        activityManager.UpdateActivity(activity, (res) => {
            if (res == Discord.Result.Ok)
                Debug.Log("Discord Status set");
            else
                Debug.LogError("Discord Status Failed");
        });

    }
    static void UpdatePresence()
    {

    }
    private void Awake()
    {
        int numDiscordControllers = GameObject.FindGameObjectsWithTag("DiscordController").Length;
        if (numDiscordControllers != 1)
        {
            Destroy(this.gameObject);
        }
        // if more then one music player is in the scene
        //destroy ourselves
        else
        {
            DontDestroyOnLoad(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {

        discord.RunCallbacks();
    }


}
