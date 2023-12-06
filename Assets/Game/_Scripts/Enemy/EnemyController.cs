using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour, IDamageable
{
    private Animator _animator;
    private NavMeshAgent _navigationAgent;
    private Transform _target = null;
    [SerializeField] private float _health;
    [SerializeField] private float _damage;
    [SerializeField] private ParticleSystem _hitParticle;
    private bool _haveTarget = false;
    public float Health { set => _health = value; }
    public ParticleSystem HitParticle { set => _hitParticle = value; }
    public float Damage { get => _damage; set => _damage = value; }

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _navigationAgent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        if (_haveTarget) FollowPlayer(_target);
    }
    private void FollowPlayer(Transform target)
    {
        _navigationAgent.SetDestination(target.position);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("PlayerAgroZone"))
        {
            _animator.SetBool("isRunning", true);
            _haveTarget = true;
            _target = other.transform;
        }
        if (other.gameObject.TryGetComponent<IDamageable>(out IDamageable damageable))
        {
            damageable.TakeDamage(_damage);
            ActivateParticle(transform.position);

            this.gameObject.SetActive(false);
        }
    }
    public void TakeDamage(float damage)
    {
        _health -= damage;
        DecreaseScale();
        ActivateParticle(transform.position + new Vector3(0, 2, 0));

        if (_health <= 0)
        {
            gameObject.SetActive(false);
        }
    }
    private void DecreaseScale()
    {
        transform.localScale -= transform.localScale * 0.1f;
    }
    public void ActivateParticle(Vector3 CollidePosition)
    {
        _hitParticle.transform.position = CollidePosition;
        _hitParticle.Play();
    }
}