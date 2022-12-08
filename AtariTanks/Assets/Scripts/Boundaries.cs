using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 clampedPos = new Vector2(
    Mathf.Clamp(transform.position.x, -9, 9),
    Mathf.Clamp(transform.position.y, -4, 4));

        transform.position = clampedPos;
    }
}
