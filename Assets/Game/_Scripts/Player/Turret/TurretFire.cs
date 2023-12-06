using System.Collections;
using UnityEngine;
public class TurretFire : MonoBehaviour
{
    [SerializeField] private BulletSpawner _bulletSpawner;
    [SerializeField][Range(0.2f, 1f)] private float _delayBetweenFire;
    [SerializeField] private float _damagePerBullet;
    [SerializeField] private float _bulletsSpeed;
    private Coroutine _shootingCoroutine;
    private bool _canShoot = true;
    private void OnEnable()
    {
        EventBus.Instance.OnGameStarted += () => _shootingCoroutine = StartCoroutine(StartFire());
        EventBus.Instance.OnGameLoose += () => StopCoroutine(_shootingCoroutine);
        EventBus.Instance.OnGameWin += () => StopCoroutine(_shootingCoroutine);
    }
    private void OnDisable()
    {
        EventBus.Instance.OnGameStarted -= () => _shootingCoroutine = StartCoroutine(StartFire());
        EventBus.Instance.OnGameLoose += () => StopCoroutine(_shootingCoroutine);
        EventBus.Instance.OnGameWin += () => StopCoroutine(_shootingCoroutine);
    }
    private IEnumerator StartFire()
    {
        while (_canShoot)
        {
            InitBullet();
            yield return new WaitForSeconds(_delayBetweenFire);
        }
    }
    private void InitBullet()
    {
        Bullet bullet = _bulletSpawner.BulletPool.Get();
        SetupBulletProperties(bullet);

        bullet.Shoot();
    }
    private void SetupBulletProperties(Bullet bullet)
    {
        bullet.Damage = _damagePerBullet;
        bullet.BulletSpeed = _bulletsSpeed;
    }
}
