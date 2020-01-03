using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New BiomData", menuName = "Biom Data", order = 51)]
public class BiomData : ScriptableObject
{
    [SerializeField]
    private string biomName;
    [SerializeField]
    private Material material;
    [SerializeField]
    private int status;
    [SerializeField]
    private int bonus;

    //[SerializeField]
    //public float x;
    [SerializeField]
    private float y;
    //[SerializeField]
    //public float z;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public string BiomName
    {
        get
        {
            return biomName;
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

    //public float X
    //{
    //    get
    //    {
    //        return x;
    //    }
    //}

    public float Y
    {
        get
        {
            return y;
        }
    }

    //public float Z
    //{
    //    get
    //    {
    //        return z;
    //    }
    //}
}
