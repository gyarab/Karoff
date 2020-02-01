using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Biome : MonoBehaviour
{
    [SerializeField]
    public BiomData biomData;

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
