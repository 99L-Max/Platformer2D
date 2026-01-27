using UnityEngine;

public class EntityAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _root;

    public void UpdateAnimationRunning(bool isRunning)
    {
        _animator.SetBool(AnimatorData.EntityParams.IsRunning, isRunning);
    }

    public void UpdateAnimationJumping(bool isJumping)
    {
        _animator.SetBool(AnimatorData.EntityParams.IsJumping, isJumping);
    }

    public void SetDirectionX(float x)
    {
        Quaternion rotation = _root.rotation;

        if (x > 0f)
            rotation.y = 0f;
        else if (x < 0f)
            rotation.y = 180f;

        _root.rotation = rotation;
    }
}
