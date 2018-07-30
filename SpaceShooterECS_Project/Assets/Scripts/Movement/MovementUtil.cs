using UnityEngine;
using Unity.Mathematics;

public static class MovementUtil
{
    public static Vector3 Move( Vector3 pos, Vector3 forward, float speed, float deltaTime, float bottomBound, float topBound )
    {
        pos += forward * speed * deltaTime;

        if (pos.z < bottomBound)
            pos.z = topBound;

        return pos;
    }

    public static float3 Move(float3 pos, float3 forward, float speed, float deltaTime, float bottomBound, float topBound)
    {
        pos += forward * speed * deltaTime;

        if (pos.z < bottomBound)
            pos.z = topBound;

        return pos;
    }
}

