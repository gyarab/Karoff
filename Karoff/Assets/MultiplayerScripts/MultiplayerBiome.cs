using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class MultiplayerBiome : MonoBehaviour
{

    public BiomeType type;

    public Sprite square;

    public bool startingTile;

    private string player;
    public GameObject gameManager;
    public GameObject BuildingSpaces;

    [HideInInspector]
    public SpriteRenderer spr;

    private MultiplayerBiomeBuilding bb;
    //private BuildingManager bm;

    private void Awake()
    {
        spr = GetComponent<SpriteRenderer>();

        bb = FindObjectOfType<MultiplayerBiomeBuilding>();
        //bm = FindObjectOfType<BuildingManager>();
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

        if (startingTile)
        {

            spr.sprite = type.typeIcon;
            Debug.Log(transform.parent.name);
            //Debug.Log(transform.parent.parent.name);
            transform.parent.GetComponent<SpriteRenderer>().color = type.typeColor;
        }
    }

    //private void Update()
    //{
    //    spr.sprite = type.typeIcon;
    //    transform.parent.GetComponent<SpriteRenderer>().color = type.typeColor;
    //}



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
        else if (bb.selected.spr.sprite == square)
        {
            Debug.Log("nothing happens");
            //bm.ActivityOnBuildingsMenu(true);
        }

    }
}









