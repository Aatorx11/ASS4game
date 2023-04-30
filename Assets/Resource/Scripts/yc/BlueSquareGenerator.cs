using UnityEngine;

public class BlueSquareGenerator : MonoBehaviour
{
    public GameObject blueSquarePrefab;
    public float squareDuration = 2f;
    public float generateOffset = 1f;

    private bool canGenerateSquare = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && canGenerateSquare)
        {
            GenerateBlueSquare();
        }
    }

    void GenerateBlueSquare()
    {
        Vector2 generatePosition = new Vector2(transform.position.x, transform.position.y);
        GameObject square = Instantiate(blueSquarePrefab, generatePosition, Quaternion.identity);
        square.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        square.GetComponent<Collider2D>().enabled = true;
        canGenerateSquare = false;
        Invoke("ActivateSquare", 0.8f); // Change Rigidbody type after 1 second
        Destroy(square, squareDuration);
        Invoke("ResetSquareGeneration", 1.5f);
    }

    void ActivateSquare()
    {
        GameObject[] squares = GameObject.FindGameObjectsWithTag("BlueSquare");
        foreach (GameObject square in squares)
        {
            square.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
    }

    void ResetSquareGeneration()
    {
        canGenerateSquare = true;
    }
}
