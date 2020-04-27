using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine;


public class MapBuilder : MonoBehaviour
{
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    
    public GameObject[] tiles;
    public List<Vector2> coords;
    

    //spwans 4 starting tiles at random positions
    private void Start()
    {    
            foreach (GameObject g in tiles)
            {
                g.transform.position = FindCoords();
            }
        
    }

    //generates 4 random positions
    public Vector2 FindCoords()
    {

        Vector2 v = new Vector2(Mathf.Round(Random.Range(minX, maxX)), Mathf.Round(Random.Range(minY, maxY)));
        if (!coords.Contains(v))
        {
            coords.Add(v);
            return v;
        } else
        {
            return FindCoords();
        }
    }
}
