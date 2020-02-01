using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class building_listener : MonoBehaviour
{

    public bool setTurn = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(setTurn == true && gameObject.GetComponent<BuildingData>().Status == 0)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            gameObject.GetComponent<BoxCollider>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
