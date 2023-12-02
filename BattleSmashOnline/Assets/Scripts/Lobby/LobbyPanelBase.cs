using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyPanelBase : MonoBehaviour
{
    public LobbyPanelType PanelType => _panelType;

    [Header("LobbyPanelBase Vars")]
    [SerializeField] private LobbyPanelType _panelType;
    [SerializeField] private Animator _panelAnimator;

    protected LobbyUiManager _lobbyUiManager;

    public enum LobbyPanelType
    {
        None,
        CreateNicknamePanel,
        MiddleSectionPanel
    }

    public virtual void InitPanel(LobbyUiManager uiManager)
    {
        _lobbyUiManager = uiManager;
    }

    public void ShowPanel()
    {
        gameObject.SetActive(true);
        const string popInClipName = "In";
        _panelAnimator.Play(popInClipName);
    }

    protected void ClosePanel()
    {
        const string popOutClipName = "Out";
        
        StartCoroutine(Utilities.PlayANimAndSetStateWhenFinished(gameObject, _panelAnimator, popOutClipName, false));
    }
}
