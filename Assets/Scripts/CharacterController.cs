using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Vector3 playerVelocity;
    public float playerSpeed = 6.0f;
    public GameObject character;
    public GameObject uiPanel;

    void Start()
    {
        // Ensure the UI panel is initially disabled
        uiPanel.SetActive(false);
    }

    void Update()
    {
        // Check for the Escape key press
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Toggle the visibility of the UI panel
            ToggleUIPanel();
        }

        // Movement controls
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * playerSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * playerSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.forward * playerSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.back * playerSpeed * Time.deltaTime;
        }
    }

    void ToggleUIPanel()
    {
        // Toggle the active state of the UI panel
        uiPanel.SetActive(!uiPanel.activeSelf);

        // You can add more logic here if needed, such as pausing the game
    }
}
