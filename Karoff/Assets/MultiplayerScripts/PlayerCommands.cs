using System.Collections;
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
    GameObject GameManager;
    GameObject ResourceManager;

    public MultiplayerBiomeBuilding MBB;

    //finds and selects
    private void Start()
    {
        turnManager = GameObject.Find("TurnManager");
        GameManager = GameObject.Find("GameManager");
        ResourceManager = GameObject.Find("ResourceManager");
        MBB = GameManager.GetComponent<MultiplayerBiomeBuilding>();
    }

    //function to call command to set sprite
    public void SetSprite(string building, GameObject o)
    {

        CmdSetSprite(building, o);
    }

    //command to server to call rpcsetsprite as server
    [Command]
    public void CmdSetSprite(string building, GameObject o) {
        RpcSetSprite(building, o);
    }

    //sets sprite for clients
    [ClientRpc]
    public void RpcSetSprite(string building, GameObject o)
    {
        o.GetComponent<SyncTile>().spr = building;

    }

    //function to call commend to spawn tile
    public void SpawnTile(Vector3 pos, string bt) {
        CmdSpawnObject(pos, bt);
    }

    //function to call command to change turn
    public void ChangeTurn() 
    {
        CmdChangeTurn();
    }

    //sets authority and instantiates new tile as server then sets its settings as server on clients
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

    //sets new tile settings on clients
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

        //there was code from testing project can still be finded in versions under 0.8v karoff on github
    }


    //server changes turn for clients
    [Command]
    void CmdChangeTurn()
    {
        NetworkIdentity NI = turnManager.GetComponent<NetworkIdentity>();
        NI.AssignClientAuthority(connectionToClient);
        RpcChangeTurn(turnManager);
        NI.RemoveClientAuthority(connectionToClient);

    }

    //changes turns on clients
    [ClientRpc]
    public void RpcChangeTurn(GameObject turnO)
    {

        turnO.GetComponent<MultiplayerTurnManager>().SetTurn();
        turnO.GetComponent<SyncResources>().ChangeResources();
    }

    //sets multipliers function to call command to server to set...
    public void SetMultipliers(int c1, int c2, int c3, int c4, int c5, int c6, int c7, int c8, int c9, string c) {
        CmdSetMultipliers(c1, c2, c3, c4, c5, c6, c7, c8, c9, c);
    }

    //server calls function on clients to set new values
    [Command]
    void CmdSetMultipliers(int c1, int c2, int c3, int c4, int c5, int c6, int c7, int c8, int c9, string c)
    {
        NetworkIdentity NI = turnManager.GetComponent<NetworkIdentity>();
        NI.AssignClientAuthority(connectionToClient);
        RpcSetMultipliers(c1, c2, c3, c4, c5, c6, c7, c8, c9, turnManager, c);
        NI.RemoveClientAuthority(connectionToClient);

    }

    //calls local function on clients to change values
    [ClientRpc]
    public void RpcSetMultipliers(int c1, int c2, int c3, int c4, int c5, int c6, int c7, int c8, int c9, GameObject turnO, string c)
    {
        turnO.GetComponent<SyncResources>().ChangeMultipliers(c1, c2, c3, c4, c5, c6, c7, c8, c9, c);
    }

    //function to command server to skip turn
    public void Skip()
    {
        CmdSkip();
    }

    //server calls skip turn on clients
    [Command]
    void CmdSkip() {
        NetworkIdentity NI = turnManager.GetComponent<NetworkIdentity>();
        NI.AssignClientAuthority(connectionToClient);
        RpcSkip(turnManager);
        NI.RemoveClientAuthority(connectionToClient);
    }

    //on clients is called skip turn (by server)
    [ClientRpc]
    void RpcSkip(GameObject turn) {
        turn.GetComponent<SyncResources>().skipTurn();
    }


}


// tu byli zapisovany zdroje dokud nemeli pekne misto v dokumentu
