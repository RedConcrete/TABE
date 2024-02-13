using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 0.125f; // Geschwindigkeit der Kamerabewegung
    public Vector3 offset = new Vector3(0f, 15f, -10f); // Offset der Kamera vom Spieler

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        if (player != null)
        {
            // Zielposition der Kamera
            Vector3 targetPosition = player.position + offset;

            // Füge eine kleine zusätzliche Bewegung hinzu, um die Kamera bouncy zu machen
            Vector3 bounceOffset = new Vector3(
                Mathf.Sin(Time.time * 5f) * 0.1f,
                Mathf.Cos(Time.time * 5f) * 0.1f,
                Mathf.Sin(Time.time * 3f) * 0.1f
            );

            // Berechne die endgültige Position der Kamera mit dem Bouncy-Effekt
            Vector3 desiredPosition = targetPosition + bounceOffset;

            // Glätte die Kamerabewegung
            Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);

            // Aktualisiere die Position der Kamera
            transform.position = smoothedPosition;

            // Behalte die Höhe der Kamera bei, aber behalte die Rotation bei, die der Spielerobjekt hat
            transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f);
        }
    }

    // Funktion, um das Ziel der Kamera zu setzen
    public void SetPlayer(Transform newPlayer)
    {
        player = newPlayer;
    }
}
