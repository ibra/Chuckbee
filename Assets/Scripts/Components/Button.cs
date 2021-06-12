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
        if (OnPlayerEnter == null)
        {
            OnPlayerEnter = new UnityEvent();
        }

        if (OnBulletEnter == null)
        {
            OnBulletEnter = new UnityEvent();
        }
      
    }

    public void Interact(GameObject interacter)
    {
        OnBulletEnter.Invoke();
    }
}
}