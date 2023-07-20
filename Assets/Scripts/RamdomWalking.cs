using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamdomWalking : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust the movement speed as needed
    public float pauseDuration = 2f; // Adjust the pause duration as needed
    public Vector3 areaMin; // Define the minimum boundaries of the area
    public Vector3 areaMax; // Define the maximum boundaries of the area

    private Vector3 targetPosition;
    private bool isPaused;
    private float pauseTimer;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();

        // Generate a random target position within the specific area
        targetPosition = GetRandomPosition();
    }

    private void Update()
    {
        if (isPaused)
        {
            // If the character is paused, increment the timer
            
            pauseTimer += Time.deltaTime;

            // If the pause duration has passed, resume movement
            if (pauseTimer >= pauseDuration)
            {
                isPaused = false;
                animator.SetBool("IsWalking", true);
                pauseTimer = 0f;
                targetPosition = GetRandomPosition();
            }
        }
        else
        {
            //animator.SetBool("IsWalking", !isPaused);
            // Move towards the target position
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // If the character reaches the target position, pause before moving to the next position
            if (transform.position == targetPosition)
            {
                isPaused = true;
                animator.SetBool("IsWalking", false);
            }
        }

        // Set the animator parameters based on the movement state
        //animator.SetBool("IsWalking", !isPaused);
    }

    private Vector3 GetRandomPosition()
    {
        // Generate a random position within the specific area
        float x = Random.Range(areaMin.x, areaMax.x);
        float y = gameObject.transform.position.y;
        float z = Random.Range(areaMin.z, areaMax.z);

        return new Vector3(x, y, z);
    }
}


