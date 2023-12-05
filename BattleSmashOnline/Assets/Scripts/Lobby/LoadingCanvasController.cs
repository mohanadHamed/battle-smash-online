using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingCanvasController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Button _cancellationBtn;

    private NetworkRunnerController _networkRunnerController;


    private void Start()
    {
        _networkRunnerController = GlobalManagers.Instance.NetworkRunnerController;
        _networkRunnerController.OnStartRunnerConnection += NetworkRunnerController_OnStartRunnerConnection;
        _networkRunnerController.OnPlayerJoinedSuccessfully += NetworkRunnerController_OnPlayerJoinedSuccessfully;

        _cancellationBtn.onClick.AddListener(CancelRequest);

        gameObject.SetActive(false);
    }

    private void NetworkRunnerController_OnPlayerJoinedSuccessfully()
    {
        const string clipName = "Out";

        StartCoroutine(Utilities.PlayAnimAndSetStateWhenFinished(gameObject, _animator, clipName, false));
    }

    private void NetworkRunnerController_OnStartRunnerConnection()
    {
        gameObject.SetActive(true);
        const string clipName = "In";

        StartCoroutine(Utilities.PlayAnimAndSetStateWhenFinished(gameObject, _animator, clipName));
    }

    private void CancelRequest()
    {
        _networkRunnerController.ShutdownRunner();
    }

    private void OnDestroy()
    {
        _networkRunnerController.OnStartRunnerConnection -= NetworkRunnerController_OnStartRunnerConnection;
        _networkRunnerController.OnPlayerJoinedSuccessfully -= NetworkRunnerController_OnPlayerJoinedSuccessfully;
    }
}
