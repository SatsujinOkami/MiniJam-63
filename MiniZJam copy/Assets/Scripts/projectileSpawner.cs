using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileSpawner : MonoBehaviour
{
    public GameObject meteorPrefab;
    public float respawnTime = 1.0f;
    public float minX;
    public float maxX;
    public float spawnHeight;

    private void Start()
    {
        StartCoroutine(meteorWave());
    }

    private void spawnMeteor()
    {
        GameObject a = Instantiate(meteorPrefab) as GameObject;
        a.transform.position = new Vector2(Random.RandomRange(minX, maxX),spawnHeight);
    }

    IEnumerator meteorWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnMeteor();
        }
        spawnMeteor();
    }
    
    
}
