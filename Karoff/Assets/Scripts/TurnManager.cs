using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class TurnManager : NetworkBehaviour
{


    [SyncVar] public string currentTurn;
    [SyncVar] public string PlayerHost;
    [SyncVar] public int turnNumber;

    public Color redColor;
    public Color blueColor;

    public Color blueDarkColor;
    public Color redDarkColor;

    public Image buildingsMenuBackground;
    //public Image gainBackground;
    //public Image[] priceBackgrounds;

    public Biome[] startingBiomes;

    private Camera mc;
    private ResourceManager rm;
    private WinManager wm;



    private void Awake()
    {



        mc = Camera.main;
        rm = gameObject.GetComponent<ResourceManager>();
        wm = FindObjectOfType<WinManager>();
    }

    private void Start()
    {
       

        Debug.Log(SceneManager.GetActiveScene().name);
        if (SceneManager.GetActiveScene().name == "") {
            Debug.Log("scena");
        }


        currentTurn = "Red";
        mc.backgroundColor = redColor;
        buildingsMenuBackground.color = redDarkColor;
        turnNumber = 0;

        /*
        gainBackground.color = redDarkColor;
        foreach (Image i in priceBackgrounds)
        {
            i.color = redColor;
        }*/

        foreach (Biome b in startingBiomes)
        {
            b.startingTile = true;
        }
    }




    public void SetHost(string id)
    {
       
        PlayerHost = id;
    }

    public string GetHost()
    {

        return PlayerHost;
    }





    public void ChangeTurn()
    {
        rm.EndTurnResources();
        turnNumber++;
        
        if(wm.goal == "Points")
        {
            wm.CheckPoints();
        } else if (wm.goal == "Turns")
        {
            wm.CheckTurns();
        }

        if (currentTurn == "Red")
        {
            currentTurn = "Blue";
            mc.backgroundColor = blueColor;
            buildingsMenuBackground.color = blueDarkColor;

            /*
            gainBackground.color = blueDarkColor;

            foreach(Image i in priceBackgrounds)
            {
                i.color = blueColor;
            }*/

        } else
        {
            currentTurn = "Red";
            mc.backgroundColor = redColor;
            buildingsMenuBackground.color = redDarkColor;

            /*gainBackground.color = redDarkColor;

            foreach(Image i in priceBackgrounds)
            {
                i.color = redColor;
            }*/

        }
    }


}

