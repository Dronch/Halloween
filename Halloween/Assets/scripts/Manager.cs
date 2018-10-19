using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

    public GameObject pumpkin;
    moving pumpkin_moving;
    update_lookat pumpkin_lookat;
    moving camera_moving;
    update_lookat camera_lookat;

    // graveyard
    public GameObject graveyard;
    public Transform patrol_graveyard;
    public Transform zeroPointGraveyard;

    public Transform route2house;

    // house
    public Transform patrol_house;
    public Transform zeroPointHouse;

    void Start () {
        pumpkin_moving = pumpkin.GetComponent<moving>();
        pumpkin_lookat = pumpkin.GetComponent<update_lookat>();
        camera_moving = Camera.main.gameObject.GetComponent<moving>();
        camera_lookat = Camera.main.gameObject.GetComponent<update_lookat>();

        pumpkin_moving.Patrol(GetChildren(patrol_graveyard));
    }

    public void go2house()
    {
        camera_lookat.target = pumpkin.transform;
        camera_moving.Go(GetChildren(route2house));
        pumpkin_moving.Go(zeroPointGraveyard);
    }
	
	public void startHouse () {
        graveyard.SetActive(false);
        pumpkin_moving.speed = 1;
        camera_lookat.target = null;
        pumpkin_moving.Loop(GetChildren(patrol_house));
    }

    Transform[] GetChildren(Transform parent)
    {
        Transform[] result = new Transform[parent.childCount];
        for (int i=0; i<parent.childCount; i++)
            result[i] = parent.GetChild(i);
        return result;
    }
}
