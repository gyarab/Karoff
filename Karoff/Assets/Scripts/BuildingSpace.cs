using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class BuildingSpace : MonoBehaviour
{
    private SpriteRenderer spr;
    private BoxCollider2D bc;
    public GameObject tilePrefab;
    public GameObject board;
    private bool clickable;

    private void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();
    }

    //again an interesting way to call public function... :-)
    private void OnEnable()
    {
        CheckAvailability();
    }

    //sets building spaces but only where they have to be clickable
    public void CheckAvailability()
    {
        bc.enabled = true;

        spr.color = new Color(1f, 1f, 1f, 0.5f);

        GameObject[] tiles = GameObject.FindGameObjectsWithTag("Tile");

        clickable = true;

        foreach (GameObject t in tiles)
        {
            if(t.transform.position == transform.position)
            {
                clickable = false;
            }
        }

        if (!clickable)
        {
            spr.color = new Color(1f, 1f, 1f, 0f);
            bc.enabled = false;
        }
            
    }

    //detects click on clickable spawns tile and sets settings for it
    private void OnMouseUp()
    {
        if (clickable)
        {
            FindObjectOfType<AudioManager>().Play("Build");
            GameObject tile = Instantiate(tilePrefab, transform.position, Quaternion.identity, board.transform);
                tile.transform.Find("Biome").GetComponent<Biome>().buildingSpaces.SetActive(false);
                tile.transform.Find("Biome").GetComponent<Biome>().type = transform.parent.parent.Find("Biome").GetComponent<Biome>().type;
                tile.transform.Find("Biome").GetComponent<Biome>().startingTile = false;
                tile.transform.Find("Biome").GetComponent<Biome>().NewColor();
            
              
                FindObjectOfType<TurnManager>().ChangeTurn();
                FindObjectOfType<BiomeBuilding>().DeselectBiome();
        }
    }

}
