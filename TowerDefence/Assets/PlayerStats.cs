using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static int coin;
    public int startMoney=100;
    public TextMeshProUGUI moneyText;
    public int health=100;
    public Slider healthSlider;

    private void Start()
    {
        coin = startMoney;//Staic variable carries over from one scene to another
        healthSlider.maxValue = healthSlider.value;
        healthSlider.value = health;
    }
    private void Update()
    {
        moneyText.SetText("$" + coin.ToString());
    }
    
}
