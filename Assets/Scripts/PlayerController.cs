using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 10.0f;
    private Rigidbody2D rb;
    private Vector2 direction;
    private ParticleSystem _plume;
    private AudioSource _source;
    private bool fadeOutEnabled = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _plume = GetComponent<ParticleSystem>();
        _source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeOutEnabled)
        {
            if (_source.volume <= 0.05f)
            {
                _source.Stop();
                fadeOutEnabled = false;
            }
            else
            {
                float newVolume = _source.volume - (0.5f * Time.deltaTime);  //change 0.01f to something else to adjust the rate of the volume dropping
                if (newVolume < 0f)
                {
                    newVolume = 0f;
                }
                _source.volume = newVolume;
            }
        }

        float directionY = Input.GetAxisRaw("Vertical");
        if(directionY <= 0){
            directionY = -0.5f;
        }
        direction = new Vector2(0, directionY).normalized;

        if (Input.GetKeyDown(KeyCode.W)){
            _plume.Play();
            _source.volume = 0.2f;
            _source.Play();
            this.fadeOutEnabled = false;
        }
        if (Input.GetKeyUp(KeyCode.W)){
            _plume.Stop();
            this.fadeOutEnabled = true;
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(direction * speed, ForceMode2D.Impulse);
    
    }
}
