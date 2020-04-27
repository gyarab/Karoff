using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpacesColor : MonoBehaviour
{
    public Color color;
    private string player;
    int turn;

    //sets MultiplayerTurnManager script turn variable as int turn
    private void Awake()
    {
        turn = GameObject.FindObjectOfType<MultiplayerTurnManager>().turn;
    }


    void Update()
    {
        //sets player as host if its host or client if client
        var objects = GameObject.FindObjectsOfType<PlayerID>();
        foreach (var o in objects)
        {

            //Debug.Log(o.ToString());
            if (o.ToString().Contains("host"))
            {
                player = "host";
            }
            else if (o.ToString().Contains("client"))
            {
                player = "client";
            }
        }

        //sets color of preview for building tiles
        if (isActiveAndEnabled && GetComponent<MultiplayerBuildingSpace>().clickable) {
            if ((player.Equals("host")) && FindObjectOfType<MultiplayerTurnManager>().GetTurn() % 2 == 0)
            {

                color = new Color(1f, 1f, 1f, 0.5f);
                this.GetComponent<SpriteRenderer>().color = color;
            }
            else if(player.Equals("client") && FindObjectOfType<MultiplayerTurnManager>().GetTurn() % 2 != 0)
            {
                color = new Color(1f, 1f, 1f, 0.5f);
                this.GetComponent<SpriteRenderer>().color = color;
            }
            else {
                color = new Color(1f, 0f, 0f, 0.5f);
                this.GetComponent<SpriteRenderer>().color = color;
            }
        }
        //sets turn deselects biome
        if(turn != GameObject.FindObjectOfType<MultiplayerTurnManager>().turn) {
            turn = GameObject.FindObjectOfType<MultiplayerTurnManager>().turn;
            FindObjectOfType<MultiplayerBiomeBuilding>().DeselectBiome();
        }
    }
}
