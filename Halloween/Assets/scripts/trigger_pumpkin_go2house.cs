using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger_pumpkin_go2house : MonoBehaviour {

    public GameObject house;
    public GameObject pumpkin;
    public Transform zeroPoint;

    moving pumpkin_move;
    update_lookat pumpkin_lookat;

    private void Start()
    {
        pumpkin_move = pumpkin.GetComponent<moving>();
        pumpkin_lookat = pumpkin.GetComponent<update_lookat>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MainCamera")
        {
            house.SetActive(true);
            pumpkin_move.speed = 4;
            pumpkin_lookat.target = house.transform;
            pumpkin_move.Go(zeroPoint);
            this.gameObject.SetActive(false);
        }
    }
}
