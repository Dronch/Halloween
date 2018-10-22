using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

    public GameObject pumpkin;
    moving pumpkin_moving;
    update_lookat pumpkin_lookat;
    pumpcin_handler pumpkin_handler;

    moving camera_moving;
    update_lookat camera_lookat;
    DragMouseOrbit camera_dmo;

    enum stage
    {
        graveyard,
        house
    }

    stage current_stage = stage.graveyard;

    // graveyard
    public AudioClip intro;
    public AudioClip grave_end;
    public GameObject graveyard;
    public Transform patrol_graveyard;
    public Transform zeroPointGraveyard;

    public Transform route2house;

    // house
    public AudioClip about_house;
    public GameObject house;
    public Transform patrool_camera_house;
    public Transform patrol_house;
    public Transform zeroPointHouse;

    void Start () {
        pumpkin_moving = pumpkin.GetComponent<moving>();
        pumpkin_lookat = pumpkin.GetComponent<update_lookat>();
        pumpkin_handler = pumpkin.transform.GetChild(0).GetComponent<pumpcin_handler>();

        camera_dmo = Camera.main.gameObject.GetComponent<DragMouseOrbit>();
        camera_moving = Camera.main.gameObject.GetComponent<moving>();
        camera_lookat = Camera.main.gameObject.GetComponent<update_lookat>();
        Camera.main.gameObject.transform.Find("lookingto").GetComponent<moving>()
            .Patrol(GetChildren(Camera.main.gameObject.transform.Find("lokingto_route")));


        pumpkin_moving.Patrol(GetChildren(patrol_graveyard));

        //StartCoroutine(WaitIntro());

        //tmp
        camera_dmo.InitTarget(graveyard.transform);
        gonext();
    }

    IEnumerator WaitIntro()
    {
        pumpkin_handler.Say(intro);
        yield return new WaitForSeconds(intro.length);
        camera_dmo.InitTarget(graveyard.transform);
    }

    void go2house()
    {
        StartCoroutine(Waithouse());
    }

    IEnumerator Waithouse()
    {
        pumpkin_moving.Go(zeroPointGraveyard);
        current_stage = stage.house;
        camera_dmo.InitTarget();
        yield return new WaitForSeconds(1.0f);

        pumpkin_handler.Say(grave_end);
        camera_lookat.target = pumpkin.transform;
        camera_moving.Go(GetChildren(route2house));
    }

    public void gonext()
    {
        if (current_stage == stage.graveyard)
            go2house();
    }


    public void startHouse () {
        graveyard.SetActive(false);
        pumpkin_moving.speed = 1;
        camera_lookat.target = null;
        pumpkin_moving.Loop(GetChildren(patrol_house));

        StartCoroutine(WaitHouseIntro());
    }

    IEnumerator WaitHouseIntro()
    {
        camera_moving.Loop(GetChildren(patrool_camera_house));
        //yield return new WaitForSeconds(5);
        pumpkin_handler.Say(about_house);
        yield return new WaitForSeconds(about_house.length);
        //Camera.main.GetComponent<update_lookat>().target = null;
        camera_dmo.InitTarget(house.transform);
    }

    Transform[] GetChildren(Transform parent)
    {
        Transform[] result = new Transform[parent.childCount];
        for (int i=0; i<parent.childCount; i++)
            result[i] = parent.GetChild(i);
        return result;
    }
}
