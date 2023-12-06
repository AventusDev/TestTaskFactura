using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class RestartLevelButton : MonoBehaviour
{
    private Button _button;
    void Start()
    {
        _button = GetComponent<Button>();

        _button.onClick.AddListener(() => RestartLevel());
    }
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
