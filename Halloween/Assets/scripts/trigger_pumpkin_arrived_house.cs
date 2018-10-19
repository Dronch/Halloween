using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger_pumpkin_arrived_house : MonoBehaviour {

    public GameObject pumpkin;

    private void OnTriggerEnter(Collider other)
    {
        pumpkin.GetComponent<update_lookat>().target = Camera.main.transform;
        gameObject.SetActive(false);
    }
}
