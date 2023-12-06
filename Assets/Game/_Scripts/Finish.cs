using UnityEngine;

public class Finish : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            EventBus.Instance.OnGameWin?.Invoke();
        }
    }
}
