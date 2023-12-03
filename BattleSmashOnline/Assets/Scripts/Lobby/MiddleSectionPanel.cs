using System;
using System.Collections;
using System.Collections.Generic;
using Fusion;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MiddleSectionPanel : LobbyPanelBase
{
    [Header("MiddleSectionPanel vars")] 
    [SerializeField] private Button _joinRandomRoomBtn;
    [SerializeField] private Button _joinRoomByArgBtn;
    [SerializeField] private Button _createRoomBtn;

    [SerializeField] private TMP_InputField _joinRoomByArgInputField;
    [SerializeField] private TMP_InputField _createRoomInputField;

    private NetworkRunnerController _networkRunnerController;

    public override void InitPanel(LobbyUiManager uiManager)
    {
        base.InitPanel(uiManager);

        _networkRunnerController = GlobalManagers.Instance.NetworkRunnerController;

        _joinRandomRoomBtn.onClick.AddListener(JoinRandomRoom);
        _joinRoomByArgBtn.onClick.AddListener(() => CreateRoom(GameMode.Client, _joinRoomByArgInputField.text));
        _createRoomBtn.onClick.AddListener(() => CreateRoom(GameMode.Host, _createRoomInputField.text));
    }

    private void JoinRandomRoom()
    {
        Debug.Log($"------------------------- Join Random Room ------------------------");
        _networkRunnerController.StartGame(GameMode.AutoHostOrClient, string.Empty);
    }

    private void CreateRoom(GameMode mode, string field)
    {
        if (field.Length >= 2)
        {
            Debug.Log($"-------------------------{mode}------------------------");
            _networkRunnerController.StartGame(mode, field);
        }
    }
}
