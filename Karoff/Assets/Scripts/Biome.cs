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
    private CameraShake cs;

    public GameObject buildingSpaces;

    public GameObject particlePrefab;

    private void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
        bb = FindObjectOfType<BiomeBuilding>();
        bm = FindObjectOfType<BuildingManager>();
        cs = FindObjectOfType<CameraShake>();
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
        } else
        {
            SpawnParticle();
            StartCoroutine(cs.ShakeCamera(cs.dur, cs.mag));

        }

    }

    public void SpawnParticle()
    {
        Instantiate(particlePrefab, transform.position, Quaternion.identity, transform);
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
