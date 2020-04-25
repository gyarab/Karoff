using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourceManager : MonoBehaviour
{

    // Points, Sand, Wood, Stone, Ice

    [Header("Resources")]
    public int[] blueResources = {0, 0, 0, 0, 0};
    public int[] redResources = {0, 0, 0, 0, 0};

    private void Start()
    {
        UpdateUITexts();
    }

    #region ChangeFunctions
    public void ChangeBluePoints(int points)
    {
        blueResources[0] += points;
    }

    public void ChangeRedPoints(int points)
    {
        redResources[0] += points;
    }

    public void ChangeBlueSand(int sand)
    {
        blueResources[1] += sand;
    }

    public void ChangeRedSand(int sand)
    {
        redResources[1] += sand;
    }

    public void ChangeBlueWood(int wood)
    {
        blueResources[2] += wood;
    }

    public void ChangeRedWood(int wood)
    {
        redResources[2] += wood;
    }

    public void ChangeBlueStone(int stone)
    {
        blueResources[3] += stone;
    }

    public void ChangeRedStone(int stone)
    {
        redResources[3] += stone;
    }

    public void ChangeBlueIce(int ice)
    {
        blueResources[4] += ice;
    }

    public void ChangeRedIce(int ice)
    {
        redResources[4] += ice;
    }
    #endregion

    [Space]
    [Header("Multipliers")]

    #region BlueMultipliers
    public int blueSandMultiplier = 1;
    public int blueWoodMultiplier = 1;
    public int blueStoneMultiplier = 1;
    public int blueIceMultiplier = 1;
    #endregion

    #region RedMultipliers
    public int redSandMultiplier = 1;
    public int redWoodMultiplier = 1;
    public int redStoneMultiplier = 1;
    public int redIceMultiplier = 1;
    #endregion

    public void EndTurnResources()
    {
        ChangeBlueSand(blueSandMultiplier);
        ChangeBlueWood(blueWoodMultiplier);
        ChangeBlueStone(blueStoneMultiplier);
        ChangeBlueIce(blueIceMultiplier);

        ChangeRedSand(redSandMultiplier);
        ChangeRedWood(redWoodMultiplier);
        ChangeRedStone(redStoneMultiplier);
        ChangeRedIce(redIceMultiplier);

        UpdateUITexts();
    }

    [Space]
    [Header("UITexts")]

    #region BlueUITexts
    public TextMeshProUGUI bluePointsText;
    public TextMeshProUGUI blueSandText;
    public TextMeshProUGUI blueWoodText;
    public TextMeshProUGUI blueStoneText;
    public TextMeshProUGUI blueIceText;
    #endregion

    #region RedUITexts
    public TextMeshProUGUI redPointsText;
    public TextMeshProUGUI redSandText;
    public TextMeshProUGUI redWoodText;
    public TextMeshProUGUI redStoneText;
    public TextMeshProUGUI redIceText;
    #endregion

    public void UpdateUITexts()
    {
        bluePointsText.text = "" + blueResources[0];
        blueSandText.text = "" + blueResources[1];
        blueWoodText.text = "" + blueResources[2];
        blueStoneText.text = "" + blueResources[3];
        blueIceText.text = "" + blueResources[4];

        redPointsText.text = "" + redResources[0];
        redSandText.text = "" + redResources[1];
        redWoodText.text = "" + redResources[2];
        redStoneText.text = "" + redResources[3];
        redIceText.text = "" + redResources[4];
    }




}
