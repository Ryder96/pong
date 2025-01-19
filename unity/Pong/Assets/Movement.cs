// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private InputAction _moveAction;

    [SerializeField] private int _velocity = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start() => _moveAction = InputSystem.actions.FindAction("Move");

    // Update is called once per frame
    private void Update() => ReadInput();

    private void ReadInput()
    {
        Vector2 moveValue = _moveAction.ReadValue<Vector2>();
        float direction = moveValue.y;

        if (direction == 0)
        {
            return;
        }

        float delta = direction * _velocity * Time.deltaTime;

        transform.position = new Vector3(transform.position.x, transform.position.y + delta);
    }
}
