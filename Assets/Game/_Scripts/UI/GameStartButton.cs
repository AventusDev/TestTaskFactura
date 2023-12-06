using UnityEngine;
using UnityEngine.UI;

public class GameStartButton : MonoBehaviour
{
    private Button _button;

    void Start()
    {
        _button = GetComponent<Button>();

        _button.onClick.AddListener
        (() =>
            {
                EventBus.Instance.OnGameStarted?.Invoke();
                this.gameObject.SetActive(false);
            }
        );
    }
}
