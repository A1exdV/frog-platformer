using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class FrogController : MonoBehaviour
{
    [SerializeField] private Animator frogAnim;


    [SerializeField] private float speed;
    [SerializeField] private float minJumpForce;
    [SerializeField] private float maxJumpForce;
    [SerializeField] private float timeToForceJump;

    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private Transform groundCheck1;
    [SerializeField] private Transform groundCheck2;

    [SerializeField] private GameObject jumpScale;
    [SerializeField] private Image jumpScaleFill;

    [SerializeField] private AudioClip jump;
    [SerializeField] private AudioSource _audioSource;

    private Rigidbody2D _frogRb2D;
    private Transform _transform;

    private Camera _camera;

    private bool _isFacingRight;

    private string _currentState;

    private float _jumpInputTimer;

    void Start()
    {
        _currentState = "Idle";
        _isFacingRight = true;
        _jumpInputTimer = 0;
        _camera = Camera.main;
        _frogRb2D = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        if (_currentState is "Attack" or "Damage")
        {
            _jumpInputTimer = 0;
            jumpScale.SetActive(false);
            return;
        }
        GetInput();
        InAirCheck();
    }

    private void GetInput()
    {
        JumpCheck();
        HorizontalCheck();
        AttackCheck();
    }

    private void ChangeState(string newState)
    {
        if (newState == _currentState)
            return;

        if ((_currentState is "Jump" or "Fall") && !IsGrounded()  && newState != "Damage")
            return;
        if (_currentState is "Attack" or "Damage")
            return;

        _currentState = newState;
        switch (_currentState)
        {
            case "Idle":
                frogAnim.Play("Idle");
                break;
            case "Run":
                frogAnim.Play("Run");
                break;
            case "Jump":
                frogAnim.Play("Jump");
                break;
            case "Fall":
                //frogAnim.Play("Fall");
                break;
            case "Attack":
                frogAnim.Play("Attack");
                break;
            case "Damage":
                frogAnim.Play("Damage");
                break;
        }
    }

    private void InAirCheck()
    {
        if (_frogRb2D.velocity.y > 0 && !IsGrounded())
        {
            ChangeState("Jump");
        }

        if (_frogRb2D.velocity.y < 0 && !IsGrounded())
        {
            ChangeState("Fall");
        }
    }

    private void HorizontalCheck()
    {
        switch (Input.GetAxisRaw("Horizontal"))
        {
            case 1:
                if (!_isFacingRight)
                    Flip();
                ChangeState("Run");
                _frogRb2D.velocity = new Vector2(speed, _frogRb2D.velocity.y);

                break;
            case -1:
                if (_isFacingRight)
                    Flip();
                ChangeState("Run");
                _frogRb2D.velocity = new Vector2(-speed, _frogRb2D.velocity.y);
                break;
            case 0:
                ChangeState("Idle");
                _frogRb2D.velocity = new Vector2(0, _frogRb2D.velocity.y);
                break;
        }
    }

    private void JumpCheck()
    {




        if (!jumpScale.activeInHierarchy && _jumpInputTimer > timeToForceJump && _currentState !="Attack")
        {
            jumpScale.transform.position = _camera.WorldToScreenPoint(transform.position) - new Vector3(0, 20, 0);
            jumpScale.SetActive(true);
        }


        if (Input.GetKey("space") && IsGrounded())
        {
            _jumpInputTimer += Time.deltaTime;
        }

        if (Input.GetKey("space") && !IsGrounded())
        {
            _jumpInputTimer = 0;
            jumpScale.SetActive(false);
        }

        if (Input.GetKeyUp("space") && IsGrounded())
        {
            if (jumpScale.activeInHierarchy)
            {
                _frogRb2D.velocity = new Vector2(_frogRb2D.velocity.x,
                    minJumpForce + (maxJumpForce - minJumpForce) * jumpScaleFill.fillAmount);
            }
            else
            {
                _frogRb2D.velocity = new Vector2(_frogRb2D.velocity.x, minJumpForce);
            }

            _audioSource.clip = jump;
            _audioSource.Play();
            jumpScale.SetActive(false);
            _jumpInputTimer = 0;
        }

        if (Input.GetKeyUp("space") && !IsGrounded())
        {
            _jumpInputTimer = 0;
            jumpScale.SetActive(false);
        }
    }

    private void AttackCheck()
    {
        if (Input.GetKeyDown(KeyCode.E) && IsGrounded())
        {
            ChangeState("Attack");
            _frogRb2D.velocity = Vector2.zero;
        }
    }

    public void OnAttackEnd()
    {
        _currentState = "Idle";
        frogAnim.Play("Idle");
    }

    public void GetDamage(Vector2 contact)
    {
        ChangeState("Damage");
        _frogRb2D.velocity = ((Vector2)transform.position -contact +new Vector2(0,2) )*speed;
        StartCoroutine(DamageStun());
    }

    private IEnumerator DamageStun()
    {
        yield return new WaitForSeconds(0.5f);
        _currentState = "Run";
    }

    private bool IsGrounded()
    {
        if (Physics2D.OverlapCircle(groundCheck1.position, 0.10f, groundLayer) ||
            Physics2D.OverlapCircle(groundCheck2.position, 0.10f, groundLayer))
            return true;
        return false;
    }

    private void OnDrawGizmos()
    {
        if(IsGrounded())
            Gizmos.color = Color.green;
        else
        {
            Gizmos.color = Color.red;
        }

        Gizmos.DrawSphere(groundCheck1.position, 0.10f);
        Gizmos.DrawSphere(groundCheck2.position, 0.10f);
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        var localScale = _transform.localScale;
        localScale.x *= -1f;
        _transform.localScale = localScale;
    }
}