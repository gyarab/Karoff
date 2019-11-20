using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellListener : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

      
    }

    // Update is called once per frame
    void Update()
    {
        //On click selects cell and changes color to red
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            if (hit)
            {
                hitInfo.transform.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
                hitInfo.transform.gameObject.transform.position = new Vector3(hitInfo.transform.gameObject.transform.position.x, 0.25f, hitInfo.transform.gameObject.transform.position.z);
            }
        }
    }
}
