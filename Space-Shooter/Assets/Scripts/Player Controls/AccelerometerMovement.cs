using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccelerometerMovement : MonoBehaviour
{
    // Variables
    public float movementSpeed = 50;
    private PlayerStatus status;
    private VirtualJoystick moveJoystick;
    private Image joystickImage;

    private Matrix4x4 calibrationMatrix;
    private Vector3 originalTilt = Vector3.zero;
    private Vector3 _InputDir;
    public bool inMenuScene = false;

    // Get references
    private void Start()
    {
        status = GetComponent<PlayerStatus>();
        if (!inMenuScene)
        {
            moveJoystick = FindObjectOfType<VirtualJoystick>();
            joystickImage = FindObjectOfType<VirtualJoystick>().GetComponent<Image>();
        }
    }

    // Set calibrated input to new variable and move the player according to new input
    private void Update()
    {
        if (!inMenuScene)
        {
            if (!status.isRespawning)
            {
                // Set the status according to the save file
                if (SaveManager.Instance.GetControlStatus(true))
                {
                    joystickImage.enabled = false;
                    _InputDir = GetAccelerometer(Input.acceleration);
                    transform.Translate(new Vector3(((_InputDir.x) * Time.deltaTime * movementSpeed), 0.0f, ((_InputDir.y) * Time.deltaTime * movementSpeed)));
                    transform.position = new Vector3(Mathf.Clamp(transform.position.x, -23.5f, 23.5f), 0.5f, Mathf.Clamp(transform.position.z, -16, 16));
                }
                else
                {
                    if (moveJoystick.InputDirection != Vector3.zero)
                    {
                        joystickImage.enabled = true;
                        _InputDir = moveJoystick.InputDirection;
                        transform.Translate(new Vector3(((_InputDir.x) * Time.deltaTime * movementSpeed), 0.0f, ((_InputDir.y) * Time.deltaTime * movementSpeed)));
                        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -23.5f, 23.5f), 0.5f, Mathf.Clamp(transform.position.z, -16, 16));
                    }
                }
            }
        }
    }

    // Method for calibration
    public void CalibrateAccelerometer()
    {
        originalTilt = Input.acceleration;
        Quaternion rotateQuaternion = Quaternion.FromToRotation(new Vector3(0f, 0f, -1f), originalTilt);

        // Create identity matrix and rotate our matrix to match up with down vec
        Matrix4x4 matrix = Matrix4x4.TRS(Vector3.zero, rotateQuaternion, new Vector3(1f, 1f, 1f));

        // Get the inverse of the matrix
        calibrationMatrix = matrix.inverse;

        Debug.Log("Accelerometer was calibrated");
    }

    // Method to get the calibrated input
    private Vector3 GetAccelerometer(Vector3 accelerator)
    {
        Vector3 accel = this.calibrationMatrix.MultiplyVector(accelerator);
        return accel;
    }
}
