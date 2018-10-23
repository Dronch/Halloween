using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pumpcin_handler : MonoBehaviour {

    AudioSource audioSource;
    bool isCat = false;
    Renderer r;
    public GameObject cat;
    public AudioClip mew;
    public AudioClip[] joke;

    private float nextActionTime = 0.0f;
    public float period = 30.0f;

    private void Update()
    {
        if (Time.time > nextActionTime)
            Action();
    }

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        r = GetComponent<Renderer>();
    }

    public void Say(AudioClip c)
    {
        audioSource.PlayOneShot(c);
        nextActionTime += period;
    }

    public void Action () {
        nextActionTime += period;

        if (isCat)
        {
            audioSource.PlayOneShot(mew);
            return;
        }
        if (!audioSource.isPlaying && joke.Length > 0)
            audioSource.PlayOneShot(joke[Random.Range(0, joke.Length)]);
    }

    public void Swap()
    {
        isCat = !isCat;
        r.enabled = !isCat;
        cat.SetActive(isCat);
    }
}
