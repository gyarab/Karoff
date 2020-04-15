using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MultiplayerBiomeBuilding : MonoBehaviour
{

    public MultiplayerBiome selected;

    public void SelectBiome(MultiplayerBiome biome)
    {
        if(selected != null)
        {
            DeselectBiome();
        }

        selected = biome;
        selected.BuildingSpaces.SetActive(true);
        Debug.Log("Selecting: " + selected.transform.parent.name);
    }

    public void DeselectBiome()
    {
        selected.BuildingSpaces.SetActive(false);
        selected = null;
    }

}
