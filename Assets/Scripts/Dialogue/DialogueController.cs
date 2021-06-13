using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;


public class DialogueController : MonoBehaviour
{
    [SerializeField] private bool forceIdle;
    
    [TextArea(0, 2)] [SerializeField] private string[] sentences;
    private int _index;

    [SerializeField] private Sprite dialogueHint;
    [SerializeField] private Sprite dialogueBox;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] private UnityEvent OnDialogueEnd;
    [SerializeField] private UnityEvent OnDialogueBegin;
    
    private BeeMovement _beeMovement;
    private bool _inRange;

    private void Start()
    {
        spriteRenderer.sprite = dialogueHint;
        OnDialogueEnd ??= new UnityEvent();
        OnDialogueBegin ??= new UnityEvent();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return) && _inRange)
        {
            // 3 sentences and our index is less than 3
            if (_index >= sentences.Length - 1)
            {
                if (forceIdle) ForcePlayerIdle(_beeMovement, false);
                forceIdle = false;
                _inRange = false;
                return;
            }
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
            _beeMovement = other.GetComponent<BeeMovement>();
            _inRange = true;
            OnDialogueBegin.Invoke();
            if (forceIdle) ForcePlayerIdle(_beeMovement, true);

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (_index < sentences.Length - 1 && _index != 0) return;
            dialogueText.text = string.Empty;
            _index = 0;
            _inRange = false;
            OnDialogueEnd.Invoke();
            spriteRenderer.sprite = dialogueHint;
        }
    }

    public void ForcePlayerIdle(BeeMovement beeMovement, bool enable)
    {
        beeMovement.ForceIdle = enable;
    }

}
