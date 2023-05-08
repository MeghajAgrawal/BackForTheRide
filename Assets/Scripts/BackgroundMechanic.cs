using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundMechanic : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject background1885;
    public GameObject background1955;
    public GameObject background2015;
    
    public GameObject spawnpoint;
    public static int currentWorld = 0;
    public int nextWorld = 0;

    GameObject[] obstacles;
    
    //UI  ELEMENTS
    public GameObject VisualPanel;
    public Text portalTime;
    void Start()
    {
        SetCurrentWorld();
        nextWorld = Random.Range(0,3);
    }

    // Update is called once per frame
    void Update()
    {
        if(nextWorld == currentWorld)
        {
            nextWorld = Random.Range(0,3);
        }
    }

    public void changeTimeline()
    {
        DisableObstacles();
        DestroyOnScreenObstacles();
        VisualPanel.SetActive(true); 
        if(nextWorld == 0)
        {
            portalTime.text = "Teleporting to 1885";
        }
        else if(nextWorld == 1)
        {
            portalTime.text = "Teleporting to 1955";
        }
        else
        {
            portalTime.text = "Teleporting to 2015";
        }
        Invoke(nameof(changeBackground),2);
    }
    void changeBackground()
    {
        VisualPanel.SetActive(false);
        if(nextWorld == 0)
        {
            background1885.SetActive(true);
            background1955.SetActive(false);
            background2015.SetActive(false);
        }
        else if(nextWorld == 1)
        {
            background1885.SetActive(false);
            background1955.SetActive(true);
            background2015.SetActive(false);
        }
        else
        {
            background1885.SetActive(false);
            background1955.SetActive(false);
            background2015.SetActive(true);
        }
        currentWorld = nextWorld;
        spawnpoint.GetComponent<SpawnController>().updateWorld(currentWorld);
        GameObject.FindGameObjectWithTag("GameController").GetComponent<ScoreManager>().UpdateYearText(currentWorld);
        Invoke(nameof(EnableObstacles),3);
    }
    void DisableObstacles()
    {
        spawnpoint.GetComponent<SpawnController>().IsSpawning = false;
    }
    void EnableObstacles()
    {
        Physics2D.IgnoreLayerCollision(6,7,false);
        spawnpoint.GetComponent<SpawnController>().IsSpawning = true;
    }
    void SetCurrentWorld()
    {
        currentWorld = Random.Range(0,3);
        spawnpoint.GetComponent<SpawnController>().updateWorld(currentWorld);
        setBackground(currentWorld);
    }
    void setBackground(int current)
    {
        if(current == 0)
        {
            background1885.SetActive(true);
            background1955.SetActive(false);
            background2015.SetActive(false);
        }
        else if(current == 1)
        {
            background1885.SetActive(false);
            background1955.SetActive(true);
            background2015.SetActive(false);
        }
        else
        {
            background1885.SetActive(false);
            background1955.SetActive(false);
            background2015.SetActive(true);
        }
        GameObject.FindGameObjectWithTag("GameController").GetComponent<ScoreManager>().UpdateYearText(current);
    }
    void DestroyOnScreenObstacles()
    {
        obstacles = GameObject.FindGameObjectsWithTag("Obstacles");
        foreach(GameObject obstacle in obstacles)
        {
            Destroy(obstacle);
        }
    }
}
