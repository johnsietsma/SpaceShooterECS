using Unity.Burst;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Jobs;

[BurstCompile]
public struct MovementJob : IJobParallelForTransform
{
    public float speed;
    public float topBound;
    public float bottomBound;
    public float deltaTime;

    public void Execute(int index, TransformAccess transform)
    {
        transform.position = MovementUtil.Move( transform.position, Vector3.forward, speed, deltaTime, bottomBound, topBound );
    }
}
