using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Obstacles"){
            Destroy(collision.gameObject);
            print("Spawned fuel on obstacle");
        }
        else if(collision.gameObject.tag == "Border"){
            Destroy(this.gameObject);
        }
        else if(collision.tag == "Player"){
            Destroy(this.gameObject);
            GameObject.FindGameObjectWithTag("GameController").GetComponent<ScoreManager>().Refuel();
        }
    }
}
