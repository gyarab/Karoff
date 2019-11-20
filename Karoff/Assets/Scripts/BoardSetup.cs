using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSetup : MonoBehaviour
{
    public GameObject GridCell;
    public Material testTile;
    public int gridSizeX = 3; //Grid of board + board border
    public int gridSizeZ = 3;
    int halfGridX;
    int halfGridZ;
    bool evenX;
    bool evenZ;

    // Start is called before the first frame update
    void Start()
    {

        gridHalf(); //Check if grid X/Z is even/odd numbers and sets halfGridX/Z
        InstantiateIfX(halfGridX, halfGridZ); //Generates X x Z + border board

    }

    //Check if grid X/Z is even/odd numbers and sets halfGridX/Z
    void gridHalf() {
        if (gridSizeX % 2 == 0) {
            halfGridX = gridSizeX / 2;
            evenX = true;
        }
        else {
            halfGridX = (gridSizeX - 1) / 2;
            evenX = false;
        }
        if (gridSizeZ % 2 == 0) {
            halfGridZ = gridSizeZ / 2;
            evenZ = true;
        }
        else {
            halfGridZ = (gridSizeZ - 1) / 2;
            evenZ = false;
        }
    }

    //Sets X cells
    protected void InstantiateIfX(int halfGridX, int halfGridZ) { 
        if(evenX == true) {
            for (int x = 0 - halfGridX - 1; x < halfGridX + 1; x++)
            {
                InstantiateIfZ(x, halfGridX, halfGridZ);
            }
        }
        else {
            for (int x = 0 - halfGridX - 1; x <= halfGridX + 1; x++)
            {
                InstantiateIfZ(x, halfGridX, halfGridZ);
            }
        }
    }

    //Sets Z cells
    protected void InstantiateIfZ(int x, int halfGridX, int halfGridZ) {
        if (evenZ == true)
        {
            for (int z = 0 - halfGridZ - 1; z < halfGridZ + 1; z++)
            {
                CheckBorders(x, z, halfGridX, halfGridZ);
            }
        }
        else
        {
            for (int z = 0 - halfGridZ - 1; z <= halfGridZ + 1; z++)
            {
                CheckBorders(x, z, halfGridX, halfGridZ);
            }
        }
    }


    //Check borders
    protected void CheckBorders(int x, int z, int halfGridX, int halfGridZ) {
        if (evenX == true && evenZ == true)
        {
            if (x == -halfGridX - 1 || x == halfGridX || z == -halfGridZ - 1 || z == halfGridZ)
            {
                InstantiateBorderCell(x, z);
            }
            else
            {
                InstantiateCell(x, z);
            }
        }
        else if(evenX == false && evenZ == true) {
            if (x == -halfGridX - 1 || x == halfGridX + 1 || z == -halfGridZ - 1 || z == halfGridZ)
            {
                InstantiateBorderCell(x, z);
            }
            else
            {
                InstantiateCell(x, z);
            }
        }
        else if (evenX == true && evenZ == false)
        {
            if (x == -halfGridX - 1 || x == halfGridX || z == halfGridZ + 1 || z == -halfGridZ - 1) {
                InstantiateBorderCell(x,z);
            }
            else {
                InstantiateCell(x, z);
            }
        }
        else if(evenX == false && evenZ == false){ 
            if(z == halfGridZ + 1 || z == -halfGridZ - 1 || x == -halfGridX - 1 || x == halfGridX + 1)
            {
                InstantiateBorderCell(x, z);
            }
            else {
                InstantiateCell(x, z);
            }
        }
    }

    //Sets basic cell
    protected void InstantiateCell(int x, int z) {
        Instantiate(GridCell, new Vector3(x, 0, z), Quaternion.identity);
    }

    //Sets borderCell
    protected void InstantiateBorderCell(int x, int z)
    {
        Instantiate(GridCell, new Vector3(x, 0.25f, z), Quaternion.identity).GetComponent<MeshRenderer>().material = testTile;
    }

}
