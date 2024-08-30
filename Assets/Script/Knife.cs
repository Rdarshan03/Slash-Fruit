using UnityEngine;

public class Knife : MonoBehaviour
{
    public float speed = 10f; // Speed of the knife
    public float lifetime = 5f; // Time after which the knife is destroyed
    public bool knifeRot = false; // Flag to enable rotation
    public float rotationSpeed = 100f; // Rotation speed in degrees per second

    private void Start()
    {
        // Destroy the knife after its lifetime expires
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        // Rotate the knife if knifeRot is true
        if (knifeRot)
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("line"))
        {
            // Destroy the knife on collision with an object tagged "line"
            Destroy(gameObject);
        }
    }
}
