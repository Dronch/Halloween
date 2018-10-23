using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class object_handler : MonoBehaviour {

    public AudioClip ac;
    public bool animate;
    public GameObject onCreate;
    AudioSource audioSource;
    Animator animator;

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	public void Action () {
        if (ac && audioSource)
            if (!audioSource.isPlaying)
                audioSource.PlayOneShot(ac);
        if (animate && animator)
            animator.SetTrigger("Action");
        if (onCreate)
            Instantiate(onCreate, transform.position, transform.rotation);
    }
}
