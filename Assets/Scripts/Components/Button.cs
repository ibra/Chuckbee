using UnityEngine;
using UnityEngine.Events;

namespace BeeGame.Components
{
public class Button : MonoBehaviour
{
    [SerializeField] private UnityEvent OnBulletEnter;
    [SerializeField] private UnityEvent OnPlayerEnter;
    private UnityEvent OnPlayerExit;
    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "Bullet":
                other.transform.GetComponent<Rigidbody2D>().isKinematic = true;
                OnBulletEnter.Invoke();
                break;
            case "Player":
                OnPlayerEnter.Invoke();
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            OnPlayerExit.Invoke();
        }
    }
}
}