using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class CharacterMovment : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Vector3 _groundCheckOffset;
    private Vector3 _input;
    private bool _isMoving;
    private bool _isJumping;
    private bool _isGrounded;

    private Rigidbody2D _rigidbody;
    private CharacterAnimation _animation;
    [SerializeField] private SpriteRenderer _characterSprite;

    

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animation = GetComponentInChildren<CharacterAnimation>();
    }

    private void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        _animation.IsMoving = _isMoving;
    }

    private bool IsJumping()
    {
        if (_rigidbody.velocity.y < 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void CheckGround()
    {
        float rayLength = 0.3f;
        Vector3 rayStartPosition = transform.position + _groundCheckOffset;
        RaycastHit2D hit = Physics2D.Raycast(rayStartPosition, rayStartPosition + Vector3.down, rayLength);
        if (hit.collider != null)
        {
            _isGrounded = hit.collider.CompareTag("Ground") ? true : false;
        }
        else
        {
            _isGrounded = false;
        }
    }
    private void Move()
    {
        _input = new Vector2(Input.GetAxis("Horizontal"), 0);
        transform.position += _input * _speed * Time.deltaTime;
        _isMoving = _input.x != 0 ? true : false;

        if (_isMoving)
        {
            _characterSprite.flipX = _input.x > 0 ? false : true;
        }
        //_animation.IsMoving = true;
    }

    private void Jump()
    {
        Debug.Log("Jump");
        _rigidbody.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
    }
}
