using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving_once : MonoBehaviour {

    public float speed = 1.0f;
    public float length = 10.0f;
    Vector3 start;
    Vector3 target;

    // Use this for initialization
    void Start()
    {
        start = transform.position;
        target = length * Vector3.up + transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);
        Vector3 dir = target - transform.position;
        if (dir.magnitude <= 0.1f)
            Destroy(gameObject);
    }
}
