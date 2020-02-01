using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellListener : MonoBehaviour
{
    public GameObject GreenVisualCell;
    public Material borderTile;
    public BiomData starting;
    public BiomData visualGreen;

    protected BiomData hitBiome;
    GameObject VisualXPlus;
    GameObject VisualXMinus;
    GameObject VisualZPlus;
    GameObject VisualZMinus;

    bool select = true;

    float selectZ;
    float selectX;

    RaycastHit hitInfo = new RaycastHit();


    void Update()
    {
        // if (MyTurn){
        if (mouseClickListener())
        {
            Action();
        }
        //}
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

    protected bool IsBorder() {
        Debug.Log("is border");
        if (hitInfo.transform.position.y == 0.75f) { //checks if it's not border
            return true;
        }
        return false;
    }

    protected void Action() {
        Debug.Log("action");
        if (IsBorder() == false) {
            if (select) {
                Select();
                Preview();
            }
            else {
                Place();
            }
        }
    }

    protected void Select()
    {
        Debug.Log("Select");
        if (hitInfo.transform.position.y == 0.5f) //check position
        {
            selectX = hitInfo.transform.position.x;
            selectZ = hitInfo.transform.position.z;
            hitBiome = hitInfo.transform.gameObject.GetComponent<Biome>().biomData;
            select = false;
        }
        else {
            select = true;
        }
    }

    protected void Place()
    {
        select = true;
        if (nextCell()) {
            Debug.Log("place");
            hitInfo.transform.gameObject.GetComponent<Biome>().biomData = hitBiome;
            hitInfo.transform.gameObject.GetComponent<MeshRenderer>().material.color = hitInfo.transform.gameObject.GetComponent<Biome>().biomData.Color;
            hitInfo.transform.position = new Vector3(hitInfo.transform.position.x, hitInfo.transform.gameObject.GetComponent<Biome>().biomData.Y, hitInfo.transform.position.z);
        }
       

    }

    protected void Preview()
    {
        Debug.Log("preview");
        if (select == false)
        {
            VisualXPlus = Instantiate(GreenVisualCell, new Vector3(selectX + 1, GreenVisualCell.GetComponent<Biome>().biomData.Y, selectZ), Quaternion.identity);
            VisualXPlus.GetComponent<MeshRenderer>().material = GreenVisualCell.GetComponent<Biome>().biomData.Material;
            VisualXMinus = Instantiate(GreenVisualCell, new Vector3(selectX - 1, GreenVisualCell.GetComponent<Biome>().biomData.Y, selectZ), Quaternion.identity);
            VisualXMinus.GetComponent<MeshRenderer>().material = GreenVisualCell.GetComponent<Biome>().biomData.Material;
            VisualZPlus = Instantiate(GreenVisualCell, new Vector3(selectX, GreenVisualCell.GetComponent<Biome>().biomData.Y, selectZ + 1), Quaternion.identity);
            VisualZPlus.GetComponent<MeshRenderer>().material = GreenVisualCell.GetComponent<Biome>().biomData.Material;
            VisualZMinus = Instantiate(GreenVisualCell, new Vector3(selectX, GreenVisualCell.GetComponent<Biome>().biomData.Y, selectZ - 1), Quaternion.identity);
            VisualZMinus.GetComponent<MeshRenderer>().material = GreenVisualCell.GetComponent<Biome>().biomData.Material;
        }
    }

    protected void Remove() 
    {
        Debug.Log("remove");
        Destroy(VisualXPlus);
        Destroy(VisualZPlus);
        Destroy(VisualXMinus);
        Destroy(VisualZMinus);

    }

    protected bool nextCell() {
        Remove();
        Debug.Log("nextcell");
        if (hitInfo.transform.position.y == 0f)
        {
            if ((hitInfo.transform.position.z == selectZ + 1) && (hitInfo.transform.position.x == selectX))
            {
                return true;
            }
            else if ((hitInfo.transform.position.z == selectZ - 1) && (hitInfo.transform.position.x == selectX))
            {
                return true;
            }
            else if ((hitInfo.transform.position.z == selectZ) && (hitInfo.transform.position.x == selectX + 1))
            {
                return true;
            }
            else if ((hitInfo.transform.position.z == selectZ) && (hitInfo.transform.position.x == selectX - 1))
            {
                return true;
            }

            else {
                return false;
            }

        }
        else if (hitInfo.transform.position.y == 0.5f)
        {
            if (hitInfo.transform.position.x == selectX && hitInfo.transform.position.z == selectZ)
            {

                return false;
            }
            else {
                Select();
                Preview();
                return false;
            }
        }
        else
        {
            return false;
        }
    }



}
//jentak btw sem davam odkazy z kterych se cerpalo pri tvorbe 
//https://answers.unity.com/questions/411793/selecting-a-game-object-with-a-mouse-click-on-it.html
//https://www.raywenderlich.com/2826197-scriptableobject-tutorial-getting-started#toc-anchor-003
//https://docs.unity3d.com/Manual/index.html
//https://answers.unity.com/questions/534582/accessing-variable-defined-in-a-script-attached-to.html

