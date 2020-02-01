using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New BuildingData", menuName = "Building Data", order = 52)]
public class BuildingData : ScriptableObject
{
    [SerializeField]
    private string buildingName;
    [SerializeField]
    private Material material;
    [SerializeField]
    private int status;
    [SerializeField]
    private int bonus;

    [SerializeField]
    private float y;


    public string BuildingName
    {
        get
        {
            return buildingName;
        }
    }

    public Material Material
    {
        get
        {
            return material;
        }
    }


    public int Status
    {
        get
        {
            return status;
        }
    }

    public int Bonus
    {
        get
        {
            return bonus;
        }
    }

    public float Y
    {
        get
        {
            return y;
        }
    }

}
