using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class const_V : MonoBehaviour {

    public float speed = 1.0f;
    public float length = 10.0f;
    Vector3 start;
    Vector3 target;
    Renderer r;

    // Use this for initialization
    void Start () {
        start = transform.position;
        target = length * Vector3.down + transform.position;
        r = GetComponent<Renderer>();
        StartCoroutine(init());
    }
	
	// Update is called once per frame
	void Update () {
        if (!r.enabled)
            return;
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);
        Vector3 dir = target - transform.position;
        if (dir.magnitude <= 0.1f)
            StartCoroutine(init());
    }

    IEnumerator init()
    {
        r.enabled = false;
        yield return new WaitForSeconds(Random.Range(0.0f, 0.5f));
        r.enabled = true;
        transform.position = start;
    }
}
