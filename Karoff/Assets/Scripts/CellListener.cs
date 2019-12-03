using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellListener : MonoBehaviour
{
    public Material borderTile;
    Material select;

    void Start()
    {


    }


    void Update()
    {
        mouseClickListener();
    }

    protected void mouseClickListener() // Targets clicked object
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            if (hit)
            {
                if (hitInfo.transform.position.y != 0.75f)
                { //checks if it's not border
                    if (hitInfo.transform.position.y == 0.5f) // check if its not already used
                    {
                        select = hitInfo.transform.gameObject.GetComponent<MeshRenderer>().material;
                    }
                    if (hitInfo.transform.position.y == 0.25f) //uses
                    {
                        hitInfo.transform.position = new Vector3(hitInfo.transform.position.x, 0.5f, hitInfo.transform.position.z);
                        hitInfo.transform.gameObject.GetComponent<MeshRenderer>().material = select;
                    }
                }
            }
        }
    }
}

