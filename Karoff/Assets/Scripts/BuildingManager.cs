
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingManager : MonoBehaviour
{
    public Building[] buildings;
    public BuildingDisplay[] displays;

    public BuildingDisplay displayPrefab;

    public GameObject buildingsParent;
    public GameObject buildingsMenu;

    public BoxCollider2D menuBox;

    //displays building menu
    private void Start()
    {

        for (int i = 0; i < buildings.Length; i++)
        {
            displays[i].building = buildings[i];
            displays[i].Fill();
        }
        
    }
     
    //detects clicks 
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

    //sets building menu active
    public void ActivityOnBuildingsMenu(bool active)
    {
        buildingsMenu.SetActive(active);
    }
}
