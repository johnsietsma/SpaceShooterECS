using UnityEngine;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

public class MovementSystem_ECSJobs : JobComponentSystem
{
    [BurstCompile]
    struct MovementJob : IJobProcessComponentData<Position, Rotation, MoveSpeed>
    {
        public float topBound;
        public float bottomBound;
        public float deltaTime;

        public void Execute(ref Position position, [ReadOnly] ref Rotation rotation, [ReadOnly] ref MoveSpeed speed)
        {
            position.Value = MovementUtil.Move(position.Value, math.forward(rotation.Value), speed.speed, deltaTime, bottomBound, topBound);
        }
    }

    struct ShipDataGroup
    {
        [ReadOnly] public SharedComponentDataArray<ShipData> shipData;
        [ReadOnly] public SharedComponentDataArray<ShipTag_ECSJobs> shipTag;
        public readonly int Length;
    }

    [Inject]
    ShipDataGroup shipDataGroup;

    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        if (shipDataGroup.Length == 0) return inputDeps;

        var shipData = shipDataGroup.shipData[0];

        MovementJob moveJob = new MovementJob
        {
            topBound = shipData.topBound,
            bottomBound = shipData.bottomBound,
            deltaTime = Time.deltaTime
        };

        JobHandle moveHandle = moveJob.Schedule(this, 64, inputDeps);

        return moveHandle;
    }
}