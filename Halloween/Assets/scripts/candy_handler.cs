using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class candy_handler : MonoBehaviour {

    public AudioClip ac;
    public Manager m;

    public void Action()
    {
        if (!m)
            m = GameObject.Find("GameManager").GetComponent<Manager>();
        AudioSource.PlayClipAtPoint(ac, transform.position);
        gameObject.SetActive(false);
        m.gonext();
    }


}
