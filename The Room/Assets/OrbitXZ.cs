using UnityEngine;

public class OrbitXZ : MonoBehaviour
{
    public Vector3 center = Vector3.zero; // center of the orbit
    public float radius = 5f;             // orbit radius
    public float speed = 1f;              // orbit speed (radians per second)

    private float angle = 0f;

    void Update()
    {
        // increment angle based on time and speed
        angle += speed * Time.deltaTime;

        // compute new position
        float x = center.x + radius * Mathf.Cos(angle);
        float z = center.z + radius * Mathf.Sin(angle);
        float y = transform.position.y; // keep original Y

        transform.position = new Vector3(x, y, z);
    }
}
