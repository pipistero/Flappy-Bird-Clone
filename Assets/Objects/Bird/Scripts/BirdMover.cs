using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BirdMover : MonoBehaviour
{
    [Space]
    [Header("Parameters")]
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        Reset();
    }

    public void Jump()
    {
        _rigidbody.velocity = new Vector2(_speed, 0);
        _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Force);
    }

    public void Reset()
    {
        transform.position = _startPosition;
        _rigidbody.velocity = Vector2.zero;
    }
}
