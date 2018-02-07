using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerometerTest : MonoBehaviour {

    // Variables
    public float movementSpeed = 50;

    private Matrix4x4 calibrationMatrix;
    private Vector3 originalTilt = Vector3.zero;
    private Vector3 _InputDir;

    public GameObject afterBurnerPrefab;

    // Load accelerometer callibration -> this should be before scene loads
    private void Start()
    {
        CalibrateAccelerometer();
        afterBurnerPrefab.SetActive(false);
    }

    // Set calibrated input to new variable and move the player according to new input
    private void Update ()
    {
        transform.hasChanged = false;
        _InputDir = GetAccelerometer(Input.acceleration);
        transform.Translate(new Vector3 (((_InputDir.x) * Time.deltaTime * movementSpeed), 0.0f, ((_InputDir.y) * Time.deltaTime * movementSpeed)));
        transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);

        if (transform.hasChanged)
        {
            afterBurnerPrefab.SetActive(true);
            transform.hasChanged = false;
        }
        if (!transform.hasChanged)
        {
            afterBurnerPrefab.SetActive(false);
        }
	}

    // Method for calibration
    private void CalibrateAccelerometer()
    {
        originalTilt = Input.acceleration;
        Quaternion rotateQuaternion = Quaternion.FromToRotation(new Vector3(0f, 0f, -1f), originalTilt);

        // Create identity matrix and rotate our matrix to match up with down vec
        Matrix4x4 matrix = Matrix4x4.TRS(Vector3.zero, rotateQuaternion, new Vector3(1f, 1f, 1f));

        // Get the inverse of the matrix
        calibrationMatrix = matrix.inverse;

    }

    // Method to get the calibrated input
    private Vector3 GetAccelerometer(Vector3 accelerator)
    {
        Vector3 accel = this.calibrationMatrix.MultiplyVector(accelerator);
        return accel;
    }
}
