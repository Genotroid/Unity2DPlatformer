using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _jumpForce;

    private bool _isGround;
    private float _currenSpeed;
    private Rigidbody2D _rigidbody;
    private Animator _animator;

    
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _currenSpeed = Mathf.Abs(Input.GetAxis("Horizontal"));
        _animator.SetFloat("MoveSpeed", _currenSpeed);

        transform.Translate(_walkSpeed * Time.deltaTime * Input.GetAxis("Horizontal"), 0, 0);

        if (Input.GetAxis("Horizontal") > 0)
            Flip(1);
        if (Input.GetAxis("Horizontal") < 0)
            Flip(-1);

        if (Input.GetKeyDown(KeyCode.Space) && _isGround)
        {
            Jump();
        }
    }

    private void Flip(int direction)
    {
        Vector3 playerScale = transform.localScale;
        playerScale.x = direction * Mathf.Abs(transform.localScale.x);
        transform.localScale = playerScale;
    }

    private void Jump()
    {
        _isGround = false;
        _rigidbody.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
            _isGround = true;
    }
}
