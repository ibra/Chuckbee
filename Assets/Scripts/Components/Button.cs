using BeeGame.Interfaces;
using UnityEngine;
using UnityEngine.Events;

namespace BeeGame.Components
{
public class Button : MonoBehaviour, IInteractable
{
    [SerializeField] private UnityEvent OnBulletEnter;
    [SerializeField] private UnityEvent OnPlayerEnter;

    private void Awake()
    {
        OnPlayerEnter = new UnityEvent();
        OnBulletEnter = new UnityEvent();
    }

    public void Interact()
    {
      OnBulletEnter.Invoke();
    }
}
}