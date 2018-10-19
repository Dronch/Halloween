using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour {

	// Use this for initialization
	void Start () {

    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // Create a particle if hit
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                hit.transform.gameObject.SetActive(false);
            }
        }


        int fingerCount = 0;
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
                fingerCount++;

            if (touch.phase == TouchPhase.Began)
            {
                // Construct a ray from the current touch coordinates
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                // Create a particle if hit
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    hit.transform.gameObject.SetActive(false);
                }
            }
        }
        if (fingerCount > 0)
            print("User has " + fingerCount + " finger(s) touching the screen");

    }
}
