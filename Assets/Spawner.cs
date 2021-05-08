using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public List<Transform> spawner;
    public GameObject monster;
    public bool isPlaying = true;
    public float spawnDelay = 1.5f;

    IEnumerator Start()
    {
        while (isPlaying)
        {
            Spawn();

            yield return new WaitForSeconds(spawnDelay);
        }
    }

    private void Spawn()
    {
        int spawnerIndex = Random.Range(0, spawner.Count);
        var spawnerTransform = spawner[spawnerIndex].transform;
        Instantiate(monster, spawnerTransform.position, spawnerTransform.rotation);
    }
}
