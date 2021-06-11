using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody2D))]
public class ControlledBee : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 20;
    [SerializeField] private float minimumDistance = 20f;
    
    [SerializeField] private float randomness = 5f;
    [SerializeField] private Vector2  randomnessVector;

    private Rigidbody2D _rb;
    private static List<Rigidbody2D> EnemyRBs;
    
    private BeeMovement _beeMovement;
    private bool _isControlled;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        // minimumDistance = Random.Range(minimumDistance, minimumDistance + randomness);
        moveSpeed = Random.Range(moveSpeed, moveSpeed + 0.25f);
    }

    private void FixedUpdate()
    {
        if (_isControlled)
        {
            // // transform.right = _beeMovement.transform.position - transform.position;
            if (Vector3.Distance(transform.position, _beeMovement.transform.position) > minimumDistance)
            {
                Vector2 movePosition = Vector2.MoveTowards(transform.position, (Vector2)_beeMovement.transform.position, moveSpeed * Time.deltaTime);
                _rb.MovePosition(movePosition);
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
