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
        Instantiate(platformPrefab, new Vector2(131.52f, -30.43f), platformPrefab.transform.rotation);
        Instantiate(platformPrefab, new Vector2(137.47f, -30.43f), platformPrefab.transform.rotation);
        Instantiate(platformPrefab, new Vector2(143.46f, -30.43f), platformPrefab.transform.rotation);
        Instantiate(platformPrefab, new Vector2(149.54f, -30.43f), platformPrefab.transform.rotation);
        Instantiate(platformPrefab, new Vector2(155.5f, -30.43f), platformPrefab.transform.rotation);
        Instantiate(platformPrefab, new Vector2(210.64f, -30.43f), platformPrefab.transform.rotation);
        Instantiate(platformPrefab, new Vector2(216.06f, -29.62f), platformPrefab.transform.rotation);
        Instantiate(platformPrefab, new Vector2(220.97f, -31.83f), platformPrefab.transform.rotation);
        Instantiate(platformPrefab, new Vector2(226.16f, -31.25f), platformPrefab.transform.rotation);
        Instantiate(platformPrefab, new Vector2(232.31f, -31.25f), platformPrefab.transform.rotation);
        Instantiate(platformPrefab, new Vector2(237.61f, -29.58f), platformPrefab.transform.rotation);
        Instantiate(platformPrefab, new Vector2(244.78f, -33.22f), platformPrefab.transform.rotation);
        Instantiate(platformPrefab, new Vector2(251.11f, -33.22f), platformPrefab.transform.rotation);
        Instantiate(platformPrefab, new Vector2(256.94f, -37.36f), platformPrefab.transform.rotation);
        Instantiate(platformPrefab, new Vector2(261.18f, -35.84f), platformPrefab.transform.rotation);
        Instantiate(platformPrefab, new Vector2(267.25f, -39.02f), platformPrefab.transform.rotation);
        Instantiate(platformPrefab, new Vector2(271.87f, -37.43f), platformPrefab.transform.rotation);
        Instantiate(platformPrefab, new Vector2(278.99f, -39.78f), platformPrefab.transform.rotation);
        Instantiate(platformPrefab, new Vector2(286.72f, -42.36f), platformPrefab.transform.rotation);

    }

    IEnumerator SpawnPlatform(Vector2 spawnPosition)
    {
        yield return new WaitForSeconds(2f);
        Instantiate(platformPrefab, spawnPosition, platformPrefab.transform.rotation);
    }
}
