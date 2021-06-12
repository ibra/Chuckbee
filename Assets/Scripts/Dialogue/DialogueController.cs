using TMPro;
using UnityEngine;


public class DialogueController : MonoBehaviour
{
    [TextArea(0,2)]
    [SerializeField] private string[] sentences;

    [SerializeField] private Sprite dialogueHint;
    [SerializeField] private Sprite dialogueBox;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer.sprite = dialogueHint;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            spriteRenderer.sprite = dialogueBox;
            dialogueText.text = sentences[0];
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            spriteRenderer.sprite = dialogueBox;
            dialogueText.text = sentences[0];
        }
    }
}
