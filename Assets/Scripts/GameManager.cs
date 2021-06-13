using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    
    public static GameManager Instance => _instance;

    public float Nectar { get; set; }
    public float RequiredPollen { get; set; }

    [SerializeField] private Image nectarBar;

    public float PollenNormalized()
    {
       return Nectar / RequiredPollen;
    }
    
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        } else {
            _instance = this;
            DontDestroyOnLoad(_instance);
        }
    }

    private void Update()
    {
        nectarBar.fillAmount = PollenNormalized();
    }
}
