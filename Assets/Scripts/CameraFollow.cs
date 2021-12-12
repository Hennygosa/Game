using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public Canvas canv;

    private float cameraZoomInDelay = 2f;
    private float timeElapsed;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        canv = gameObject.GetComponentInChildren<Canvas>();
        canv.enabled = false;
        gameObject.transform.rotation = Quaternion.Euler(45, 0, 0);
        //disable controls
        target.GetComponentInParent<PlayerCombatMelee>().enabled = false;
        target.GetComponentInParent<PlayerCombatRanged>().enabled = false;
        target.GetComponentInParent<Player>().enabled = false;
        target.GetComponentInParent<PlayerMovement>().enabled = false;
        target.GetComponentInParent<PlayerDash>().enabled = false;
    }

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed > cameraZoomInDelay)
        {
            gameObject.transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(90, 0, 0), 100 * Time.deltaTime);
            canv.transform.rotation = gameObject.transform.rotation;
            offset = new Vector3(0, 100, 0);
        }
        if (timeElapsed > cameraZoomInDelay + 1)
        {
            gameObject.GetComponent<Camera>().orthographic = true;
            canv.enabled = true;
            //enable controls
            target.GetComponentInParent<PlayerCombatMelee>().enabled = true;
            target.GetComponentInParent<PlayerCombatRanged>().enabled = true;
            target.GetComponentInParent<Player>().enabled = true;
            target.GetComponentInParent<PlayerMovement>().enabled = true;
            target.GetComponentInParent<PlayerDash>().enabled = true;
        }
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
