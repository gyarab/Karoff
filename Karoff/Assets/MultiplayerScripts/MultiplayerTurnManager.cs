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
        //rm = gameObject.GetComponent<MultiplayerResourceManager>();
        //wm = FindObjectOfType<WinManager>();
    }


    private void Update()
    {

    }

    public int GetTurn()
    {
        return turn;
    }

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


    private void Start()
    {


        Debug.Log(SceneManager.GetActiveScene().name);

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



