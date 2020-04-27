using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class MultiplayerBiome : MonoBehaviour
{

    public BiomeType type;

    public Sprite square;

    public bool startingTile;

    public string player;
    public GameObject gameManager;
    public GameObject BuildingSpaces;

    [HideInInspector]
    public SpriteRenderer spr;
    private CameraShake cs;
    private MultiplayerBiomeBuilding bb;
    private MultiplayerBuildingManager bm;

    public GameObject particlePrefab;

    private void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
        cs = FindObjectOfType<CameraShake>();
        bb = FindObjectOfType<MultiplayerBiomeBuilding>();
        bm = FindObjectOfType<MultiplayerBuildingManager>();
    }



    //finds GameManager starts latestart
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        StartCoroutine(LateStart());
    }

    //waits for player objects to spawn and then sets player as host or client
    private IEnumerator LateStart()
    {
        yield return new WaitForSeconds(0.1f);

        var objects = GameObject.FindObjectsOfType<PlayerID>();

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


        //calls spawn particles when created
        if (startingTile)
        {
            spr.sprite = type.typeIcon;
            transform.parent.GetComponent<SpriteRenderer>().color = type.typeColor;
        }
        else
        {
            if ((player.Equals("host")) && FindObjectOfType<MultiplayerTurnManager>().GetTurn() % 2 == 1)
            {
                SpawnParticle();
                StartCoroutine(cs.ShakeCamera(cs.dur, cs.mag));

            }
            else if (player.Equals("client") && FindObjectOfType<MultiplayerTurnManager>().GetTurn() % 2 != 1)
            {
                SpawnParticle();
                StartCoroutine(cs.ShakeCamera(cs.dur, cs.mag));
            }
        }
    }


    //spawns particles
    public void SpawnParticle()
    {
        Instantiate(particlePrefab, transform.position, Quaternion.identity, transform);
    }

    //sets color
    public void NewColor()
    {
        spr.sprite = square;
        spr.color = type.typeColor;
        transform.parent.GetComponent<SpriteRenderer>().color = type.typeColor;
    }



    //detects click and selects tile and biome
    void OnMouseUp()
    {

        if (bb.selected != this)
        {
            if (BuildingSpaces.active == false)
            {
                gameManager.GetComponent<MultiplayerBiomeBuilding>().SelectBiome(this);
            }
            else
            {
                gameManager.GetComponent<MultiplayerBiomeBuilding>().DeselectBiome();

            }
        }

        else if (bb.selected.spr.sprite == null)
        { 
            if ((player.Equals("host")) && FindObjectOfType<MultiplayerTurnManager>().GetTurn() % 2 == 0)
            {
                //building menu 
                bm.ActivityOnBuildingsMenu(true);
            }
            else if (player.Equals("client") && FindObjectOfType<MultiplayerTurnManager>().GetTurn() % 2 != 0)
            {
                //building menu 
                bm.ActivityOnBuildingsMenu(true);
            }
            else {
                Debug.Log("Not your turn");
            }




        }

    }
}









