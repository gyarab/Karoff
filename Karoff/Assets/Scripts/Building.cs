using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField]
    public BuildingData buildingData;

    public bool setTurn = false;
    private void OnMouseDown()
    {
        //Debug.Log(biomData.BiomName); 
        //Debug.Log(biomData.Material); 
        //Debug.Log(biomData.Status);
        ////Debug.Log("X is:" + biomData.X.ToString());
        //Debug.Log("Y is:" + biomData.Y.ToString());
        //Debug.Log("Z is:" + biomData.Z.ToString());
    }

    void Update()
    {
         if (setTurn == true && this.gameObject.GetComponent<Building>().buildingData.Status == 0)
        {
            this.gameObject.GetComponent<MeshRenderer>().enabled = true;
            this.gameObject.GetComponent<BoxCollider>().enabled = true;
       }
        else if (this.gameObject.GetComponent<Building>().buildingData.Status == 0)
        {
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
     }

    private void Start()
    {
    }

}
