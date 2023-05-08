using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject[] obstacle;
    public GameObject fuel;
    public GameObject portal;
    public float maxX, minX, maxY, minY;
    public float obstacleDeltaTime;
    public float fuelDeltaTime;
    public float portalDeltaTime;
    private float obstacleSpawnTime;
    private float fuelSpawnTime = 5f;
    private float portalSpawnTime = 20f;
    public bool IsSpawning = true;
    private int cWorld;

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player") != null){
            if(Time.time > obstacleSpawnTime){
                obstacleSpawnTime = Time.time + obstacleDeltaTime;
                if(IsSpawning)
                {
                    Spawn(obstacle[cWorld]);
                }
            }
            if(Time.time > fuelSpawnTime){
                fuelSpawnTime = Time.time + fuelDeltaTime;
                Spawn(fuel);
            }
            if(Time.time > portalSpawnTime){
                portalSpawnTime = Time.time + portalDeltaTime;
                Spawn(portal);
            }
        }
    }

    void Spawn(GameObject obj){
        Vector3 spawnPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
        Instantiate(obj, transform.position + spawnPosition, transform.rotation);
    }
    
    public void updateWorld(int newWorld)
    {
        cWorld = newWorld;
    }
}
