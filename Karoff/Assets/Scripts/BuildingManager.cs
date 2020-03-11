
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingManager : MonoBehaviour
{
    public Building[] buildings;

    public BuildingDisplay displayPrefab;

    public GameObject buildingsParent;
    public GameObject buildingsMenu;
    private Vector2 position;

    public BoxCollider2D menuBox;

    private void Start()
    {

        position = new Vector2(225f, 150f);

        foreach (Building b in buildings)
        {

            BuildingDisplay bd = Instantiate(displayPrefab, position, Quaternion.identity, buildingsParent.transform);

            bd.building = b;
            position = new Vector2(bd.transform.position.x + 310f, bd.transform.position.y);
        }
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
