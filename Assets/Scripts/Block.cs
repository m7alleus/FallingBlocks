using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    float screenHalfHeightInWorldUnits;
    float screenLimitBottom;
    float halfBlockHeight;

    public Vector2 speedRange;
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = Mathf.Lerp(speedRange.x, speedRange.y, Difficulty.GetDifficultyPercent());
        screenHalfHeightInWorldUnits = Camera.main.orthographicSize;
        halfBlockHeight = transform.localScale.y / 2f;
        screenLimitBottom = -screenHalfHeightInWorldUnits - halfBlockHeight;
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime, Space.Self);

        // Delete block once it's out of the screen
        if(transform.position.y < screenLimitBottom)
        {
            Destroy(gameObject);
        }
    }
}
