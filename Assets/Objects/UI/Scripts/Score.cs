using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private TMP_Text _text;

    private void OnEnable() { _bird.ScoreChanged += OnScoreChanged; }

    private void OnDisable() { _bird.ScoreChanged -= OnScoreChanged; }

    private void OnScoreChanged(int score)
    {
        _text.text = score.ToString();
    }
}
