using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private GameObject m_panel;

    public void ShowPanel(bool show)
    {
        GameManager.ChangeControlState(!show);
        m_panel.SetActive(show);
    }
}
