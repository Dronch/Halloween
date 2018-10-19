using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pumpcin_handler : MonoBehaviour {

    AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Say(AudioClip c)
    {
        audioSource.PlayOneShot(c);
    }

    public void Action () {
        Debug.Log(123);
	}
}
