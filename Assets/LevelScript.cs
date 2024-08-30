using UnityEngine;

public class LevelScript : MonoBehaviour
{
    public static LevelScript instance;

    public GameObject knifePrefab; // Reference to the knife prefab
    public Transform throwPoint; // Point from where the knife will be thrown

    private void Update()
    {
        // Check for input to throw the knife (e.g., pressing the space bar)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ThrowKnife();
        }
    }

    private void ThrowKnife()
    {
        if (knifePrefab && throwPoint)
        {
            // Instantiate the knife at the throw point
            GameObject knife = Instantiate(knifePrefab, throwPoint.position, throwPoint.rotation);

            // Get the Knife script and Rigidbody2D component
            Knife knifeScript = knife.GetComponent<Knife>();
            Rigidbody2D rb = knife.GetComponent<Rigidbody2D>();

            if (rb)
            {
                // Set the knife's velocity based on throw direction and speed
                rb.velocity = throwPoint.up * knifeScript.speed;

                // Optionally, enable rotation
                knifeScript.knifeRot = true;
            }
        }
    }
}
