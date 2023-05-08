using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalMechanic : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player"){
            Physics2D.IgnoreLayerCollision(6,7,true);
            GameObject.FindGameObjectWithTag("GameController").GetComponent<BackgroundMechanic>().changeTimeline();
            Destroy(this.gameObject);
        }
    }
}
