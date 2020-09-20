using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileSpawner : MonoBehaviour
{
    public GameObject meteorPrefab;
    public float respawnTime = 1.0f;

    private void Start()
    {
        StartCoroutine(meteorWave());
    }

    private void spawnMeteor()
    {
        GameObject a = Instantiate(meteorPrefab) as GameObject;
        a.transform.position = new Vector2(Random.RandomRange(352, 535),-14);
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
