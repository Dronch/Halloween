using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving : MonoBehaviour {

    enum MovingBehavior
    {
        NoMove,
        Patrol,
        Loop,
        GoForward
    }

    MovingBehavior state = MovingBehavior.NoMove;
    Transform[] mpath;
    public float speed = 0.5f;
    public float reachDist = 0.1f;
    int currentPoint = 0;
    bool waiting = false;
    public float waiting_min = 0;
    public float waiting_max = 4;
    update_lookat ul;

    void Start() {
        ul = GetComponent<update_lookat>();
    }

    void Update() {

        if (waiting)
            return;

        if (state == MovingBehavior.NoMove)
            return;

        if (mpath.Length == 0)
        {
            Stop();
            return;
        }

        if (!ul)
        {
            transform.LookAt(mpath[currentPoint]);
        }

        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, mpath[currentPoint].position, step);
        Vector3 dir = mpath[currentPoint].position - this.gameObject.transform.position;

        if (dir.magnitude <= reachDist)
        {
            if (state == MovingBehavior.Patrol)
            {
                ChooseRandomPoint();
                StartCoroutine(WaitInPatrol());
            }
            else
            {
                currentPoint++;
                if (currentPoint == mpath.Length)
                {
                    if (state == MovingBehavior.GoForward)
                        Stop();
                    else
                        currentPoint = 0;
                }
            }
        }
    }

    IEnumerator WaitInPatrol()
    {
        waiting = true;
        yield return new WaitForSeconds(Random.Range(waiting_min, waiting_max));
        waiting = false;
    }

    void ChooseRandomPoint()
    {
        int i = Random.Range(0, mpath.Length - 1);
        currentPoint = i == currentPoint ? mpath.Length - 1 : i;
    }

    public void Stop()
    {
        state = MovingBehavior.NoMove;
        currentPoint = 0;
        waiting = false;
    }

    public void Go(Transform[] path)
    {
        state = MovingBehavior.GoForward;
        mpath = path;
        currentPoint = 0;
        waiting = false;
    }

    public void Go(Transform point)
    {
        Transform[] route = new Transform[1];
        route[0] = point;
        Go(route);
    }

    public void Patrol(Transform[] path)
    {
        state = MovingBehavior.Patrol;
        mpath = path;
        ChooseRandomPoint();
        waiting = false;
    }

    public void Loop(Transform[] path)
    {
        state = MovingBehavior.Loop;
        mpath = path;
        currentPoint = 0;
        waiting = false;
    }
}
