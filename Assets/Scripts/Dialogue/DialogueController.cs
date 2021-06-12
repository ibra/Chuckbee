using System;
using TMPro;
using UnityEngine;


public class DialogueController : MonoBehaviour
{
    [SerializeField] private bool forceIdle;
    
    [TextArea(0, 2)] [SerializeField] private string[] sentences;
    private int _index;

    [SerializeField] private Sprite dialogueHint;
    [SerializeField] private Sprite dialogueBox;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer.sprite = dialogueHint;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
        {
            // 3 sentences and our index is less than 3
            if (_index >= sentences.Length - 1) return;
            _index++;
            spriteRenderer.sprite = dialogueBox;
            dialogueText.text = sentences[_index];
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            spriteRenderer.sprite = dialogueBox;
            dialogueText.text = sentences[_index];
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (_index < sentences.Length - 1 && _index != 0) return;
            dialogueText.text = string.Empty;
            _index = 0;
            spriteRenderer.sprite = dialogueHint;
        }
    }

    public void ForcePlayerIdle(BeeMovement _beeMovement)
    {
        _beeMovement.enabled = false;
    }

}
