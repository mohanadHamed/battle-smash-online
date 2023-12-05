using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyUiManager : MonoBehaviour
{
    [SerializeField] private LobbyPanelBase[] _lobbyPanels;
    [SerializeField] private LoadingCanvasController _loadingCanvasControllerPrefab;

    private void Start()
    {
        foreach (var lobby in _lobbyPanels)
        {
            lobby.InitPanel(this);
        }

        Instantiate(_loadingCanvasControllerPrefab);
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
