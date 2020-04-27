using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class MultiplayerBuildingSpace : MonoBehaviour
{
    private string player;
    private SpriteRenderer spr;
    private BoxCollider2D bc;
    public GameObject tilePrefab;
    //public GameObject board;
    public bool clickable;
    private BuildingSpacesColor[] colors;

    //sets components of objects to variables 
    private void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();
    }

   //an interesting way to call public function...
    private void OnEnable()
    {
        CheckAvailability();
    }

    //sets as clickable but only where they really are clickable
    public void CheckAvailability()
    {
        bc.enabled = true;

        SetColor();
        //spr.color = new Color(1f, 1f, 1f, 0.5f);

        GameObject[] tiles = GameObject.FindGameObjectsWithTag("Tile");

        clickable = true;

        foreach (GameObject t in tiles)
        {
            if (t.transform.position == transform.position)
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

    //when click on clickable calls command to spawn tile with biome 
    private void OnMouseUp()
    {
        if (clickable)
        {
            var objects = GameObject.FindObjectsOfType<PlayerID>();

            foreach (var o in objects)
            {

                //Debug.Log(o.ToString());
                if (o.ToString().Contains("host")) {
                    player = "host";
                }
                else if (o.ToString().Contains("client")) {
                    player = "client";
                }
            }
            Vector3 pos = transform.position;
            BiomeType bt = transform.parent.parent.Find("Biome").GetComponent<MultiplayerBiome>().type;

            if ((player.Equals("host")) && FindObjectOfType<MultiplayerTurnManager>().GetTurn()%2 == 0) {
                FindObjectOfType<AudioManager>().Play("Build");
                FindObjectOfType<PlayerCommands>().SpawnTile(pos, bt.name);
                }
            else if (player.Equals("client")&& FindObjectOfType<MultiplayerTurnManager>().GetTurn() % 2 != 0) {
                FindObjectOfType<AudioManager>().Play("Build");
                FindObjectOfType<PlayerCommands>().SpawnTile(pos, bt.name);
            }
            else
            {
                Debug.Log("Not your turn");
            }


            if ((player.Equals("host")) && FindObjectOfType<MultiplayerTurnManager>().GetTurn()%2 == 0) {
                FindObjectOfType<PlayerCommands>().ChangeTurn();            
                }
            else if (player.Equals("client")&& FindObjectOfType<MultiplayerTurnManager>().GetTurn() % 2 != 0) {
                FindObjectOfType<PlayerCommands>().ChangeTurn();
            }
          
            FindObjectOfType<MultiplayerBiomeBuilding>().DeselectBiome();

        }

    }

    //I have no idea why its called SetColor but it sets plyer as host or client
    void SetColor() {
        var objects = GameObject.FindObjectsOfType<PlayerID>();

        foreach (var o in objects)
        {
            if (o.ToString().Contains("host"))
            {
                player = "host";
            }
            else if (o.ToString().Contains("client"))
            {
                player = "client";
            }
        }
    }

}
