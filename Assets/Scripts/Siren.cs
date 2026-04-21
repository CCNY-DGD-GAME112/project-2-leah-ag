using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Siren : MonoBehaviour
{
    public float rotateSpeed = 360f; // Degrees per second

    void Update() {
        // Rotates the object around its Y-axis continuously
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
    }
}
