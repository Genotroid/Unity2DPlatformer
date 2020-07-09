using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _diamondCount = 0;
    [SerializeField] private TMP_Text _score;

    public int DiamondsCount => _diamondCount;

    private void Start()
    {
        _score.text = _diamondCount.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("DeadZone"))
            Die();
    }

    public void TakeDiamond()
    {
        _diamondCount++;
        _score.text = _diamondCount.ToString();
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
