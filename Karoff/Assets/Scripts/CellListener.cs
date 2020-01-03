using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellListener : MonoBehaviour
{
    public Material borderTile;
    public BiomData starting;

    RaycastHit hitInfo = new RaycastHit();

    void Start()
    {


    }


    void Update()
    {
        if (mouseClickListener())
        {
            action();
        }
    }

    protected bool mouseClickListener() // Targets clicked object
    {
        if (Input.GetMouseButtonDown(0))
        {
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            if (hit)
            {
                return hit;
            }
            else {
                return false;
            }

        }
        return false;
    }

    protected void action() {
        if (hitInfo.transform.position.y != 0.75f)
        { //checks if it's not border

            if (hitInfo.transform.position.y == 0.5f) // check if its not already used
            {

            }
           
                if (hitInfo.transform.position.y == 0.25f) //uses
                {
                    hitInfo.transform.gameObject.GetComponent<Biome>().biomData = starting;
                    hitInfo.transform.position = new Vector3(hitInfo.transform.position.x, hitInfo.transform.gameObject.GetComponent<Biome>().biomData.Y, hitInfo.transform.position.z);
                    hitInfo.transform.gameObject.GetComponent<MeshRenderer>().material = hitInfo.transform.gameObject.GetComponent<Biome>().biomData.Material;

                    
                }
            
        }
    }

}
//jentak btw sem davam odkazy z kterych se cerpalo pri tvorbe 
//https://answers.unity.com/questions/411793/selecting-a-game-object-with-a-mouse-click-on-it.html
//https://www.raywenderlich.com/2826197-scriptableobject-tutorial-getting-started#toc-anchor-003
//https://docs.unity3d.com/Manual/index.html

