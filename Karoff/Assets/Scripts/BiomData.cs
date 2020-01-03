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


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
