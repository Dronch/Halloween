using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class child_eat : MonoBehaviour {

    public AudioClip ac;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "cake")
        {
            other.gameObject.SetActive(false);
            if (!audioSource.isPlaying)
                audioSource.PlayOneShot(ac);
        }
    }

}
