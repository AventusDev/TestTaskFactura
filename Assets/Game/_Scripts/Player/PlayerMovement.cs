using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private float _speed;
    [SerializeField] private bool _canMove = false;
    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    void OnEnable()
    {
        EventBus.Instance.OnGameStarted += () => _canMove = true;
        EventBus.Instance.OnGameLoose += () => _canMove = false;
        EventBus.Instance.OnGameWin += () => _canMove = false;
    }
    void OnDisable()
    {
        EventBus.Instance.OnGameStarted -= () => _canMove = true;
        EventBus.Instance.OnGameLoose -= () => _canMove = false;
        EventBus.Instance.OnGameWin -= () => _canMove = false;
    }
    void FixedUpdate()
    {
        if (_canMove) _rb.MovePosition(transform.position + new Vector3(0, 0, 1f) * Time.deltaTime * _speed);
    }
}
