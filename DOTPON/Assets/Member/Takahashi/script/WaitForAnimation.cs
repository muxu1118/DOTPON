using UnityEngine;

class WaitForAnimation : CustomYieldInstruction
{
    Animator _animator;
    int _layerNo = 0;
    int _lastStateHash = 0;
    
    public WaitForAnimation(Animator animator, int layerNo)
    {
        Init(animator, layerNo, animator.GetCurrentAnimatorStateInfo(layerNo).nameHash);
    }

    void Init(Animator animator, int layerNo, int hash)
    {
        _animator = animator;
        _layerNo = layerNo;
        _lastStateHash = hash;
    }

    public override bool keepWaiting
    {
        get
        {
            var currentAnimatorState = _animator.GetCurrentAnimatorStateInfo(_layerNo);
            return currentAnimatorState.fullPathHash == _lastStateHash &&
                (currentAnimatorState.normalizedTime < 1);
        }
    }
}