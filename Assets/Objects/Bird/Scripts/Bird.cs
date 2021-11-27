using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BirdMover))]
public class Bird : MonoBehaviour
{
    public event UnityAction GameOver;
    public event UnityAction<int> ScoreChanged;

    private BirdMover _birdMover;

    private int _score;

    private void Start()
    {
        _birdMover = GetComponent<BirdMover>();
    }

    public void AddScore()
    {
        _score += 1;

        ScoreChanged?.Invoke(_score);
    }

    public void Die()
    {
        GameOver?.Invoke();
    }

    public void Reset()
    {
        _score = 0;

        _birdMover.Reset();

        ScoreChanged?.Invoke(_score);
    }
}
