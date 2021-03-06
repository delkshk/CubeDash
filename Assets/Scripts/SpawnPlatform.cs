﻿using System.Collections.Generic;
using UnityEngine;
public class SpawnPlatform : MonoBehaviour
{

    public List<GameObject> platforms = new List<GameObject>();
    public List<Transform> currentPlatforms = new List<Transform>();
    public GameObject StartPlatform;


    public int offset;
    private int offsetAppend = 280;

    private Transform player;
    public Transform currentPlatformPoint;
    private int PlatformIndex = 0;
    private float distance;
    // Start is called before the first frame update
    void Shuffle<T>(List<T> list)
    {
        System.Random random = new System.Random();
        int n = list.Count;
        while (n > 1)
        {
            int k = random.Next(n);
            n--;
            T temp = list[k];
            list[k] = list[n];
            list[n] = temp;
        }
    }

    void Start()
    {
        //START PLATFORM
        //Instantiate(StartPlatform, new Vector3(0, 0, 0), transform.rotation);
        offset += (int)(offsetAppend + 0.05);
        //Start Random
        Shuffle(platforms);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        int posY;
        for (int i = 0; i < platforms.Count; i++) {
            
            if (i == 0)
            {
                posY = (int)(offset + 0.01);
            }
            else
            {
                posY = offset;
            }
            Transform p = Instantiate(platforms[i],new Vector3(0,0, posY), transform.rotation).transform;
            currentPlatforms.Add(p);
            offset += offsetAppend;
            //Debug.Log(offset);
        }
        currentPlatformPoint = currentPlatforms[PlatformIndex].GetComponent<Platform>().point;
    }
    void Update()
    {
        distance = player.position.z - currentPlatformPoint.position.z;
        if (distance >= 3)
        {
            //Recycle(currentPlatforms[PlatformIndex].gameObject);
            CreatePlatform(PlatformIndex);
            //CreatePlatform(currentPlatforms[PlatformIndex].gameObject, PlatformIndex);
            PlatformIndex++;
            // Reset no index pra nao quebrar
            //if (PlatformIndex >= platforms.Count)
            //{
            //    PlatformIndex = 0;
               
            //}
            currentPlatformPoint = currentPlatforms[2].Find("FinalPlatform");
            Destroy(currentPlatforms[0].gameObject);
            currentPlatforms.RemoveAt(0);
        }
    }
    public void Recycle(GameObject platform)
    {
        platform.transform.position = new Vector3(0, 0, (float)(offset + 0.01));
        offset += offsetAppend;

        //
    }
    public void CreatePlatform(int index)
    {
 
        
        GameObject new_p = Instantiate(platforms[Random.Range(0, platforms.Count - 1)], new Vector3(0, 0, (float)(offset + 0.01)), transform.rotation);
        currentPlatforms.Add(new_p.transform);
        offset += offsetAppend;
        //Até aqui funciona

        //Destroy(currentPlatforms[0].gameObject);
        //currentPlatforms.RemoveAt(0);


        //currentPlatforms.Add(new_p);
        //Destroy(currentPlatforms[index].gameObject);
        //currentPlatforms.RemoveAt(index);
        //Transform p = Instantiate(platforms[index], new Vector3(0, 0, (float)(offset + 0.01)), transform.rotation).transform;
        //offset += offsetAppend;
        //currentPlatforms.Add(p);

    }
}
