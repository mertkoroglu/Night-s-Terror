using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    List<Vector3> cameraPositions = new List<Vector3>() {
        new Vector3(10F, 22.65F, 0F),
        new Vector3(0F, 22.65F, 10F),
        new Vector3(-10F, 22.65F, 0F),
        new Vector3(0F, 22.65F, -10F)
    };

    List<Vector3> cameraAngles = new List<Vector3>() {
        new Vector3(70F, -90F, 0F),   // Euler angles for rotation around Y-axis
        new Vector3(70F, 180F, 0F),   // Euler angles for rotation around Y-axis
        new Vector3(70F, 90F, 0F),    // Euler angles for rotation around Y-axis
        new Vector3(70F, 0F, 0F)      // Euler angles for rotation around Y-axis
    };

    int index = 0;
    bool first = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (first)
            {
                index = 0;
                first = false;
            }
            else
            {
                index++; // Move to next position and angle
                if (index >= cameraPositions.Count)
                    index = 0;
            }

            RotateCamera();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (first)
            {
                index = 2;
                first = false;
            }
            else
            {
                index--; // Move to previous position and angle
                if (index < 0)
                    index = cameraPositions.Count - 1;
            }

            RotateCamera();
        }
    }

    void RotateCamera()
    {
        transform.position = cameraPositions[index];
        transform.eulerAngles = cameraAngles[index];
    }
}
