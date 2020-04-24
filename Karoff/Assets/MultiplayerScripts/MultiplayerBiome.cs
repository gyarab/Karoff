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



    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        StartCoroutine(LateStart());

    }

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
        Debug.Log(player);

        if (startingTile)
        {

            spr.sprite = type.typeIcon;
            Debug.Log(transform.parent.name);
            //Debug.Log(transform.parent.parent.name);
            transform.parent.GetComponent<SpriteRenderer>().color = type.typeColor;
        }
        else
        {
            Debug.Log(player);
            Debug.Log(FindObjectOfType<MultiplayerTurnManager>().GetTurn());

            if ((player.Equals("host")) && FindObjectOfType<MultiplayerTurnManager>().GetTurn() % 2 == 1)
            {
                //Debug.Log("1234");
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

    //private void Update()
    //{
    //    spr.sprite = type.typeIcon;
    //    transform.parent.GetComponent<SpriteRenderer>().color = type.typeColor;
    //}

    public void SpawnParticle()
    {
        Instantiate(particlePrefab, transform.position, Quaternion.identity, transform);
    }


    public void NewColor()
    {
        spr.sprite = square;
        spr.color = type.typeColor;
        transform.parent.GetComponent<SpriteRenderer>().color = type.typeColor;
    }




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
            //Debug.Log(bb.selected.spr.sprite);
            //Debug.Log(player);
            //Debug.Log(FindObjectOfType<MultiplayerTurnManager>().GetTurn());

            if ((player.Equals("host")) && FindObjectOfType<MultiplayerTurnManager>().GetTurn() % 2 == 0)
            {
                bm.ActivityOnBuildingsMenu(true);
            }
            else if (player.Equals("client") && FindObjectOfType<MultiplayerTurnManager>().GetTurn() % 2 != 0)
            {
                bm.ActivityOnBuildingsMenu(true);
            }
            else {
                Debug.Log("Not your turn");
            }




        }

    }
}









