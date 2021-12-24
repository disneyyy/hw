using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject tile;
    public GameObject reference;
    public GameObject non;
    public GameObject coin;
    public GameObject trap;
    public float timeOffset = 0.4f;
    public float distanceBetweenTiles = 5.0F;
    public float randomValue = 0.6f;
    private Vector3 previousTilePosition;
    private float startTime;
    private Vector3 direction, mainDirection = new Vector3(0, 0, 1), otherDirection = new Vector3(1, 0, 0);
    private bool empty = false;
    // Start is called before the first frame update
    void Start()
    {
        previousTilePosition = reference.transform.position;
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - startTime > timeOffset)
        {
            if (Random.value < randomValue)
                direction = mainDirection;
            else
            {
                Vector3 temp = direction;
                direction = otherDirection;
                mainDirection = direction;
                otherDirection = temp;
            }
            Vector3 spawnPos = previousTilePosition + distanceBetweenTiles * direction;
            startTime = Time.time;
            int R = (int)Random.Range(0, 4);
            if (R == 2)
            {

                if (!empty)
                    if ((int)Random.Range(0, 2) == 1)
                        Instantiate(non, spawnPos, Quaternion.Euler(0, 0, 0));
                    else
                        Instantiate(trap, spawnPos, Quaternion.Euler(0, 0, 0));
                else
                    Instantiate(tile, spawnPos, Quaternion.Euler(0, 0, 0));
                if (!empty)
                    empty = true;
            }
            else if (R == 1)
            {
                Instantiate(coin, spawnPos, Quaternion.Euler(0, 0, 0));
                empty = false;
            }
            else
            {
                Instantiate(tile, spawnPos, Quaternion.Euler(0, 0, 0));
                empty = false;
            }

            previousTilePosition = spawnPos;
        }
    }
}