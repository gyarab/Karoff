using System.Collections;
using System.Collections.Generic;
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

    private void OnEnable()
    {
        CheckAvailability();
    }

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

    private void OnMouseUp()
    {
        if (clickable)
        {
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
