using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class SyncData : NetworkBehaviour
{
    [SyncVar] public BiomeType biome;
    [SyncVar] public Color color;
    [SyncVar] public Sprite sprite;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name != "OnlineScene")
        {
            Debug.Log("nope");
            //FindObjectOfType<SyncData>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

        //if (color != null)
        //{
        //    this.GetComponent<SpriteRenderer>().material.color = color;
        //}
        //if (biome != null)
        //{
        //    this.GetComponent<Biome>().type = biome;
        //}
        //if (sprite != null)
        //{
        //    this.GetComponent<SpriteRenderer>().sprite = sprite;
        //}
    }

    public Color GetColor()
    {
        return color;
    }

    public void SetColor(Color c)
    {
        color = c;
    }

    public BiomeType GetBiome()
    {
        return biome;
    }

    public void SetBiome(BiomeType b)
    {
        biome =  b;
    }

    public Sprite GetSprite()
    {
        return sprite;
    }

    public void SetSprite(Sprite s)
    {
        sprite = s;
    }


}
