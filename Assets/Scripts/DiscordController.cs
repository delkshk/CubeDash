using UnityEngine;
using System;
public class DiscordController : MonoBehaviour
{
    public Discord.Discord discord;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Discord Status Started ");
        discord = new Discord.Discord(816815784432107540, (UInt64)Discord.CreateFlags.Default);
        var activityManager = discord.GetActivityManager();
        var activity = new Discord.Activity
        {
            Details = "HighScore:",
            State = "Running Infinite",
        };

        activityManager.UpdateActivity(activity,(res)=> {
            if (res == Discord.Result.Ok)
                Debug.Log("Discord Status set");
            else
                Debug.LogError("Discord Status Failed");
        });
    }

    // Update is called once per frame
    void Update()
    {
        discord.RunCallbacks();
    }


}
