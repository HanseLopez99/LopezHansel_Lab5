using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    Text text;
    public static int coinAmount;
    private GameObject[] totalCoinAmount; 
    public int getArrayLenght()
    {
        return this.totalCoinAmount.Length;
    }

    void Start()
    {
        text = GetComponent<Text>();
        totalCoinAmount = GameObject.FindGameObjectsWithTag("Coin");
    }

    void Update()
    {
        text.text = coinAmount.ToString()+"/"+getArrayLenght();
    }
}
