using TMPro;
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
    [SerializeField] private TextMeshProUGUI successText;

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
        }
    }

    private void Update()
    {
        
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (PollenNormalized() == 1f)
        {
            nectarBar.transform.parent.gameObject.SetActive(true);
            successText.gameObject.SetActive(true);
        }
        else if (PollenNormalized() == 0f)
        {
            nectarBar.transform.parent.gameObject.SetActive(false);
        }
        else
        {
            nectarBar.transform.parent.gameObject.SetActive(true);
        }

        nectarBar.fillAmount = PollenNormalized();
    }
}
