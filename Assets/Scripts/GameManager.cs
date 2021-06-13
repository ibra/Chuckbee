using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    
    public static GameManager Instance => _instance;

    public float Nectar { get; set; }
    public float RequiredPollen { get; set; }

    [SerializeField] private Image nectarBar;

    private float PollenNormalized()
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
        if (SceneManager.GetActiveScene().buildIndex == 0) Destroy(gameObject);

        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        nectarBar.transform.parent.gameObject.SetActive(PollenNormalized() != 0f);
        nectarBar.fillAmount = PollenNormalized();
    }
}
