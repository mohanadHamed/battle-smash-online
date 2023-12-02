using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreateNicknamePanel : LobbyPanelBase
{
    [Header("CreateNicknamePanel Vars")]
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private Button _createNicknameButton;

    private const int MaxCharForNickname = 2;

    public override void InitPanel(LobbyUiManager uiManager)
    {
        base.InitPanel(uiManager);

        _createNicknameButton.interactable = false;
        _createNicknameButton.onClick.AddListener(OnClickCreateNickname);
        _inputField.onValueChanged.AddListener(OnInputValueChanged);
    }

    private void OnInputValueChanged(string arg0)
    {
        _createNicknameButton.interactable = arg0.Length >= MaxCharForNickname;
    }

    private void OnClickCreateNickname()
    {
        var nickname = _inputField.text;

        if (nickname.Length >= MaxCharForNickname)
        {
            base.ClosePanel();
            _lobbyUiManager.ShowPanel(LobbyPanelType.MiddleSectionPanel);
        }
    }
}
