using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class object_handler : MonoBehaviour {

    public AudioClip ac;
    public bool animate;
    public GameObject onCreate;
    public GameObject receive;
    public GameObject show;
    public AudioClip ac_idle;
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
        if (receive)
            receive.SendMessage("Action");
        if (show)
        {
            show.SetActive(!show.active);
        }
    }

    public void Sound()
    {
        if (ac_idle && audioSource)
            if (!audioSource.isPlaying)
                audioSource.PlayOneShot(ac_idle);
    }
}
