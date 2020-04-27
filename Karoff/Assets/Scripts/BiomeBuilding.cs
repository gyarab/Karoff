using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiomeBuilding : MonoBehaviour
{

    public Biome selected;

    //selects biome
    public void SelectBiome(Biome biome)
    {
        if(selected != null)
        {
            DeselectBiome();
        }

        selected = biome;
        selected.buildingSpaces.SetActive(true);
        Debug.Log("Selecting: " + selected.transform.parent.name);
    }

    //deselects biome 
    public void DeselectBiome()
    {
        selected.buildingSpaces.SetActive(false);
        selected = null;
    }

}
