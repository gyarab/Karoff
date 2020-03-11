using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Biome : MonoBehaviour
{

    public BiomeType type;

    public Sprite square;

    public bool startingTile;

    [HideInInspector]
    public SpriteRenderer spr;
    private BiomeBuilding bb;
    private BuildingManager bm;

    public GameObject buildingSpaces;

    private void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
        bb = FindObjectOfType<BiomeBuilding>();
        bm = FindObjectOfType<BuildingManager>();
    }

    private void Start()
    {
        StartCoroutine(LateStart());
    }

    private IEnumerator LateStart()
    {
        yield return new WaitForSeconds(0.1f);

        if (startingTile)
        {
            spr.sprite = type.typeIcon;
            transform.parent.GetComponent<SpriteRenderer>().color = type.typeColor;
        }
    }

    public void NewColor()
    {
        spr.sprite = square;
        spr.color = type.typeColor;
    }

    private void OnMouseUp()
    {
        if(bb.selected != this)
        {
            bb.SelectBiome(this);
        } else if (bb.selected.spr.sprite == square)
        {
            bm.ActivityOnBuildingsMenu(true);
        }
    }

}
