using BeeGame.Interfaces;
using UnityEngine;

public class Flower : MonoBehaviour, IInteractable
{
    [SerializeField] private float additionAmount;
    public void Interact()
    {
        GameManager.Instance.Pollen += additionAmount;
    }
}
