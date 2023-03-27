using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AgentAnimator : MonoBehaviour
{
    protected Animator _animator;
    protected readonly int _walkBoolHash = Animator.StringToHash("Walk");

    public UnityEvent OnFootStep;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void AnimatorPlayer(float velocity)
    {
        SetWalkAnimation(velocity > 0);
    }

    public void SetWalkAnimation(bool value)
    {
        _animator.SetBool(_walkBoolHash, value); 
    }

    public void FootStepEvent()
    {
        OnFootStep?.Invoke();
    }
}
