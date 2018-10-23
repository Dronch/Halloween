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
        house,
        child
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
    public AudioClip house_end;
    public GameObject house_sce;
    public GameObject house;
    public Transform patrool_camera_house;
    public Transform patrol_house;
    public Transform zeroPointHouse;
    public Transform route2child;

    //child
    public AudioClip about_child;
    public AudioClip child_end;
    public GameObject child;
    public Transform patrool_camera_child;
    public Transform patrol_child;
    public Transform zeroPointChild;
    public GameObject witch;
    public Transform witch_route;
    public GameObject girl;
    public Transform girl_route;

    void Start () {
        pumpkin_moving = pumpkin.GetComponent<moving>();
        pumpkin_lookat = pumpkin.GetComponent<update_lookat>();
        pumpkin_handler = pumpkin.transform.GetChild(0).GetComponent<pumpcin_handler>();

        camera_dmo = Camera.main.gameObject.GetComponent<DragMouseOrbit>();
        camera_moving = Camera.main.gameObject.GetComponent<moving>();
        camera_lookat = Camera.main.gameObject.GetComponent<update_lookat>();
        Camera.main.gameObject.transform.Find("lookingto").GetComponent<moving>()
            .Patrol(GetChildren(Camera.main.gameObject.transform.Find("lokingto_route")));

        witch.GetComponent<moving>().Patrol(GetChildren(witch_route));
        girl.GetComponent<moving>().Patrol(GetChildren(girl_route));

        //tmp
        current_stage = stage.child;
        startChild();
        //activate zeropoint and stonemonster and poin4
        return;

        pumpkin_moving.Patrol(GetChildren(patrol_graveyard));

        StartCoroutine(WaitIntro());

    }

    IEnumerator WaitIntro()
    {
        pumpkin_handler.Say(intro);
        yield return new WaitForSeconds(intro.length);
        camera_dmo.InitTarget(graveyard.transform);
    }

    IEnumerator go2house()
    {
        pumpkin_moving.Go(zeroPointGraveyard);
        current_stage = stage.house;
        camera_dmo.InitTarget();
        yield return new WaitForSeconds(1.0f);

        pumpkin_handler.Say(grave_end);
        camera_lookat.target = pumpkin.transform;
        camera_moving.Go(GetChildren(route2house));
    }

    IEnumerator go2child()
    {
        pumpkin_moving.Go(zeroPointHouse);
        current_stage = stage.child;
        camera_dmo.InitTarget();
        yield return new WaitForSeconds(1.0f);

        pumpkin_handler.Say(house_end);
        camera_lookat.target = pumpkin.transform;
        camera_moving.Go(GetChildren(route2child));
    }

    public void gonext()
    {
        if (current_stage == stage.graveyard)
        {
            StartCoroutine(go2house());
            return;
        }
        if (current_stage == stage.house)
        {
            StartCoroutine(go2child());
            return;
        }
        if (current_stage == stage.child)
        {
            pumpkin_handler.Swap();
            return;
        }
        
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
        Camera.main.GetComponent<update_lookat>().target = house.transform;
        pumpkin_handler.Say(about_house);
        yield return new WaitForSeconds(about_house.length);
        Camera.main.GetComponent<update_lookat>().target = null;
        camera_moving.Stop();
        camera_dmo.InitTarget(house.transform);
    }

    public void startChild()
    {
        house_sce.SetActive(false);
        pumpkin_moving.speed = 1;
        camera_lookat.target = null;
        pumpkin_moving.Loop(GetChildren(patrol_child));

        StartCoroutine(WaitChildIntro());
    }

    IEnumerator WaitChildIntro()
    {
        camera_moving.Loop(GetChildren(patrool_camera_child));
        Camera.main.GetComponent<update_lookat>().target = child.transform;
        pumpkin_handler.Say(about_child);
        yield return new WaitForSeconds(about_child.length);
        Camera.main.GetComponent<update_lookat>().target = null;
        camera_moving.Stop();
        camera_dmo.InitTarget(child.transform);
    }

    Transform[] GetChildren(Transform parent)
    {
        Transform[] result = new Transform[parent.childCount];
        for (int i=0; i<parent.childCount; i++)
            result[i] = parent.GetChild(i);
        return result;
    }
}
