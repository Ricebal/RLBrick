using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemUI : MonoBehaviour
{
    [SerializeField] private Item m_item;
    [SerializeField] private TextMeshProUGUI m_nameText;
    [SerializeField] private TextMeshProUGUI m_descriptionText;
    [SerializeField] private TextMeshProUGUI m_priceText;

    private void Start()
    {
        m_nameText.text = m_item.Name;
        m_descriptionText.text = m_item.Description;
        m_priceText.text = "Price: " + m_item.Cost;
    }

    public void BuyItem()
    {
        if (ScoreManager.RemoveCoins(m_item.Cost))
        {
            Debug.Log("Bought: " + m_item.Name);
        }
        else
        {
            Debug.Log("Not enough coins");
        }
    }
}
