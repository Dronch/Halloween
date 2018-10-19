using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light_pulse : MonoBehaviour {

    Light mLight;
    bool mLightUp = true;

    public float minI = 1;

    public float maxI = 6;

    public float deltaI = 0.05f;

    void Start () {
        mLight = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
        if (mLightUp)
        {
            mLight.intensity += deltaI;
            if (mLight.intensity >= maxI)
                mLightUp = false;
        }
        else
        {
            mLight.intensity -= deltaI;
            if (mLight.intensity <= minI)
                mLightUp = true;
        }
	}
}
