using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int speed = 6;
    public event System.Action OnPlayerDeath;
    
    public bool invincibility = false;
    public float invincibilityTimer = 2f;
    float invincibilityInterval;

    float screenHalfWidthInWorldUnits;
    Vector3 velocity;
    SpriteRenderer sprite;

    void Start()
    {
        invincibilityInterval = invincibilityTimer;
        sprite = GetComponent<SpriteRenderer>();
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize;
        GameObject invincibilityCircle = GameObject.Find("InvincibilityCircle");
        invCircleScale = invincibilityCircle.transform.localScale;
    }

    void Update()
    {
        HandleInvincibilityState();

        // Compute velocity
        Vector3 inputX = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
        Vector3 direction = inputX.normalized;
        velocity = direction * speed;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnTriggerEnter2D(Collider2D triggerCollider)
    {
        if (triggerCollider.tag == "Block" && !invincibility)
        {
            if(OnPlayerDeath != null)
            {
                OnPlayerDeath();
            }
            Destroy(gameObject);
        }
        else if (triggerCollider.tag == "InvincibilityBonus")
        {
            invincibility = true;
        }
    }

    private void Move()
    {
        float halfPlayerWidth = transform.localScale.x / 2f;
        float screenLimitRight = screenHalfWidthInWorldUnits + halfPlayerWidth;
        float screenLimitLeft = -screenHalfWidthInWorldUnits - halfPlayerWidth;

        transform.position += velocity * Time.fixedDeltaTime;
        if (transform.position.x > screenLimitRight)
        {
            transform.position = new Vector3(screenLimitLeft, transform.position.y, 0);
        }
        else if (transform.position.x < screenLimitLeft)
        {
            transform.position = new Vector3(screenLimitRight, transform.position.y, 0);
        }
    }

    Vector3 invCircleScale;

    private void HandleInvincibilityState()
    {
        if (invincibilityTimer <= 0)
        {
            invincibility = false;
            invincibilityTimer = invincibilityInterval;
        }

        GameObject invincibilityCircle = GameObject.Find("InvincibilityCircle");
        float invincibilityCircleSizePercent = Mathf.Clamp01(invincibilityTimer / invincibilityInterval);

        if (invincibility)
        {
            invincibilityTimer -= Time.deltaTime;
            // display circle
            invincibilityCircle.GetComponent<Renderer>().enabled = true;
            invincibilityCircle.transform.localScale = invCircleScale * invincibilityCircleSizePercent;
        }
        else
        {
            // hide circle
            invincibilityCircle.GetComponent<Renderer>().enabled = false;
            //invincibilityCircle.transform.localScale = 1;
        }
    }
}
