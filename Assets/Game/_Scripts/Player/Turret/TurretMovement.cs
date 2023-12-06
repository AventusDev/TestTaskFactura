using UnityEngine;

public class TurretMovement : MonoBehaviour
{
    private Vector3 _touchPosition;
    private Vector3 _lastTouchPosition;
    [SerializeField] private Transform _turret;
    [SerializeField][Range(1f, 10f)] private float _speed;
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _touchPosition = Input.mousePosition;
            if (_lastTouchPosition != Vector3.zero)
            {
                Vector3 mouseDelta = _touchPosition - _lastTouchPosition;
                _turret.Rotate(new Vector3(0, 0, mouseDelta.x * _speed * Time.deltaTime), Space.Self);
            }
            _lastTouchPosition = _touchPosition;
        }
        else
        {
            _lastTouchPosition = Vector3.zero;
        }
    }
}
