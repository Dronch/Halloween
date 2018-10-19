using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger_start_house : MonoBehaviour {

    public Manager manager;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MainCamera")
        {
            manager.startHouse();
            this.gameObject.SetActive(false);
        }
    }
}
