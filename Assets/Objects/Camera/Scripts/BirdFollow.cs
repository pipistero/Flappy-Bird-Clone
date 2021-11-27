using UnityEngine;

public class BirdFollow : MonoBehaviour
{
    [Space]
    [Header("Followed object")]
    [SerializeField] private Transform _bird;

    [Space]
    [Header("Parameters")]
    [SerializeField] private float _xOffset;
    [SerializeField] private float _yPosition;
    [SerializeField] private float _zPosition;

    private void Update()
    {
        transform.position = new Vector3(_bird.position.x + _xOffset, _yPosition, _zPosition);
    }
}
