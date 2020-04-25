
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

    private void Start()
    {

        for (int i = 0; i < buildings.Length; i++)
        {
            displays[i].building = buildings[i];
            displays[i].Fill();
        }

        //position = new Vector2(225f, 116.5f);

        //foreach (Building b in buildings)
        //{

        //    MultiplayerBuildingDisplay bd = Instantiate(displayPrefab, position, Quaternion.identity, buildingsParent.transform);

        //    bd.building = b;
        //    position = new Vector2(bd.transform.position.x + 310f, bd.transform.position.y);
        //}
    }

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

    public void ActivityOnBuildingsMenu(bool active)
    {
        buildingsMenu.SetActive(active);
    }
}
