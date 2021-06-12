using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    
    public static GameManager Instance => _instance;

    public float Pollen { get; set; }

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
    
    private void Start()
    {
        
    }        
    
    private void Update()
    {
        
    }
}
