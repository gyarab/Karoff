using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MultiplayerBuildingDisplay : MonoBehaviour
{
    private string player;

    public Building building;

    public Image icon;

    public TextMeshProUGUI[] pricesTexts = new TextMeshProUGUI[4];

    public Image gainIcon;
    public Sprite[] posssibleGainIcons = new Sprite[5]; // Points, Sand, Wood, Stone, Ice

    public TextMeshProUGUI gainText;

    private MultiplayerTurnManager tm;
    private SyncResources sr;
    private MultiplayerResourceManager rm;
    private MultiplayerBiomeBuilding bb;
    private MultiplayerBuildingManager bm;

    private void Awake()
    {
        tm = FindObjectOfType<MultiplayerTurnManager>();
        rm = FindObjectOfType<MultiplayerResourceManager>();
        bb = FindObjectOfType<MultiplayerBiomeBuilding>();
        bm = FindObjectOfType<MultiplayerBuildingManager>();
        sr = FindObjectOfType<SyncResources>();
    }

    private void Start()
    {
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




        icon.sprite = building.buildingIcon;

        for (int i = 0; i < pricesTexts.Length; i++)
        {
            pricesTexts[i].text = "" + building.prices[i];
        }

        if (building.gain[0] != 0) // Awards Points
        {
            gainIcon.sprite = posssibleGainIcons[0];
            gainText.text = "" + building.gain[0];
        } else if (building.gain[1] != 0) // Awards Sand Multiplier
        {
            gainIcon.sprite = posssibleGainIcons[1];
            gainText.text = "" + building.gain[1];
        } else if (building.gain[2] != 0) // Awards Wood Multiplier
        {
            gainIcon.sprite = posssibleGainIcons[2];
            gainText.text = "" + building.gain[2];
        } else if (building.gain[3] != 0) // Awards Stone Multiplier
        {
            gainIcon.sprite = posssibleGainIcons[3];
            gainText.text = "" + building.gain[3];
        } else if (building.gain[4] != 0) // Awards Ice Multiplier
        {
            gainIcon.sprite = posssibleGainIcons[4];
            gainText.text = "" + building.gain[4];
        }
    }

    int change1;
    int change2;
    int change3;
    int change4;
    int change5;
    int change6;
    int change7;
    int change8;
    int change9;

    public void Buy()
    {
        if (tm.currentTurn == "Blue")
        {

            if (rm.blueResources[1] >= building.prices[0] && rm.blueResources[2] >= building.prices[1] && rm.blueResources[3] >= building.prices[2] && rm.blueResources[4] >= building.prices[3] && Array.Exists<BiomeType>(building.possibleBiomes, element => element == bb.selected.type))
            {
                rm.blueResources[1] -= building.prices[0];
                rm.blueResources[2] -= building.prices[1];
                rm.blueResources[3] -= building.prices[2];
                rm.blueResources[4] -= building.prices[3];
                change1 = building.prices[0];
                change2 = building.prices[1];
                change3 = building.prices[2];
                change4 = building.prices[3];

                if (building.gain[0] != 0)
                {
                    rm.blueResources[0] += building.gain[0];
                    change5 = building.gain[0];
                }
                else if (building.gain[1] != 0) {
                    rm.blueSandMultiplier += building.gain[1];
                    change6 = building.gain[1]; 
                } else if (building.gain[2] != 0)
                {
                    rm.blueWoodMultiplier += building.gain[2];
                    change7 = building.gain[2];
                } else if (building.gain[3] != 0)
                {
                    rm.blueStoneMultiplier += building.gain[3];
                    change8 = building.gain[3];
                } else if (building.gain[4] != 0)
                {
                    rm.blueIceMultiplier += building.gain[4];
                    change9 = building.gain[4];
                }


                //bb.lastSelected = bb.selected;
                //bb.selected.spr.sprite = building.buildingIcon;
                //bb.selected.spr.color = new Color(1f, 1f, 1f);


                if ((player.Equals("host")) && FindObjectOfType<MultiplayerTurnManager>().GetTurn() % 2 == 0)
                {

                    bb.selected.gameObject.GetComponentInParent<SyncTile>().SetTile(building.ToString());
                    FindObjectOfType<PlayerCommands>().SetMultipliers(change1, change2, change3, change4, change5, change6, change7, change8, change9, tm.currentTurn);
                    //FindObjectOfType<PlayerCommands>().SetSprite(building.ToString());
                    FindObjectOfType<PlayerCommands>().ChangeTurn();
                }
                else if (player.Equals("client") && FindObjectOfType<MultiplayerTurnManager>().GetTurn() % 2 != 0)
                {

                    bb.selected.gameObject.GetComponentInParent<SyncTile>().SetTile(building.ToString());
                    FindObjectOfType<PlayerCommands>().SetMultipliers(change1, change2, change3, change4, change5, change6, change7, change8, change9, tm.currentTurn);
                    //FindObjectOfType<PlayerCommands>().SetSprite(building.ToString());
                    FindObjectOfType<PlayerCommands>().ChangeTurn();
                }
                bm.ActivityOnBuildingsMenu(false);
                bb.DeselectBiome();

            }
            else
            {
                Debug.Log("Not enough resources, Blue.");
                return;
            }
        } else if (tm.currentTurn == "Red")
        {
            if (rm.redResources[1] >= building.prices[0] && rm.redResources[2] >= building.prices[1] && rm.redResources[3] >= building.prices[2] && rm.redResources[4] >= building.prices[3] && Array.Exists<BiomeType>(building.possibleBiomes, element => element == bb.selected.type))
            {
                rm.redResources[1] -= building.prices[0];
                rm.redResources[2] -= building.prices[1];
                rm.redResources[3] -= building.prices[2];
                rm.redResources[4] -= building.prices[3];
                change1 = building.prices[0];
                change2 = building.prices[1];
                change3 = building.prices[2];
                change4 = building.prices[3];
                if (building.gain[0] != 0)
                {
                    rm.redResources[0] += building.gain[0];
                    change5 = building.gain[0];
                }
                else if (building.gain[1] != 0)
                {
                    rm.redSandMultiplier += building.gain[1];
                    change6 = building.gain[1];
                }
                else if (building.gain[2] != 0)
                {
                    rm.redWoodMultiplier += building.gain[2];
                    change7 = building.gain[2];
                }
                else if (building.gain[3] != 0)
                {
                    rm.redStoneMultiplier += building.gain[3];
                    change8 = building.gain[3];
                }
                else if (building.gain[4] != 0)
                {
                    rm.redIceMultiplier += building.gain[4];
                    change9 = building.gain[4];
                }

                //Debug.Log(building.buildingIcon.ToString());

                //bb.selected.spr.sprite = building.buildingIcon;
                //bb.selected.spr.color = new Color(1f, 1f, 1f);
                //Debug.Log(bb.selected);

                //bb.lastSelected = bb.selected;


                if ((player.Equals("host")) && FindObjectOfType<MultiplayerTurnManager>().GetTurn() % 2 == 0)
                {
                    
                    bb.selected.gameObject.GetComponentInParent<SyncTile>().SetTile(building.ToString());
                    FindObjectOfType<PlayerCommands>().SetMultipliers(change1, change2, change3, change4, change5, change6, change7, change8, change9, tm.currentTurn);
                    //FindObjectOfType<PlayerCommands>().SetSprite(building.ToString());
                    FindObjectOfType<PlayerCommands>().ChangeTurn();
                }
                else if (player.Equals("client") && FindObjectOfType<MultiplayerTurnManager>().GetTurn() % 2 != 0)
                {

                    bb.selected.gameObject.GetComponentInParent<SyncTile>().SetTile(building.ToString());
                    FindObjectOfType<PlayerCommands>().SetMultipliers(change1, change2, change3, change4, change5, change6, change7, change8, change9, tm.currentTurn);
                    //FindObjectOfType<PlayerCommands>().SetSprite(building.ToString());
                    FindObjectOfType<PlayerCommands>().ChangeTurn();
                }
                bm.ActivityOnBuildingsMenu(false);
                bb.DeselectBiome();

            }
            else
            {
                Debug.Log("Not enough resources, Red.");
                return;
            }
        }
    }


}
