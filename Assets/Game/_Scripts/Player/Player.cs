using UnityEngine;
public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private float _health = 100;
    public float Health { get => _health;}

    public void TakeDamage(float damage)
    {
        _health -= damage;
        EventBus.Instance.OnPlayerDamaged?.Invoke(damage);

        if (_health <= 0)
        {
            EventBus.Instance.OnGameLoose?.Invoke();
        }
    }
}
