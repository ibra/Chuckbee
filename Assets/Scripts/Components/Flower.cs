using BeeGame.Interfaces;
using UnityEngine;

public class Flower : MonoBehaviour, IInteractable
{
    [SerializeField] private float additionAmount;
    public void Interact(GameObject interacter)
    {
        GameManager.Instance.Pollen += additionAmount;
        Destroy(interacter);
    }
}
