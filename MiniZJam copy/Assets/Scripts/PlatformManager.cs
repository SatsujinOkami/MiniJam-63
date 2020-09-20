using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public static PlatformManager instance = null;

        [SerializeField]
    GameObject platformPrefab;

     void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }


     void Start()
    {
        Instantiate(platformPrefab, new Vector2(8.878319f, -3.368502f), platformPrefab.transform.rotation);
        Instantiate(platformPrefab, new Vector2(14.77831f, -3.368502f), platformPrefab.transform.rotation);
        Instantiate(platformPrefab, new Vector2(20.94831f, -3.368502f), platformPrefab.transform.rotation);
        Instantiate(platformPrefab, new Vector2(26.94831f, -3.368502f), platformPrefab.transform.rotation);
        Instantiate(platformPrefab, new Vector2(32.89831f, -3.368502f), platformPrefab.transform.rotation);

    }

    IEnumerator SpawnPlatform(Vector2 spawnPosition)
    {
        yield return new WaitForSeconds(2f);
        Instantiate(platformPrefab, spawnPosition, platformPrefab.transform.rotation);
    }
}
