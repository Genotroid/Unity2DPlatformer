using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _scoreText;

    private int _currentScore = 0;

    private void OnEnable()
    {
        _player.DiamondTaked += ChangeScore;
    }

    private void OnDisable()
    {
        _player.DiamondTaked -= ChangeScore;
    }

    private void ChangeScore()
    {
        _scoreText.text = (++_currentScore).ToString();
    }
}
