using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoLift : MonoBehaviour
{
    private Vector2 startPosition;
    private Vector2 newPosition;
    public int speed;
    public int maxDistance;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        newPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        newPosition.y = startPosition.y + (maxDistance * Mathf.Sin(Time.time * speed));
        transform.position = newPosition;
    }
}
