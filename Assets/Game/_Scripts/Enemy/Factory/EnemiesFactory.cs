using UnityEngine;

public class EnemiesFactory : MonoBehaviour, IEnemiesFactory
{
    [SerializeField] private int _enemiesCount;
    [SerializeField] private Transform _parentObject;
    [SerializeField] private ParticleSystem _hitParticle;
    [SerializeField] private Collider _spawnBounds;
    [SerializeField] private EnemyController _enemy;
    [SerializeField] private float _damage;
    private Vector3[] _randomPositions;

    public int EnemiesCount { get => _enemiesCount; set => _enemiesCount = value; }
    public EnemyController Enemy { get => _enemy; set => _enemy = value; }
    public Vector3[] RandomPositions { get => _randomPositions; set => _randomPositions = value; }
    public ParticleSystem HitParticle { get => _hitParticle; set => _hitParticle = value; }
    public Collider SpawnBounds { get => _spawnBounds; set => _spawnBounds = value; }
    public float Damage { get => _damage; set => _damage = value; }

    void Start()
    {
        CreateEnemies(_enemiesCount);
    }
    public void CreateEnemies(int enemiesCount)
    {

        for (int i = 0; i < enemiesCount; i++)
        {
            Vector3 randomPosition = GeneratesRandomPosition(_spawnBounds.bounds);
            var enemy = Instantiate(_enemy, randomPosition, Quaternion.identity, _parentObject);
            
            enemy.HitParticle = _hitParticle;
            enemy.Damage = _damage;
        }
    }

    private Vector3 GeneratesRandomPosition(Bounds bounds)
    {
        return new Vector3
        (
            Random.Range(bounds.min.x, bounds.max.x),
            0,
            Random.Range(bounds.min.z, bounds.max.z)
        );
    }
}
