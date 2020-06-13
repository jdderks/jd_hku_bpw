using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EconomyManager : MonoBehaviour
{
    public static float Money = 0;
    private UIManager uiManager;

    void Start()
    {
        uiManager = GetComponent<UIManager>();
    }
    
    void Update()
    {
        uiManager.MoneyText.text = "Money: " + Money.ToString();
    }
}
