using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSetup : MonoBehaviour
{
    public GameObject cameraObject;
    public GameObject GridCell;
    public Material testTile;
    public Material logoTile;
    public Material emptyTile;

    public BiomData blank;
    public BiomData starting;
    public BiomData border;


    public int gridSizeX = 3; //Grid of board + board border
    public int gridSizeZ = 3;

    bool evenX;
    bool evenZ;
    int halfGridX;
    int halfGridZ;
    float startX;
    float startZ;

    

    // Start is called before the first frame update
    void Start()
    {
        gridHalf(); //Check if grid X/Z is even/odd numbers and sets halfGridX/Z
        InstantiateXZ(halfGridX, halfGridZ); //Generates X x Z + border board

        setCamera();

    }

    //Check if grid X/Z is even/odd numbers and sets halfGridX/Z + 1 for border
    private void gridHalf()
    {
        if (gridSizeX % 2 == 0) { //if gridSizeX is even and sets sizes
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
        else
        {
            halfGridZ = (gridSizeZ - 1) / 2;
            evenZ = false;
        }

        halfGridZ += 1;
        halfGridX += 1;
    }


    //loops generating board
    protected void InstantiateXZ(int halfGridX, int halfGridZ) {
        //sets starting cell coordinates
        if (evenX == true) {
            startX = halfGridX - 0.5f;
        }
        else {
            startX = halfGridX;
        }
        if (evenZ == true) {
            startZ = halfGridZ - 0.5f;
        }
        else {
            startZ = halfGridZ;
        }

        for (float x = startX; x >= -startX; x--) {
            for (float z = startZ; z >= -startZ; z--) {
                setCell(x, z, startX, startZ);
            }
        }
    }

    //sets cells of the board
    protected void setCell(float x, float z, float startX, float startZ){
        if(x == startX || x == -startX || z == startZ || z == -startZ) {    //sets boarders
            GridCell.GetComponent<Biome>().biomData = border;


            Instantiate(GridCell, new Vector3(x, GridCell.GetComponent<Biome>().biomData.Y, z), Quaternion.identity).GetComponent<MeshRenderer>().material = GridCell.GetComponent<Biome>().biomData.Material;
        }
        else {  //sets regular cells

            if (z == startZ-1 || z == -(startZ - 1)) {
                GridCell.GetComponent<Biome>().biomData = starting;
                Instantiate(GridCell, new Vector3(x, GridCell.GetComponent<Biome>().biomData.Y, z), Quaternion.identity).GetComponent<MeshRenderer>().material = GridCell.GetComponent<Biome>().biomData.Material;
            }
            else {
                GridCell.GetComponent<Biome>().biomData = blank;
                Instantiate(GridCell, new Vector3(x, GridCell.GetComponent<Biome>().biomData.Y, z), Quaternion.identity).GetComponent<MeshRenderer>().material = GridCell.GetComponent<Biome>().biomData.Material;

            }
        }
    }

    protected void setCamera() {
        cameraObject.transform.position = new Vector3(0, gridSizeZ+1.65f, 0); //move main camera
    }
}
