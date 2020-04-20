﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class SyncTile : NetworkBehaviour
{
    public BiomeType Desert;
    public BiomeType Mountains;
    public BiomeType Forest;
    public BiomeType Snow;



    public GameObject o;

    BiomeType biomeType;

    [SyncVar] public string bt;

    public Sprite sprite;

    public Building[] buildings;
    public Building bu;

    public GameObject go;
    public MultiplayerBiome bi;
    public SpriteRenderer sr;

    [SyncVar] public string spr;
   

    [SyncVar] public bool starting = false;

    private void Start()
    {
        if (bt.Equals("Desert"))
        {
            biomeType = Desert;
        }
        else if (bt.Equals("Forest"))
        {
            biomeType = Forest;
        }
        else if (bt.Equals("Mountains"))
        {
            biomeType = Mountains;
        }
        else if (bt.Equals("Snow"))
        {
            biomeType = Snow;
        }


        go = o.transform.Find("Biome").gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        if (biomeType != null)
        {
            //Debug.Log(o);
            //Debug.Log(o.GetComponent<Biome>());
            //Debug.Log(o.GetComponent<Biome>().type);
            //Debug.Log(biomeType);
            o.GetComponentInChildren<MultiplayerBiome>().type = biomeType;
            o.GetComponent<SpriteRenderer>().color = biomeType.typeColor;
        }

        if (spr != null && spr != "" ) {
            Debug.Log("trying to set spriiiite");

            foreach (Building b in buildings)
            {

                if (b.ToString().Contains(spr))
                {
                    bu = b;
                }
            }

            //syncVar of this 

            //Debug.Log(go);
            bi = go.GetComponent<MultiplayerBiome>();
            sr = go.GetComponent<SpriteRenderer>();

            //o.GetComponentInChildren<Biome>().square = bu.buildingIcon;
            bi.square = bu.buildingIcon;
            sr.sprite = bu.buildingIcon;
            sr.color = new Color(1f, 1f, 1f);
        }


        if(starting != false) {
            o.GetComponentInChildren<MultiplayerBiome>().startingTile = starting;
        }
    }

    public void SetTile(string building) {
        FindObjectOfType<PlayerCommands>().SetSprite(building, o);
    }


}
