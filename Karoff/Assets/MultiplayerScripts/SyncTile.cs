using System.Collections;
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

        //if (sprite != null) {
        //    o.GetComponentInChildren<Biome>().GetComponent<SpriteRenderer>().sprite = sprite;
        //}
        if(starting != false) {
            o.GetComponentInChildren<MultiplayerBiome>().startingTile = starting;
        }
    }

  

}
