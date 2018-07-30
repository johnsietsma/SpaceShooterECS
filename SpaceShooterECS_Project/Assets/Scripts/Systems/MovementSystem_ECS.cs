using Unity.Entities;
using Unity.Collections;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class MovementSystem_ECS : ComponentSystem
{
    struct ShipGroup
    {
        public ComponentDataArray<Position> positions;
        [ReadOnly] public ComponentDataArray<Rotation> rotations;
        [ReadOnly] public ComponentDataArray<MoveSpeed> moveSpeeds;
        [ReadOnly] public SharedComponentDataArray<ShipData> shipData;
        [ReadOnly] public SharedComponentDataArray<ShipTag_ECS> shipTag;
        public readonly int Length;
    }
    [Inject]
    ShipGroup enemies;

    protected override void OnUpdate()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            Position position = enemies.positions[i];
            Rotation rotation = enemies.rotations[i];
            MoveSpeed speed = enemies.moveSpeeds[i];
            ShipData shipData = enemies.shipData[i];

            position.Value = MovementUtil.Move(position.Value, math.forward(rotation.Value), speed.speed, Time.deltaTime, shipData.bottomBound, shipData.topBound);

            enemies.positions[i] = position;
        }
    }
}
