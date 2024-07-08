using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    List<Vector3> cameraPositions = new List<Vector3>() {
        new Vector3(10F, 15.5F, -10F),
        new Vector3(10F, 15.5F, 10F),
        new Vector3(-10F, 15.5F, 10F),
        new Vector3(-10F, 15.5F, -10F)
    };

    List<Vector3> cameraAngles = new List<Vector3>() {
        new Vector3(50F, 315F, 0F),   // Euler angles for rotation around Y-axis
        new Vector3(50F, 225F, 0F),   // Euler angles for rotation around Y-axis
        new Vector3(50F, 135F, 0F),    // Euler angles for rotation around Y-axis
        new Vector3(50F, 45F, 0F)      // Euler angles for rotation around Y-axis
    };

    int index = 0;
    bool first = true;
    bool isTransitioning = false;
    float transitionSpeed = 5f; // Speed of the transition

    Vector3 targetPosition;
    Quaternion targetRotation;

    void Update()
    {
        if (!isTransitioning)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (first)
                {
                    index = 1;
                    first = false;
                }
                else
                {
                    index++;
                    if (index >= cameraPositions.Count)
                        index = 0;
                }

                SetTarget();
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                if (first)
                {
                    index = 0;
                    first = false;
                }
                else
                {
                    index--;
                    if (index < 0)
                        index = cameraPositions.Count - 1;
                }

                SetTarget();
            }
        }

        if (isTransitioning)
        {
            float step = transitionSpeed * Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, targetPosition, step);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, step);

            if (Vector3.Distance(transform.position, targetPosition) < 0.1f && Quaternion.Angle(transform.rotation, targetRotation) < 1f)
            {
                isTransitioning = false;
                transform.position = targetPosition;
                transform.rotation = targetRotation;
            }
        }
    }

    void SetTarget()
    {
        targetPosition = cameraPositions[index];
        targetRotation = Quaternion.Euler(cameraAngles[index]);
        isTransitioning = true;
    }
}
