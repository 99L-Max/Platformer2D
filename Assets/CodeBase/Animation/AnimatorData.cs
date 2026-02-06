using UnityEngine;

public static class AnimatorData
{
    public static class PlayerParams
    {
        public const int ControlLayer = 0;
        public const int DamageLayer = 1;

        public static readonly int IsJumping = Animator.StringToHash(nameof(IsJumping));
        public static readonly int IsRunning = Animator.StringToHash(nameof(IsRunning));
    }

    public static class EnemyParams
    {
        public const int ControlLayer = 0;
        public const int DamageLayer = 1;

        public static readonly int IsPatrolling = Animator.StringToHash(nameof(IsPatrolling));
        public static readonly int IsFollowing = Animator.StringToHash(nameof(IsFollowing));
    }

    public static class ChestParams
    {
        public static readonly int IsOpened = Animator.StringToHash(nameof(IsOpened));
    }
}
