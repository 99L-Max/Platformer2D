using UnityEngine;

public static class AnimatorData
{
    public static class EntityParams
    {
        public static readonly int IsJumping = Animator.StringToHash(nameof(IsJumping));
        public static readonly int IsRunning = Animator.StringToHash(nameof(IsRunning));
    }

    public static class ChestParams
    {
        public static readonly int IsOpened = Animator.StringToHash(nameof(IsOpened));
    }
}
