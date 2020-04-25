using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAwake : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
         FindObjectOfType<MenuNetworkManager>().SetupMenu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
