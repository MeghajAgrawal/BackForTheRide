using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private GameObject player;
    public GameObject gameOverPanel;
    public GameObject increaseSpeedPanel;
    public Text scoreText;
    public Text fuelText;
    public Text yearText;
    public Text finalScoreText;
    private float scoreCount;
    private float fuelValue = 100;

    public float gameSpeed;
    private float speedIncreaseDeltaTime = 10f;
    private float speedIncreaseTime = 10f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        speedIncreaseTime = 10f;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(gameSpeed * Time.deltaTime, 0, 0);

        if(Time.time > speedIncreaseTime){
            speedIncreaseTime = Time.time + speedIncreaseDeltaTime;
            IncreaseSpeed();
        }

        if(fuelValue <= 0){
            Destroy(player.gameObject);
        }
        if(GameObject.FindGameObjectWithTag("Player") != null){
            fuelValue -= 0.4f*gameSpeed*Time.deltaTime;
            fuelText.text = "Fuel Remaining : "+((int)fuelValue).ToString()+ "%";
            scoreCount += gameSpeed * Time.deltaTime;
            scoreText.text = "Distance Travelled : "+((int)scoreCount).ToString() +"m";
        }
        else{
            EnableGameOverPanel();
        }
    }

    private void EnableGameOverPanel(){
        gameOverPanel.SetActive(true);
        finalScoreText.text = "Final Score : "+((int)scoreCount).ToString();
    }

    public void Restart(){
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit(){
        SceneManager.LoadScene(0);
    }

    public void Refuel(){
        fuelValue = 100;
        print("Fuel Refilled");
    }

    public void IncreaseSpeed(){
        gameSpeed *= 1.2f;
        print("Game Speed Increased to "+gameSpeed);
    }
    public void UpdateYearText(int currentyear)
    {
        if(currentyear == 0)
        {
            yearText.text = "Year : 1885";
        }
        else if(currentyear == 1)
        {
            yearText.text = "Year : 1955";
        }
        else
        {
            yearText.text = "Year : 2015";
        }
    }
}
