using UnityEngine;

public interface IEnemiesFactory
{
    int EnemiesCount { get; set; }
    EnemyController Enemy { get; set; }
    Vector3[] RandomPositions { get; set; }
    ParticleSystem HitParticle {get; set;}
    Collider SpawnBounds {get; set;}
    float Damage {get; set;}
    void CreateEnemies(int enemiesCount);
}
