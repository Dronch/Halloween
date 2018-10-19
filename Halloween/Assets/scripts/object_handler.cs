using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class object_handler : MonoBehaviour {

    public AudioClip ac;
    AudioSource audioSource;

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	public void Action () {
        if (ac)
            audioSource.PlayOneShot(ac);

    }
}
