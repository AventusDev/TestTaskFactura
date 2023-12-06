using UnityEngine;
using UnityEngine.Pool;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _bulletMuzzle;
    private ObjectPool<Bullet> _bulletPool;
    public ObjectPool<Bullet> BulletPool { get => _bulletPool;}

    void Awake()
    {
        _bulletPool = new ObjectPool<Bullet>(CreateBullet, GetBullet, ReleaseBullet, DestroyBullet, true, 20, 32);
    }
    private Bullet CreateBullet()
    {
        Bullet bullet = Instantiate(_bulletPrefab, _bulletMuzzle.position, _bulletMuzzle.rotation);
        bullet.SetupPool(_bulletPool);

        return bullet;
    }
    private void GetBullet(Bullet bullet)
    {
        bullet.transform.position = _bulletMuzzle.position;
        bullet.transform.rotation = _bulletMuzzle.rotation;

        bullet.gameObject.SetActive(true);
    }
    private void ReleaseBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }
    private void DestroyBullet(Bullet bullet)
    {
        Destroy(bullet.gameObject);
    }
}
