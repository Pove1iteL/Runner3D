using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class Score : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private TMP_Text _highScoreText;
    [SerializeField] private TMP_Text _currentScore;

    private TMP_Text _score;
    private int _highScore;

    private void Start()
    {
        _score = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        _score.text = $"Score: {((int)_player.position.z).ToString()}";
        _highScoreText.text = $"High Score: {PlayerPrefs.GetInt("HighScireText")}";

        _currentScore.text = _score.text;

        _highScore = (int)_player.position.z;

        if (PlayerPrefs.GetInt("HighScireText") <= _highScore)
        {
            PlayerPrefs.SetInt("HighScireText",_highScore);
        }
    }
}
