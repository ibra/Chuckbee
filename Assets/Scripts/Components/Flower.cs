using BeeGame.Interfaces;
using UnityEngine;

public class Flower : MonoBehaviour, IInteractable
{
    [SerializeField] private float additionAmount;
    private bool pollinated;
    public void Interact(GameObject interacter)
    {
        GameManager.Instance.Nectar += additionAmount;
        Destroy(interacter);
    }
}
