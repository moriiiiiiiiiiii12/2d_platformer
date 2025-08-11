using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class VampirismView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _radiusSprite; 
    [SerializeField] private Slider _durationSlider; 
    [SerializeField] private Vampirism _vampirism; 

    private void OnEnable()
    {
        _vampirism.OnActivated += Enable;
        _vampirism.OnDeactivated += Disable;
    }

    private void OnDisable()
    {
        _vampirism.OnActivated -= Enable;
        _vampirism.OnDeactivated -= Disable;
    }

    private void Enable()
    {
        _radiusSprite.enabled = true;

        float currentValue = _durationSlider.value;
        float targetValue = 0f;

        StartCoroutine(DecreaseSlider(_vampirism.Duration, currentValue, targetValue));
    }

    private void Disable()
    {
        _radiusSprite.enabled = false;

        float currentValue = _durationSlider.value;
        float targetValue = 1f;

        StartCoroutine(IncreaseSlider(_vampirism.Cooldown, currentValue, targetValue));
    }


    private IEnumerator IncreaseSlider(float time, float currentValue, float targetValue)
    {
        while (currentValue < targetValue)
        {
            currentValue = Mathf.MoveTowards(currentValue, targetValue, Time.deltaTime / time);
            _durationSlider.value = currentValue;

            yield return null;
        }
    }

    private IEnumerator DecreaseSlider(float time, float currentValue, float targetValue)
    {
        while (currentValue > targetValue)
        {
            currentValue = Mathf.MoveTowards(currentValue, targetValue, Time.deltaTime / time);
            _durationSlider.value = currentValue;

            yield return null;
        }
    }
}
