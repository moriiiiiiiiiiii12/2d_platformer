using System;
using UnityEngine;

public class SpriteFlipper : MonoBehaviour
{
    private const float LeftAngle = 180f;
    private const float RightAngle = 0f;

    private bool _isFacingLeft;

    public event Action<bool> FacingChanged;

    public void Flip(bool isLeft)
    {
        if (isLeft == _isFacingLeft)
            return;

        _isFacingLeft = isLeft;

        float yRotation = _isFacingLeft ? LeftAngle : RightAngle;
        transform.rotation = Quaternion.Euler(0f, yRotation, 0f);

        FacingChanged?.Invoke(_isFacingLeft);
    }
}
