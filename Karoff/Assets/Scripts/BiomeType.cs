using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Biome Type", menuName = "Karoff/Biome Type", order = 1)]
public class BiomeType : ScriptableObject
{
    public string typeName;

    public Sprite typeIcon;

    public Color typeColor;

}
