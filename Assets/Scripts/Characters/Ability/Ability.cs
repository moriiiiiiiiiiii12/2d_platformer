using System.Collections;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    [SerializeField] protected float _duration;
    [SerializeField] protected float _delay;
    [SerializeField] protected float _cooldown;

    protected Coroutine _coroutine;

    public abstract void Execute();

    protected IEnumerator WaitCooldown()
    {
        yield return new WaitForSeconds(_cooldown);
        _coroutine = null;
    }
}