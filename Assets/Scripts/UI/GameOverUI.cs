using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private GameObject m_panel;

    public void ShowPanel(bool show)
    {
        GameController.ChangeControlState(!show);
        m_panel.SetActive(show);
    }

    public void Retry()
    {
        ShowPanel(false);
    }
}
