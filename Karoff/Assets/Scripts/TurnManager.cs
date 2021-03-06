﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TurnManager : MonoBehaviour
{


    public string currentTurn;
  
    public int turnNumber;

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

    //sets starting player and tun
    private void Start()
    {
        Debug.Log(SceneManager.GetActiveScene().name);

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

    //change turn "automaticka druha faze"
    public void ChangeTurn()
    {
        rm.EndTurnResources();
        turnNumber++;

        WinCheck();

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
        
    //checks win conditions
    protected void WinCheck() {
        if (wm.goal == "Points")
        {
            wm.CheckPoints();
        }
        else if (wm.goal == "Turns")
        {
            wm.CheckTurns();
        }
    }

}


