using UnityEngine;

public class Movement : MonoBehaviour
{
    [HideInInspector]
    public float bottomBound;

    [HideInInspector]
    public float topBound;

    [HideInInspector]
    public float speed = 1f;


    void Update()
    {
        transform.position = MovementUtil.Move(transform.position, transform.forward, speed, Time.deltaTime, bottomBound, topBound);
    }
}
