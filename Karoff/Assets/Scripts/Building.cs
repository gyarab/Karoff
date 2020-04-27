using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//scriptable object of building
[CreateAssetMenu(fileName = "New Building", menuName = "Karoff/Building", order = 2)]
public class Building : ScriptableObject
{

    public string buildingName;
    public Sprite buildingIcon;
    public int[] prices = new int[4]; // Sand, Wood, Stone, Ice
    public BiomeType[] possibleBiomes;
    public int[] gain = new int[5]; // Points, Sand, Wood, Stone, Ice

}
