using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger_givecandy : MonoBehaviour {

    public AudioClip knock;
    public AudioClip zombie;
    bool ok = false;
    AudioSource audioSource;
    public GameObject hand;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void Action()
    {
        if (ok)
            return;
        ok = true;

        StartCoroutine(GiveCandy());
    }

    IEnumerator GiveCandy()
    {
        audioSource.PlayOneShot(knock);
        yield return new WaitForSeconds(knock.length + 0.5f);

        hand.SetActive(true);
        audioSource.PlayOneShot(zombie);
    }
}
