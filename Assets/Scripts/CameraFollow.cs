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
        gameObject.transform.rotation = Quaternion.Euler(45, 0, 0);
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
        if (timeElapsed > cameraZoomInDelay + 2)
        {
            gameObject.GetComponent<Camera>().orthographic = true;
        }
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
