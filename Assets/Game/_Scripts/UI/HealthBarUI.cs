using UnityEngine;
using UnityEngine.UI;
public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private EnemiesFactory _enemyFactory;
    private Image _healthBar;
    private float _fillPercent;
    private float _targetFillAmount;

    private void Awake()
    {
        _healthBar = GetComponent<Image>();
        _fillPercent = _enemyFactory.Damage * 100 / _player.Health;
    }
    private void Start()
    {
        EventBus.Instance.OnPlayerDamaged += FillHealthBar;
    }
    private void OnDisable()
    {
        EventBus.Instance.OnPlayerDamaged -= FillHealthBar;
    }
    private void FillHealthBar(float healthDamage)
    {
        _targetFillAmount = _healthBar.fillAmount - _fillPercent * 0.01f;
        _healthBar.fillAmount = _targetFillAmount;
    }
}
