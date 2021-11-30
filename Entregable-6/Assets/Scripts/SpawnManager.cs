using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject prefab;
    public Vector3 spawnPos;
    public int left = 0;
    public int right = 1;
    private Quaternion roffset = Quaternion.Euler(0, 180, 0);

    public float randomY;
    private int randomX;

    public float startDelay = 0.5f;
    public float repeatRate = 2f;

    private PlayerController playerControllerScript;

    
    void Start()
    {
        InvokeRepeating("SpawnRandom", startDelay, repeatRate);

        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }


    public void SpawnRandom()
    {

        if (!playerControllerScript.gameOver)
        {
            randomX = Random.Range(0, 2);
            randomY = Random.Range(2, 14);


            if (randomX == left)
            {
                spawnPos = new Vector3(-13, randomY, 0);
                Instantiate(prefab, spawnPos, prefab.transform.rotation);
            }

            if (randomX == right)
            {
                spawnPos = new Vector3(13, randomY, 0);
                Instantiate(prefab, spawnPos, prefab.transform.rotation * roffset);
            }
        }

    }

}
