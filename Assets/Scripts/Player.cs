using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] float moveSpeed = 7.0f;
    [SerializeField] PlayerInput playerInput;

    public bool IsWalking { get; private set; }

    private void Update() {
        Vector2 inputVector = playerInput.GetInputVector2Normalized();
        Vector3 moveDirection = new Vector3(inputVector.x, 0.0f, inputVector.y);
        IsWalking = !moveDirection.Equals(Vector3.zero);
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
        const float rotateSpeed = 10.0f;
        transform.forward = Vector3.Slerp(transform.forward, moveDirection, Time.deltaTime * rotateSpeed);
    }
}
