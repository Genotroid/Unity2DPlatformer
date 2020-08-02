using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _walkSpeed;

    private Animator _animator;
    private SpriteRenderer _sprite;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        transform.Translate(_walkSpeed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _animator.Play("Attack");
            player.Die();
        }
    }

    public void Flip()
    {
        _sprite.flipX = _sprite.flipX ? false : true;
        _walkSpeed *= -1;
    }
}
