using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallex : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform cameraTransform;
    private float startPos;
    private float length;
    private float textureUnitsizex;

    public float parallexEffect;
    void Start()
    {
        cameraTransform = Camera.main.transform;
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
       
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float temp = cameraTransform.position.x * (1 - parallexEffect);
        float deltaMovement = cameraTransform.position.x * parallexEffect;
        transform.position = new Vector3(startPos + deltaMovement, transform.position.y , transform.position.z);
        if(temp > startPos + length)
        {
            startPos += length;
        }
        if(temp < startPos - length)
        {
            startPos -= length;
        }
        
    }
}
