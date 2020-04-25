using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SyncResources : NetworkBehaviour
{
    // Points, Sand, Wood, Stone, Ice

    [SyncVar] public int blueResources0 = 0;
    [SyncVar] public int redResources0 = 0;

    [SyncVar] public int blueResources1 = 0;
    [SyncVar] public int blueResources2 = 0;
    [SyncVar] public int blueResources3 = 0;
    [SyncVar] public int blueResources4 = 0;

    [SyncVar] public int redResources1 = 0;
    [SyncVar] public int redResources2 = 0;
    [SyncVar] public int redResources3 = 0;
    [SyncVar] public int redResources4 = 0;


    [SyncVar] public int blueSandMultiplier = 1;

    [SyncVar] public int blueWoodMultiplier = 1;

    [SyncVar] public int blueStoneMultiplier = 1;

    [SyncVar] public int blueIceMultiplier = 1;

    [SyncVar] public int redSandMultiplier = 1;

    [SyncVar] public int redWoodMultiplier = 1;

    [SyncVar] public int redStoneMultiplier = 1;

    [SyncVar] public int redIceMultiplier = 1;

    GameObject ResourceManager;

    // Start is called before the first frame update
    void Start()
    {
        ResourceManager = GameObject.Find("ResourceManager");
        InvokeRepeating("SetRes", 0, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {


    }

    void SetRes() {

        ResourceManager.GetComponent<MultiplayerResourceManager>().blueResources[0] = blueResources0;
        ResourceManager.GetComponent<MultiplayerResourceManager>().blueResources[1] = blueResources1;
        ResourceManager.GetComponent<MultiplayerResourceManager>().blueResources[2] = blueResources2;
        ResourceManager.GetComponent<MultiplayerResourceManager>().blueResources[3] = blueResources3;
        ResourceManager.GetComponent<MultiplayerResourceManager>().blueResources[4] = blueResources4;

        ResourceManager.GetComponent<MultiplayerResourceManager>().redResources[0] = redResources0;
        ResourceManager.GetComponent<MultiplayerResourceManager>().redResources[1] = redResources1;
        ResourceManager.GetComponent<MultiplayerResourceManager>().redResources[2] = redResources2;
        ResourceManager.GetComponent<MultiplayerResourceManager>().redResources[3] = redResources3;
        ResourceManager.GetComponent<MultiplayerResourceManager>().redResources[4] = redResources4;

        ResourceManager.GetComponent<MultiplayerResourceManager>().blueIceMultiplier = blueIceMultiplier;
        ResourceManager.GetComponent<MultiplayerResourceManager>().blueSandMultiplier = blueSandMultiplier;
        ResourceManager.GetComponent<MultiplayerResourceManager>().blueStoneMultiplier = blueStoneMultiplier;
        ResourceManager.GetComponent<MultiplayerResourceManager>().blueWoodMultiplier = blueWoodMultiplier;

        ResourceManager.GetComponent<MultiplayerResourceManager>().redIceMultiplier = redIceMultiplier;
        ResourceManager.GetComponent<MultiplayerResourceManager>().redSandMultiplier = redSandMultiplier;
        ResourceManager.GetComponent<MultiplayerResourceManager>().redStoneMultiplier = redStoneMultiplier;
        ResourceManager.GetComponent<MultiplayerResourceManager>().redWoodMultiplier = redWoodMultiplier;
    }

    public void ChangeResources() {
        blueResources1 += ResourceManager.GetComponent<MultiplayerResourceManager>().blueSandMultiplier;
        blueResources2 += ResourceManager.GetComponent<MultiplayerResourceManager>().blueWoodMultiplier;
        blueResources3 += ResourceManager.GetComponent<MultiplayerResourceManager>().blueStoneMultiplier;
        blueResources4 += ResourceManager.GetComponent<MultiplayerResourceManager>().blueIceMultiplier;
        redResources1 += ResourceManager.GetComponent<MultiplayerResourceManager>().redSandMultiplier;
        redResources2 += ResourceManager.GetComponent<MultiplayerResourceManager>().redWoodMultiplier;
        redResources3 += ResourceManager.GetComponent<MultiplayerResourceManager>().redStoneMultiplier;
        redResources4 += ResourceManager.GetComponent<MultiplayerResourceManager>().redIceMultiplier;

    }

    public void ChangeMultipliers(int c1, int c2, int c3, int c4, int c5, int c6, int c7, int c8, int c9, string c) {
        if (c == "Blue")
        {
            blueResources1 -= c1;
            blueResources2 -= c2;
            blueResources3 -= c3;
            blueResources4 -= c4;
            blueResources0 += c5;
            blueSandMultiplier += c6;
            blueWoodMultiplier += c7;
            blueStoneMultiplier += c8;
            blueIceMultiplier += c9;
        }
        else if (c == "Red") {
            redResources1 -= c1;
            redResources2 -= c2;
            redResources3 -= c3;
            redResources4 -= c4;
            redResources0 += c5;
            redSandMultiplier += c6;
            redWoodMultiplier += c7;
            redStoneMultiplier += c8;
            redIceMultiplier += c9;
        }
    }

    public void skipTurn() {
       if(FindObjectOfType<MultiplayerTurnManager>().currentTurn == "Red") {
            if (redResources0 - 3 < 0)
            {
                redResources0 = 0;
            }
            else
            {
                redResources0 -= 3; 
            }

            redResources1 = Mathf.FloorToInt(redResources1 * 0.6f);
            redResources2 = Mathf.FloorToInt(redResources2 * 0.6f);
            redResources3 = Mathf.FloorToInt(redResources3 * 0.6f);
            redResources4 = Mathf.FloorToInt(redResources4 * 0.6f);


        }
       else if (FindObjectOfType<MultiplayerTurnManager>().currentTurn == "Blue") {
            if (blueResources0 - 3 < 0)
            {
                blueResources0 = 0;
            }
            else
            {
                blueResources0 -= 3;
            }

            blueResources1 = Mathf.FloorToInt(blueResources1 * 0.6f);
            blueResources2 = Mathf.FloorToInt(blueResources2 * 0.6f);
            blueResources3 = Mathf.FloorToInt(blueResources3 * 0.6f);
            blueResources4 = Mathf.FloorToInt(blueResources4 * 0.6f);
        }
    }
}
