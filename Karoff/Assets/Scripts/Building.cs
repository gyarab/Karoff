using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField]
    public BuildingData buildingData;

    private void OnMouseDown()
    {
        //Debug.Log(biomData.BiomName); 
        //Debug.Log(biomData.Material); 
        //Debug.Log(biomData.Status);
        ////Debug.Log("X is:" + biomData.X.ToString());
        //Debug.Log("Y is:" + biomData.Y.ToString());
        //Debug.Log("Z is:" + biomData.Z.ToString());
    }

}
