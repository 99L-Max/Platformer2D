using UnityEngine;

public class Rotator
{
    public void SetDirectionX(Transform root, Vector3 target)
    {
        var direction = target - root.position;
        var rotation = root.rotation;

        rotation.y = direction.x > 0f ? 0f : 180f;
        root.rotation = rotation;
    }

    public void SetDirectionX(Transform root, float directionX)
    {
        var rotation = root.rotation;

        if (directionX > 0f)
            rotation.y = 0f;
        else if (directionX < 0f)
            rotation.y = 180f;

        root.rotation = rotation;
    }
}
