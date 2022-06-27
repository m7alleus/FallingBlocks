using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityBonus : MonoBehaviour
{
    float screenHalfHeightInWorldUnits;
    float screenLimitBottom;
    float halfBlockHeight;
    float speed = 7;

    private void Start()
    {
        screenHalfHeightInWorldUnits = Camera.main.orthographicSize;
        halfBlockHeight = transform.localScale.y / 2f;
        screenLimitBottom = -screenHalfHeightInWorldUnits - halfBlockHeight;
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime, Space.Self);

        // Delete block once it's out of the screen
        if (transform.position.y < screenLimitBottom)
        {
            Destroy(gameObject);
        }
    }
}
