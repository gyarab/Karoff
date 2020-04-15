﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerCommands : NetworkBehaviour
{
    RaycastHit hit;
    public GameObject GridCell;
    GameObject turnManager;
    public BiomeType Desert;
    public BiomeType Forest;
    public BiomeType Mountains;
    public BiomeType Snow;
    private BiomeType biomeType;






    //public GameObject tile;

    private void Start()
    {
        turnManager = GameObject.Find("TurnManager");
    }

    void Update()
    {

    }




   public void SpawnTile(Vector3 pos, string bt) {
        CmdSpawnObject(pos, bt);
    }

    public void ChangeTurn() 
    {
        CmdChangeTurn();
    }

    [Command]
    void CmdSpawnObject(Vector3 pos, string bt) 
    {

        GameObject tile = Instantiate(GridCell, pos, Quaternion.identity) as GameObject;

        NetworkServer.SpawnWithClientAuthority(tile, connectionToClient);
        NetworkIdentity NI = tile.GetComponent<NetworkIdentity>();
        NI.AssignClientAuthority(connectionToClient);
        RpcTileSettings(tile, bt);
        NI.RemoveClientAuthority(connectionToClient);

    }

    [ClientRpc]
    public void RpcTileSettings(GameObject tile, string bt) {

        if (bt.Equals("Desert")) {
            biomeType = Desert;
        }
        else if (bt.Equals("Forest")) {
            biomeType = Forest;
        }
        else if (bt.Equals("Mountains")) {
            biomeType = Mountains;
        }
        else if (bt.Equals("Snow")) {
            biomeType = Snow;
        }


        tile.transform.Find("Biome").GetComponent<MultiplayerBiome>().BuildingSpaces.SetActive(false);

        tile.GetComponent<SyncTile>().bt = bt;
        tile.transform.Find("Biome").GetComponent<MultiplayerBiome>().type = biomeType;

        tile.GetComponent<SyncTile>().starting = false;
        tile.transform.Find("Biome").GetComponent<MultiplayerBiome>().startingTile = false;


        tile.transform.Find("Biome").GetComponent<MultiplayerBiome>().NewColor();
        

        //object1.GetComponent<MeshRenderer>().material.color = Color.blue;
        //object1.GetComponent<SaveCellData>().SetColor(Color.blue);
    }




    [Command]
    void CmdChangeTurn()
    {
        NetworkIdentity NI = turnManager.GetComponent<NetworkIdentity>();
        NI.AssignClientAuthority(connectionToClient);
        RpcChangeTurn(turnManager);
        NI.RemoveClientAuthority(connectionToClient);
    }

    [ClientRpc]
    public void RpcChangeTurn(GameObject turnO)
    {

        turnO.GetComponent<MultiplayerTurnManager>().SetTurn();
    }


}


//jentak btw sem davam odkazy z kterych se cerpalo pri tvorbe 
//https://answers.unity.com/questions/411793/selecting-a-game-object-with-a-mouse-click-on-it.html
//https://www.raywenderlich.com/2826197-scriptableobject-tutorial-getting-started#toc-anchor-003
//https://docs.unity3d.com/Manual/index.html
//https://answers.unity.com/questions/534582/accessing-variable-defined-in-a-script-attached-to.html

