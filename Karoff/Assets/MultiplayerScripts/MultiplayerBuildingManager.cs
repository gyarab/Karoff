
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MultiplayerBuildingManager : MonoBehaviour
{
    public Building[] buildings;
    public MultiplayerBuildingDisplay[] displays;

    public MultiplayerBuildingDisplay displayPrefab;

    public GameObject buildingsParent;
    public GameObject buildingsMenu;
    private Vector2 position;

    public BoxCollider2D menuBox;


    //displayes buildings to menu from Fill from MultiplayerBuildingManager.cs
    private void Start()
    {
        for (int i = 0; i < buildings.Length; i++)
        {
            displays[i].building = buildings[i];
            displays[i].Fill();
        }

        //there removed old code if needed search on github with karoff 0.8v and lower
    }

    //detects click disables menu
    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && buildingsMenu.activeInHierarchy)
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                Debug.Log("Disabling menu.");
                ActivityOnBuildingsMenu(false);
            }
        }
    }

    //sets active game menu
    public void ActivityOnBuildingsMenu(bool active)
    {
        buildingsMenu.SetActive(active);
    }
}
