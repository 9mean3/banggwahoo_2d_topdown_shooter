using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AgentMovement : MonoBehaviour
{
    private Rigidbody2D _rigid;

    [SerializeField]
    private MovementDataSO _movementdata;


    protected float _currentVelocity = 0;
    protected Vector2 _movementDirection;

    public UnityEvent<float> OnVelocityChange;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    public void MoveAgent(Vector2 movementInput)
    {
        if(movementInput.sqrMagnitude > 0)
        {
            if(Vector2.Dot(movementInput, _movementDirection) < 0)
            {
                _currentVelocity = 0;
            }
            _movementDirection = movementInput.normalized;
        }
        _currentVelocity = CalcSpeed(movementInput);
    }

    float CalcSpeed(Vector2 movementInput)
    {
        if (movementInput.sqrMagnitude > 0)
        {
            _currentVelocity += _movementdata._acceleration * Time.deltaTime;
        }
        else
        {
            _currentVelocity -= _movementdata._deAcceleration * Time.deltaTime;
        }
        return Mathf.Clamp(_currentVelocity, 0, 5);
    }

    private void FixedUpdate()
    {
        OnVelocityChange?.Invoke(_currentVelocity);
        _rigid.velocity = _movementDirection * _currentVelocity;
    }
}
