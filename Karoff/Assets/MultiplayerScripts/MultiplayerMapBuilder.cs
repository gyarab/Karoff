using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Networking;


public class MultiplayerMapBuilder : MonoBehaviour
{
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    private string player;



    public GameObject[] tiles;
    public List<Vector2> coords;
    

    private void Start()
    {




        StartCoroutine(LateStart());
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


       



    private IEnumerator LateStart()
    {
        yield return new WaitForSeconds(0.15f);

        var objects = FindObjectsOfType<PlayerID>();
        //Debug.Log(objects[0]);
        foreach (var o in objects)
        {

            Debug.Log(o.ToString());
            if (o.ToString().Contains("host"))
            {
                player = "host";
            }
            else if (o.ToString().Contains("client"))
            {
                player = "client";
            }
        }

        if ((player.Equals("host")) && FindObjectOfType<MultiplayerTurnManager>().GetTurn() % 2 == 0)
        {
            foreach (GameObject g in tiles)
            {
                g.transform.position = FindCoords();
            }
        }
    }


}
