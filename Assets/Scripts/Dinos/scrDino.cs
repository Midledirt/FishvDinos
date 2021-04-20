using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class scrDino : MonoBehaviour
{
    public static Action<scrFishHealth, int> OnDealingDamage;
    public static Action OnDinoGoalReached;
    [Tooltip("This float is used to generate a goal possition for the dinos. Increase the number to make the path for the dinosaurs longer")]
    [SerializeField] private float mapLength;
    private Vector3 dinoGoalPos;
    [SerializeField] private float dinoMovementSpeed;
    private Vector3 dinoEndOfPathPoint; //Used to illustrate mapLength
    private float minDistanceToEnoughToEndPoint = 4f;
    private bool dinoCanMove;
    private scrFishHealth currentDinoTargetHealth;
    [SerializeField] private float attackTimer;
    private float timeSinceLastAttack;

    private void Start()
    {
        dinoCanMove = true;
        timeSinceLastAttack = 0f;
    }
    private void Update()
    {
        MoveDino();
        DealDamage();
        if((transform.position - dinoGoalPos).magnitude <= minDistanceToEnoughToEndPoint)
        {
            DinoReachedGoal();
        }
    }
    private void MoveDino()
    {
        if(!dinoCanMove)
        {
            return;
        }
        transform.position = Vector3.Lerp(transform.position, dinoGoalPos, dinoMovementSpeed * Time.deltaTime);
    }
    private void DealDamage()
    {
        if(!dinoCanMove)
        {
            if (currentDinoTargetHealth != null)
            {
                //print("i have a target...");
                timeSinceLastAttack += 1 * Time.deltaTime;
                if (timeSinceLastAttack >= attackTimer)
                {
                    print("attempting to deal damage...");
                    timeSinceLastAttack = 0f;
                    OnDealingDamage?.Invoke(currentDinoTargetHealth, 1);
                }
            }
        }
        
    }
    private scrFishHealth ReturnCurrentTarget(scrFishHealth _newTarget)
    {
        return currentDinoTargetHealth = _newTarget;
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 12)
        {
            print("meet a fish...");
            scrFishHealth _newDinoTargetHealth = collision.GetComponent<scrFishHealth>();
            ReturnCurrentTarget(_newDinoTargetHealth);
            dinoCanMove = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 12)
        {
            currentDinoTargetHealth = null;
            dinoCanMove = true;
        }
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
