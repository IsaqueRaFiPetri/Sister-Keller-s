using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TimeBeforeEvent : MonoBehaviour
{
    [Header("Tempo de espera (em segundos)")]
    public float delay = 1f;

    [Header("Evento a ser chamado após o atraso")]
    public UnityEvent onDelayComplete;

    // Chame este método no botão (via OnClick no Inspector)
    public bool IsEventNecessary;
    public void OnEnable()
    {
        if (!IsEventNecessary)
        {
            StartCoroutine(DelayedEventCoroutine());
        }
    }
    public void TriggerDelayedEvent()
    {
        if (IsEventNecessary)
        {
            StartCoroutine(DelayedEventCoroutine());
        }
    }

    private IEnumerator DelayedEventCoroutine()
    {
        yield return new WaitForSeconds(delay);
        onDelayComplete?.Invoke();
    }
}
