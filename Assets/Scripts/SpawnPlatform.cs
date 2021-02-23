using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform : MonoBehaviour
{

    public List<GameObject> platforms = new List<GameObject>();
    public List<Transform> currentPlatforms = new List<Transform>();
    public int offset;
    private int offsetAppend = 280;

    private Transform player;
    public Transform currentPlatformPoint;
    private int PlatformIndex = 0;
    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        for (int i = 0; i < platforms.Count; i++) {
            Transform p = Instantiate(platforms[i],new Vector3(0,0,i*offsetAppend), transform.rotation).transform;
            currentPlatforms.Add(p);
            offset += offsetAppend;
        }
        currentPlatformPoint = currentPlatforms[PlatformIndex].GetComponent<Platform>().point;
    }
    void Update()
    {
        distance = player.position.z - currentPlatformPoint.position.z;
        if (distance >= 2)
        {
            Recycle(currentPlatforms[PlatformIndex].gameObject);
            PlatformIndex++;
            // Reset no index pra nao quebrar
            if (PlatformIndex >= platforms.Count)
            {
                PlatformIndex = 0;
               
            }
            currentPlatformPoint = currentPlatforms[PlatformIndex].GetComponent<Platform>().point;

        }
    }
    public void Recycle(GameObject platform)
    {
        //platform.transform.position = new Vector3(0, 0, offset);
        Transform p = Instantiate(platforms[PlatformIndex], new Vector3(0, 0, (float)(offset + 0.01)), transform.rotation).transform;
        currentPlatforms.Add(p);
        //
        Destroy(currentPlatforms[PlatformIndex].gameObject);
        currentPlatforms.RemoveAt(PlatformIndex);
        offset += offsetAppend;
        print(currentPlatforms);
        //
    }
}
