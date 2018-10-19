using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class update_lookat : MonoBehaviour {

    public Transform target;

	void Update () {
        if (target == null)
            return;
        transform.LookAt(target.position);
    }
}
