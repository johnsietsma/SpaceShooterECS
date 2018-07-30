using Unity.Collections;
using Unity.Entities;
using Unity.Burst;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class MovementSystem_Hybrid : ComponentSystem
{
    struct Ship
    {
        public Transform transform;
        public MovementHybrid movement;
    }

    protected override void OnUpdate()
    {
        float dt = Time.deltaTime;

        foreach( var e in GetEntities<Ship>() )
        {
            var movement = e.movement;
            var transform = e.transform;

            transform.position = MovementUtil.Move(transform.position, transform.forward, movement.speed, Time.deltaTime, movement.bottomBound, movement.topBound);
        }
    }
}
