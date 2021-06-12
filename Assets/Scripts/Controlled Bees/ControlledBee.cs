using System;
using System.Collections.Generic;
using BeeGame;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BeeBullet))]
public class ControlledBee : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 20;
    [SerializeField] private float minimumDistance = 20f;
    
    [SerializeField] private  float repelRange = .5f;
    [SerializeField] private float repelAmount = 1f;

    private Rigidbody2D _rb;
    private static List<Rigidbody2D> EnemyRBs;
    
    private BeeMovement _beeMovement;
    private bool _isControlled;
    
  

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        GetComponent<BeeBullet>().enabled = false;
        if (EnemyRBs == null)
        {
            EnemyRBs = new List<Rigidbody2D>();
        }
        EnemyRBs.Add(_rb);
        
        moveSpeed = Random.Range(moveSpeed, moveSpeed + 0.1f);
    }

    private void FixedUpdate()
    {
        if (_isControlled)
        {
            Vector2 direction = ((Vector2)_beeMovement.transform.position - _rb.position).normalized;
            
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            _rb.rotation = angle;
            
            if (Vector3.Distance(transform.position, _beeMovement.transform.position) > minimumDistance)
            {
                Vector2 newPos = MoveRegular(direction);
                newPos -= _rb.position;
                if (_rb.velocity.magnitude < 8f)
                {
                    _rb.AddForce(newPos, ForceMode2D.Force);
                }
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

    private Vector2 MoveRegular(Vector2 direction)
    {
        Vector2 repelForce = Vector2.zero;
        foreach (Rigidbody2D enemy in EnemyRBs)
        {
            if (enemy == _rb)
                continue;

            if (Vector2.Distance(enemy.position, _rb.position) <= repelRange)
            {
                Vector2 repelDir = (_rb.position - enemy.position).normalized;
                repelForce += repelDir;
            }
        }

        Vector2 newPos = transform.position + transform.right * (Time.fixedDeltaTime * moveSpeed);
        newPos += repelForce * (Time.fixedDeltaTime * repelAmount);

        return newPos;
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, minimumDistance);
    }
}
