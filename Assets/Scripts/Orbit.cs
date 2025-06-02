using UnityEngine;

public class Orbit : MonoBehaviour {
    public Transform target;
    public float speed = 250f;
    public Vector3 axis = Vector3.up; // Orbit axis (Y = horizontal spin)

    private void Update() {
        if (target != null) transform.RotateAround(target.position, axis, speed * Time.deltaTime);
    }
}