using System;
using BeeGame.Interfaces;
using UnityEngine;

public class Flower : MonoBehaviour, IInteractable
{
    [SerializeField] private float additionAmount;
    private Animator _animator;
    private bool pollinated;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Interact(GameObject interacter)
    {
        if(pollinated) return;
        GameManager.Instance.Nectar += additionAmount;
        _animator.SetTrigger("Pollinated");
        pollinated = true;
        Destroy(interacter);
    }
}
