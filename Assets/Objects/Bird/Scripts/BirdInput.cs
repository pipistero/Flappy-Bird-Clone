using UnityEngine;

[RequireComponent(typeof(BirdRotation))]
[RequireComponent(typeof(BirdMover))]
public class BirdInput : MonoBehaviour
{
    [Space]
    [Header("Parameters")]
    [SerializeField] private KeyCode _keyToJump;

    private BirdRotation _birdRotation;
    private BirdMover _birdMover;

    private void Start()
    {
        _birdRotation = GetComponent<BirdRotation>();
        _birdMover = GetComponent<BirdMover>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(_keyToJump))
        {
            _birdMover.Jump();
            _birdRotation.Jump();
        }
    }
}
