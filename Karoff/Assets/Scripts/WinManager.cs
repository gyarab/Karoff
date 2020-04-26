using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class WinManager : MonoBehaviour
{
    public int numberOfTurns; // -1 => Not playing for turns
    public int numberOfPoints; // -1 => Not playing for points

    public string goal; // "Points" / "Turns"

    private ResourceManager rm;
    private TurnManager tm;

    public GameObject winScreen;
    public TextMeshProUGUI winner;

    private void Awake()
    {
        rm = FindObjectOfType<ResourceManager>();
        tm = FindObjectOfType<TurnManager>();
    }

    private void Start()
    {
        if(numberOfTurns == -1)
        {
            goal = "Points";
        } else if (numberOfPoints == -1)
        {
            goal = "Turns";
        }
    }

    public void CheckPoints()
    {
        if (rm.blueResources[0] >= numberOfPoints)
        {
            Debug.Log("Blue Wins!");

            winScreen.SetActive(true);
            winner.SetText("Blue Wins!");

            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            return;
        }

        if (rm.redResources[0] >= numberOfPoints)
        {
            Debug.Log("Red Wins!");

            winScreen.SetActive(true);
            winner.SetText("Red Wins!");

            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            return;
        }
    }

    public void CheckTurns()
    {
        if(tm.turnNumber >= numberOfTurns)
        {
            if(rm.blueResources[0] > rm.redResources[0])
            {
                Debug.Log("Blue Wins!");

                winScreen.SetActive(true);
                winner.SetText("Blue Wins!");

                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                return;
            } else if(rm.redResources[0] > rm.blueResources[0])
            {
                Debug.Log("Red Wins!");

                winScreen.SetActive(true);
                winner.SetText("Red Wins!");

                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                return;
            } else
            {
                Debug.Log("Tie!");

                winScreen.SetActive(true);
                winner.SetText("Tie!");

                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                return;
            }
        }
    }
}
