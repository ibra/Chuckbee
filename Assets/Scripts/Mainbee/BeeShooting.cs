using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class BeeShooting : MonoBehaviour
{
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float shootForce = 25f;
    
    private BeeMovement _beeMovement;
    private bool _positionOccupied;

    private ControlledBee _controlledBee;

    private void Start()
    {
        _beeMovement = GetComponent<BeeMovement>();
    }

    private void Update()
    {
        if (_beeMovement.ControlledBees.Count == 0) return;
        
        if (Input.GetMouseButtonDown(0) && !_positionOccupied)
        {
            _controlledBee = _beeMovement.ControlledBees[Random.Range(0, _beeMovement.ControlledBees.Count)];
            
            _beeMovement.ControlledBees.Remove(_controlledBee);
            
            _controlledBee.enabled = false;
            _controlledBee.GetComponent<Rigidbody2D>().isKinematic = true;

            _controlledBee.transform.position = shootPoint.transform.position;
            _controlledBee.transform.eulerAngles = Vector3.zero;
            _controlledBee.transform.parent = shootPoint.transform;
            
            _positionOccupied = true;

        }
        else if (Input.GetMouseButtonDown(0) && _positionOccupied)
        {
            Rigidbody2D controlledRigidbody = _controlledBee.GetComponent<Rigidbody2D>();
            controlledRigidbody.isKinematic = false;
            controlledRigidbody.AddForce(shootPoint.right * shootForce);
            _controlledBee.transform.parent = null;
            Destroy(_controlledBee, 5f);
            _positionOccupied = false;
        }

    }
}
