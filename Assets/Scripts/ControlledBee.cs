using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ControlledBee : MonoBehaviour
{
    [SerializeField] private float minVelocity = 5;
    [SerializeField] private float maxVelocity = 20;
    [SerializeField] private float randomness = 1;
    [SerializeField] private float minimumDistance = 20f;

    private Rigidbody2D _rb;
    private static List<Rigidbody2D> EnemyRBs;
    
    private BeeMovement _beeMovement;
    private bool _isControlled;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        if (EnemyRBs == null)
        {
            EnemyRBs = new List<Rigidbody2D>();
        }
        EnemyRBs.Add(_rb);
    }

    private void FixedUpdate()
    {
        if (_isControlled)
        {
            // transform.right = _beeMovement.transform.position - transform.position;
            if (Vector3.Distance(_beeMovement.transform.position, transform.position) > minimumDistance)
            {
                _rb.MovePosition(_beeMovement.transform.position);
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (_isControlled) return;
            _beeMovement = other.GetComponent<BeeMovement>();
            _beeMovement.ControlledBees.Add(this);
            _isControlled = true;
        }
    }
    
    private void OnDestroy()
    {
        EnemyRBs.Remove(_rb);
    }
}
