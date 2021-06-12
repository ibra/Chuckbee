using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BeeMovement : MonoBehaviour
{
    public List<ControlledBee> ControlledBees;
    
    private Rigidbody2D _rb;
    
    [SerializeField] private Camera _camera;
    [SerializeField] private float moveSpeed = 25f;

    [SerializeField] private TextMeshProUGUI beesCollectedText;
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        beesCollectedText.text = ControlledBees.Count.ToString();
    }

    private void FixedUpdate()
    {
        //Movement
        _rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) *
                       (moveSpeed * Time.fixedDeltaTime);
        
        //Rotation
        Vector2 inputPos = _camera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = inputPos - _rb.position;
        float angleOffset = 0f;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - angleOffset;
        _rb.rotation = angle;
    }
}
