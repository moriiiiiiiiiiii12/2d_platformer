using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Jump = nameof(Jump);
    private const string Horizontal = nameof(Horizontal);

    public float HorizontalAxis { get; private set; }

    public event Action PressJumpInput;

    private void Update()
    {
        bool jumpInput = Input.GetButtonDown(Jump);
        HorizontalAxis = Input.GetAxis(Horizontal);

        if (jumpInput)
            PressJumpInput?.Invoke();
    }
}