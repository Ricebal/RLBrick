using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_coinsText;

    public void SetCoinText(float amount)
    {
        m_coinsText.text = "Coins: " + amount;
    }
}
