using UnityEngine;
using UnityEngine.Pool;
public class Bullet : MonoBehaviour
{
    private float _damage;
    private ObjectPool<Bullet> _pool;
    private Rigidbody _rb;
    private float _bulletSpeed;
    public float Damage { set => _damage = value; }
    public float BulletSpeed { set => _bulletSpeed = value; }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("PlayerAgroZone"))
        {
            if (other.TryGetComponent<IDamageable>(out IDamageable damageable))
            {
                damageable?.TakeDamage(_damage);
            }
            _pool.Release(this);
        }
    }
    public void SetupPool(ObjectPool<Bullet> pool)
    {
        _pool = pool;
    }
    public void Shoot()
    {
        _rb.velocity = transform.up * _bulletSpeed;
    }
}
