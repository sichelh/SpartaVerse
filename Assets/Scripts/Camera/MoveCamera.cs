using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float moveSpeed = 0.5f;
    [SerializeField] private Vector2 moveMin;
    [SerializeField] private Vector2 moveMax;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        Vector3 movePosition = target.position + offset;
        movePosition.z = transform.position.z;

        movePosition.x = Mathf.Clamp(movePosition.x, moveMin.x, moveMax.x);
        movePosition.y = Mathf.Clamp(movePosition.y, moveMin.y, moveMax.y);

        transform.position = Vector3.Lerp(transform.position, movePosition, Time.deltaTime * moveSpeed); 
    }
}
