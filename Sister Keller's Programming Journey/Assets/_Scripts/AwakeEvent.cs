using UnityEngine;
using UnityEngine.Events;

public class AwakeEvent : MonoBehaviour
{
    [SerializeField] UnityEvent onAwake;

    void Start()
    {
        onAwake?.Invoke();
    }
}
