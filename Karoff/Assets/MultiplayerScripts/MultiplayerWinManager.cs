using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class MultiplayerWinManager : MonoBehaviour
{
    public int numberOfTurns; // -1 => Not playing for turns
    public int numberOfPoints; // -1 => Not playing for points

    public string goal; // "Points" / "Turns"



    private MultiplayerResourceManager rm;
    private MultiplayerTurnManager tm;


    public GameObject winScreen;
    public TextMeshProUGUI winner;

    public int music = 1;
    public int music2Trigger = 10;
    public int music3Trigger = 20;

    private void Awake()
    {
        rm = FindObjectOfType<MultiplayerResourceManager>();
        tm = FindObjectOfType<MultiplayerTurnManager>();
    }

    private void Start()
    {
        if (numberOfTurns == -1)
        {
            goal = "Points";
        }
        else if (numberOfPoints == -1)
        {
            goal = "Turns";
        }
    }

    public void CheckPoints()
    {
        if (rm.blueResources[0] >= numberOfPoints)
        {
            if(rm.redResources[0] >= numberOfPoints) {
                Debug.Log("Red Wins!");

                winScreen.SetActive(true);
                winner.SetText("Red Wins!");
                FindObjectOfType<AudioManager>().Play("Main1");
                StartCoroutine(CrossFade(FindObjectOfType<AudioManager>().Sound("Main3"), FindObjectOfType<AudioManager>().Sound("Main1")));
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                return;
            }

            Debug.Log("Blue Wins!");

            winScreen.SetActive(true);
            winner.SetText("Blue Wins!");
            FindObjectOfType<AudioManager>().Play("Main1");
            StartCoroutine(CrossFade(FindObjectOfType<AudioManager>().Sound("Main3"), FindObjectOfType<AudioManager>().Sound("Main1")));

            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            return;
        }

        if (rm.redResources[0] >= numberOfPoints)
        {

            if (rm.blueResources[0] >= numberOfPoints)
            {
                Debug.Log("Blue Wins!");

                winScreen.SetActive(true);
                winner.SetText("Blue Wins!");
                FindObjectOfType<AudioManager>().Play("Main1");
                StartCoroutine(CrossFade(FindObjectOfType<AudioManager>().Sound("Main3"), FindObjectOfType<AudioManager>().Sound("Main1")));
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                return;
            }
            Debug.Log("Red Wins!");

            winScreen.SetActive(true);
            winner.SetText("Red Wins!");
            FindObjectOfType<AudioManager>().Play("Main1");
            StartCoroutine(CrossFade(FindObjectOfType<AudioManager>().Sound("Main3"), FindObjectOfType<AudioManager>().Sound("Main1")));
            //GetComponent<MenuNetworkManager>().StopHosting();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            return;
        }

        if (music == 1 && (rm.blueResources[0] >= music2Trigger || rm.redResources[0] >= music2Trigger))
        {
            music = 2;
            //FindObjectOfType<AudioManager>().Stop("Main1");
            FindObjectOfType<AudioManager>().Play("Main2");
            StartCoroutine(CrossFade(FindObjectOfType<AudioManager>().Sound("Main1"), FindObjectOfType<AudioManager>().Sound("Main2")));
            return;
        }

        if (music == 2 && (rm.blueResources[0] >= music3Trigger || rm.redResources[0] >= music3Trigger))
        {
            music = 3;
            //FindObjectOfType<AudioManager>().Stop("Main2");
            FindObjectOfType<AudioManager>().Play("Main3");
            StartCoroutine(CrossFade(FindObjectOfType<AudioManager>().Sound("Main2"), FindObjectOfType<AudioManager>().Sound("Main3")));
            return;
        }
    }

    public IEnumerator CrossFade(Sound end, Sound start)
    {
        bool done = false;
        float startVol = start.source.volume;
        start.source.volume = 0f;

        while (!done)
        {
            end.source.volume -= Time.deltaTime;
            start.source.volume += Time.deltaTime;

            if (end.source.volume <= 0f && start.source.volume >= startVol)
            {
                done = true;
            }

            yield return new WaitForEndOfFrame();
        }

        end.source.Stop();
    }

    public void CheckTurns()
    {
        if (tm.turn >= numberOfTurns)
        {
            if (rm.blueResources[0] > rm.redResources[0])
            {
                if (rm.redResources[0] >= numberOfPoints)
                {
                    Debug.Log("Red Wins!");

                    winScreen.SetActive(true);
                    winner.SetText("Red Wins!");
                    FindObjectOfType<AudioManager>().Play("Main1");
                    StartCoroutine(CrossFade(FindObjectOfType<AudioManager>().Sound("Main3"), FindObjectOfType<AudioManager>().Sound("Main1")));
                    //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                    return;
                }
                else
                {
                    Debug.Log("Blue Wins!");

                    winScreen.SetActive(true);
                    winner.SetText("Blue Wins!");
                    FindObjectOfType<AudioManager>().Play("Main1");
                    StartCoroutine(CrossFade(FindObjectOfType<AudioManager>().Sound("Main3"), FindObjectOfType<AudioManager>().Sound("Main1")));
                    //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                    return;
                }
            }
            else if (rm.redResources[0] > rm.blueResources[0])
            {
                if (rm.blueResources[0] >= numberOfPoints)
                {
                    Debug.Log("Blue Wins!");

                    winScreen.SetActive(true);
                    winner.SetText("Blue Wins!");
                    FindObjectOfType<AudioManager>().Play("Main1");
                    StartCoroutine(CrossFade(FindObjectOfType<AudioManager>().Sound("Main3"), FindObjectOfType<AudioManager>().Sound("Main1")));
                    //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                    return;
                }
                else
                {

                    Debug.Log("Red Wins!");

                    winScreen.SetActive(true);
                    winner.SetText("Red Wins!");
                    FindObjectOfType<AudioManager>().Play("Main1");
                    StartCoroutine(CrossFade(FindObjectOfType<AudioManager>().Sound("Main3"), FindObjectOfType<AudioManager>().Sound("Main1")));
                    //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                    return;
                }
            }
            else
            {
                Debug.Log("Tie!");

                winScreen.SetActive(true);
                winner.SetText("Tie!");
                FindObjectOfType<AudioManager>().Play("Main1");
                StartCoroutine(CrossFade(FindObjectOfType<AudioManager>().Sound("Main3"), FindObjectOfType<AudioManager>().Sound("Main1")));
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                return;
            }
        }
    }
}

