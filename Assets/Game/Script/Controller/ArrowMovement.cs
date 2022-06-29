using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    private ArrowController _arrowController;
    [SerializeField] private float swerveSpeed = 0.5f;
    [SerializeField] private float maxSwerveAmount = 1f;
    
    private void Awake()
    {
        _arrowController= GetComponent<ArrowController>();
    }

    private void Update()
    {
        float swerveAmount = Time.deltaTime * swerveSpeed * _arrowController.MoveFactorX;
        swerveAmount = Mathf.Clamp(swerveAmount, -maxSwerveAmount, maxSwerveAmount);
        transform.Translate(swerveAmount, 0, 0);
    }
}
