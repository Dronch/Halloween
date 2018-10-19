using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour {

    private float doubleClickTimeLimit = 0.25f;
    DragMouseOrbit camera_dmo;

    protected void Start()
    {
        camera_dmo = Camera.main.gameObject.GetComponent<DragMouseOrbit>();
        StartCoroutine(InputListener());
    }

    // Update is called once per frame
    private IEnumerator InputListener()
    {
        while (enabled)
        { //Run as long as this is activ

            if (Input.GetMouseButtonDown(0))
                yield return ClickEvent();

            yield return null;
        }
    }

    private IEnumerator ClickEvent()
    {
        //pause a frame so you don't pick up the same mouse down event.
        yield return new WaitForEndOfFrame();

        float count = 0f;
        while (count < doubleClickTimeLimit)
        {
            if (Input.GetMouseButtonDown(0))
            {
                DoubleClick();
                yield break;
            }
            count += Time.deltaTime;// increment counter by change in time between frames
            yield return null; // wait for the next frame
        }
    }



    private void DoubleClick()
    {
        if (!camera_dmo.target)
            return;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            hit.transform.gameObject.SendMessage("Action");
        }
    }

}
