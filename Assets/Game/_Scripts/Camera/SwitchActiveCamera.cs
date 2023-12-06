using UnityEngine;
using Cinemachine;
public class SwitchActiveCamera : MonoBehaviour
{
    private CinemachineVirtualCamera _gameplayCamera;
    private void Awake()
    {
        _gameplayCamera = GetComponent<CinemachineVirtualCamera>();
    }
    private void Start()
    {
        EventBus.Instance.OnGameStarted += () => _gameplayCamera.Priority += 2;
    }
    private void OnDisable()
    {
        EventBus.Instance.OnGameStarted -= () => _gameplayCamera.Priority += 2;
    }
}
