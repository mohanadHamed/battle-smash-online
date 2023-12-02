using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyUiManager : MonoBehaviour
{
    [SerializeField] private LobbyPanelBase[] _lobbyPanels;

    private void Start()
    {
        foreach (var lobby in _lobbyPanels)
        {
            lobby.InitPanel(this);
        }
    }

    public void ShowPanel(LobbyPanelBase.LobbyPanelType lobbyType)
    {
        foreach (var lobby in _lobbyPanels)
        {
            if (lobby.PanelType == lobbyType)
            {
                //todo show panel
                lobby.ShowPanel();
                break;
            }
        }
    }
}
