using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int speed = 6;
    public event System.Action OnPlayerDeath;

    float screenHalfWidthInWorldUnits;
    Vector3 velocity;
    
    // Start is called before the first frame update
    void Start()
    {
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 inputX = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
        Vector3 direction = inputX.normalized;
        velocity = direction * speed;
    }

    private void FixedUpdate()
    {
        float halfPlayerWidth = transform.localScale.x / 2f;
        float screenLimitRight  = screenHalfWidthInWorldUnits + halfPlayerWidth;
        float screenLimitLeft = -screenHalfWidthInWorldUnits - halfPlayerWidth;

        transform.position += velocity * Time.fixedDeltaTime;
        if (transform.position.x > screenLimitRight)
        {
            transform.position = new Vector3(screenLimitLeft, transform.position.y, 0);
        }
        else if(transform.position.x < screenLimitLeft)
        {
            transform.position = new Vector3(screenLimitRight, transform.position.y, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D triggerCollider)
    {
        if (triggerCollider.tag == "Block")
        {
            if(OnPlayerDeath != null)
            {
                OnPlayerDeath();
            }
            Destroy(gameObject);
        }
    }
}
