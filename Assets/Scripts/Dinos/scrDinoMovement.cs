using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class scrDinoMovement : MonoBehaviour
{
    public static Action OnDinoGoalReached;
    [Tooltip("This float is used to generate a goal possition for the dinos. Increase the number to make the path for the dinosaurs longer")]
    [SerializeField] private float mapLength;
    private Vector3 dinoGoalPos;
    [SerializeField] private float dinoMovementSpeed;
    private Vector3 dinoEndOfPathPoint; //Used to illustrate mapLength
    private float minDistanceToEnoughToEndPoint = .2f;

    private void Update()
    {
        MoveDino();
        if((transform.position - dinoGoalPos).magnitude <= minDistanceToEnoughToEndPoint)
        {
            DinoReachedGoal();
        }
    }
    private void MoveDino()
    {
        transform.position = Vector3.Lerp(transform.position, dinoGoalPos, dinoMovementSpeed * Time.deltaTime);
    }
    public Vector3 AssignGoalPos(GameObject _spawnPos)
    {
        dinoGoalPos = _spawnPos.transform.position;
        dinoGoalPos.x -= mapLength;
        return dinoGoalPos;
    }
    private void DinoReachedGoal()
    {
        print("I reached the goal");
        OnDinoGoalReached?.Invoke();
        transform.gameObject.SetActive(false);
    }
    private void OnDrawGizmos() //Visualize the path
    {
        dinoEndOfPathPoint = transform.position;
        dinoEndOfPathPoint.x = transform.position.x - mapLength;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(dinoGoalPos, 2f); //Draw end possition
        Gizmos.DrawLine(transform.position, dinoGoalPos); //Draw the path
        Gizmos.DrawLine(transform.position, dinoEndOfPathPoint);
    }
}
