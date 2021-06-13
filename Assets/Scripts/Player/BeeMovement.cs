using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BeeMovement : MonoBehaviour
{
    public List<ControlledBee> ControlledBees;
    
    private Rigidbody2D _rb;
    private SpriteRenderer _spriteRenderer;
    
    [SerializeField] private Camera _camera;
    [SerializeField] private float moveSpeed = 25f;

    [SerializeField] private TextMeshProUGUI beesCollectedText;
    public bool ForceIdle {get; set;}

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        beesCollectedText.text = $"{ControlledBees.Count} BEES IN SWARM";
    }

    private void FixedUpdate()
    {
        if (!ForceIdle)
        {
            HandleMovement();
        }
        else
        {
            _rb.velocity = Vector2.zero;
        }
      
        HandleRotation();
    }

    private void HandleRotation()
    {
        Vector2 inputPos = _camera.ScreenToWorldPoint(Input.mousePosition);
        transform.localScale = inputPos.x > transform.position.x ? new Vector2(transform.localScale.x, 4) : new Vector2(transform.localScale.x, -4);

        Vector2 lookDir = inputPos - _rb.position;
        float angleOffset = 0f;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - angleOffset;
        _rb.rotation = angle;
    }

    private void HandleMovement()
    {
        _rb.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) *
                       (moveSpeed * Time.fixedDeltaTime);
    }
}
