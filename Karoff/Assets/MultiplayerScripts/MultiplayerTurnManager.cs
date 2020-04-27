using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MultiplayerTurnManager : NetworkBehaviour
{
    public string currentTurn;
    public GameObject o;
    [SyncVar] public int turn = 0;

    public Color redColor;
    public Color blueColor;

    public Color blueDarkColor;
    public Color redDarkColor;

    public Image buildingsMenuBackground;


    private Camera mc;
    public MultiplayerResourceManager rm;
    public MultiplayerWinManager wm;


    private void Awake()
    {
        mc = Camera.main;
    }


    public int GetTurn()
    {
        return turn;
    }


    // almost everything what does "druha faze" does is called there
    public void SetTurn()
    {
        Debug.Log(rm);
        rm.EndTurnResources();
        turn += 1;
        WinCheck();

        if (currentTurn == "Red" && turn%2!=0)
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

            }
            else
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



    //sets backgrounds
    private void Start()
    {

        if (turn % 2 == 0)
        {
            currentTurn = "Red";
            mc.backgroundColor = redColor;
            buildingsMenuBackground.color = redDarkColor;
        }
        else {
            currentTurn = "Blue";
            mc.backgroundColor = blueColor;
            buildingsMenuBackground.color = blueDarkColor;
        }
       


    }

    //checks win conditions
    public void WinCheck()
    {
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



