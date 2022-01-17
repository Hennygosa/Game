using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float maxX;
    public float maxZ;
    public float minX;
    public float minZ;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public Canvas canv;

    private bool isCountingTime = true;
    private float cameraZoomInDelay = 2f;
    private float timeElapsed;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        canv = gameObject.GetComponentInChildren<Canvas>();
        canv.enabled = false;
        gameObject.transform.rotation = Quaternion.Euler(45, 0, 0);
        DisableControls();
    }
    

    void FixedUpdate()
    {
        if (isCountingTime)
            timeElapsed += Time.deltaTime;

        
        if (timeElapsed > cameraZoomInDelay && isCountingTime)
        {
            gameObject.transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(90, 0, 0), 100 * Time.deltaTime);
            canv.transform.rotation = gameObject.transform.rotation;
            offset = new Vector3(0, 100, 0);
        }
        if (timeElapsed > cameraZoomInDelay + 1 && isCountingTime)
        {
            gameObject.GetComponent<Camera>().orthographic = true;
            canv.enabled = true;
            EnableControls();
            isCountingTime = false;
        }
        if (player != null)
        {
            Vector3 desiredPosition = player.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
            if (transform.position.x > maxX)
                transform.position = new Vector3(maxX, transform.position.y, transform.position.z);
            if (transform.position.x < minX)
                transform.position = new Vector3(minX, transform.position.y, transform.position.z);
            if (transform.position.z > maxZ)
                transform.position = new Vector3(transform.position.x, transform.position.y, maxZ);
            if (transform.position.z < minZ)
                transform.position = new Vector3(transform.position.x, transform.position.y, minZ);
        }
        else
            return;
    }
    private void DisableControls()
    {
        player.GetComponentInParent<PlayerCombatMelee>().enabled = false;
        player.GetComponentInParent<PlayerCombatRanged>().enabled = false;
        player.GetComponentInParent<Player>().enabled = false;
        player.GetComponentInParent<PlayerMovement>().enabled = false;
        player.GetComponentInParent<PlayerDash>().enabled = false;
    }
    private void EnableControls()
    {
        
        player.GetComponentInParent<PlayerCombatMelee>().enabled = true;
        player.GetComponentInParent<PlayerCombatRanged>().enabled = true;
        player.GetComponentInParent<Player>().enabled = true;
        player.GetComponentInParent<PlayerMovement>().enabled = true;
        player.GetComponentInParent<PlayerDash>().enabled = true;
    }
}
