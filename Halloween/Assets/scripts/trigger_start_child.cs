using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger_start_child : MonoBehaviour {

    public Manager manager;
    public GameObject obj;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MainCamera")
        {
            manager.startChild();
            obj.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
}
