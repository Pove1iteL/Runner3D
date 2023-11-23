using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private const string Jump = "IsJump";
    private const string JumpWithTorch = "JumpWith";

    [SerializeField] private Animator _trchAnimation;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _gravity;
    [SerializeField] private float _highJump = 1f;

    private CharacterController _characterController;
    private Animator _animator;
    private Vector3 _direction;
    private float _defaultPositionY;

    private void Start()
    {
        _defaultPositionY = transform.position.y;

        _animator = GetComponent<Animator>();
        _characterController = GetComponent<CharacterController>();

        StartCoroutine(SpeedUp());
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _characterController.isGrounded)
        {
            JumpUp();
        }
        else if (_direction.y <= _defaultPositionY)
        {
            _animator.SetBool(Jump, false);
        }
    }

    private void JumpUp()
    {
        _animator.SetBool(Jump, true);

        _trchAnimation.Play(JumpWithTorch);

        _direction.y = _highJump;
    }

    private void FixedUpdate()
    {
        _direction.z = _speed;
        _direction.y += _gravity * Time.fixedDeltaTime;
        _characterController.Move(_direction * Time.fixedDeltaTime);
    }

    private IEnumerator SpeedUp()
    {
        float secondsWait = 3f;
        var waitForSecond = new WaitForSeconds(secondsWait);
        bool isWork = true;

        while (isWork)
        {
            _speed += 0.2f;

            yield return waitForSecond;
        }
    }
}
