using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Networking;

public class MapBuilder : NetworkBehaviour
{
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    
    public GameObject[] tiles;
    public List<Vector2> coords;
    

    private void Start()
    {

        if (SceneManager.GetActiveScene().name == "OnlineScene")
        {

        }

    
        else
        {
            foreach (GameObject g in tiles)
            {
                g.transform.position = FindCoords();
            }
        }
    }

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
