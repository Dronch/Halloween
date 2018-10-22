using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger_pumpkin_arrived_house : MonoBehaviour {

    public GameObject pumpkin;
    public GameObject house;

    private void OnTriggerEnter(Collider other)
    {
        pumpkin.GetComponent<update_lookat>().target = Camera.main.gameObject.transform.Find("lookingto");
        Camera.main.GetComponent<update_lookat>().target = house.transform;
        gameObject.SetActive(false);
    }
}
