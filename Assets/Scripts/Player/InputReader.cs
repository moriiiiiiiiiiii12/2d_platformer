using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Jump = nameof(Jump);
    private const string Horizontal = nameof(Horizontal);

    public event Action PressJumpInput;
    public float HorizontalAxis { get; private set; }

    private float tempHorizontal;

    private void Update()
    {
        bool jumpInput = Input.GetButtonDown(Jump);
        float horizontalInput = Input.GetAxis(Horizontal);

        if (jumpInput)
            PressJumpInput?.Invoke();

        if (horizontalInput != tempHorizontal)
        {
            HorizontalAxis = horizontalInput;
            tempHorizontal = horizontalInput;
        }
    }
}