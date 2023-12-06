using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] private GameObject _winScreen;
    [SerializeField] private GameObject _looseScreen;
    private void Start()
    {
        EventBus.Instance.OnGameWin += () => _winScreen.SetActive(true);
        EventBus.Instance.OnGameLoose += () => _looseScreen.SetActive(true);
    }
    private void OnDisable()
    {
        EventBus.Instance.OnGameWin -= () => _winScreen.SetActive(true);
        EventBus.Instance.OnGameLoose -= () => _looseScreen.SetActive(true);
    }
}
