using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(Rigidbody))]
public class DragObject : MonoBehaviourPun
{
    private float distance;
    private Vector3 offset;
    private Camera cam;
    private Rigidbody rb;
    private PhotonView pv;

    public float heightSpeed = 2f;
    public float minHeight = 0.1f;
    public float gridSize = 0.5f;

    void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
        pv = GetComponent<PhotonView>();

        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    void OnMouseDown()
    {
        if (InteractionManager.instance.currentMode != InteractionManager.Mode.Move)
            return;

        // ✅ TAKE OWNERSHIP (IMPORTANT)
        if (pv != null && PhotonNetwork.IsConnected)
        {
            pv.RequestOwnership();
        }

        distance = Vector3.Distance(transform.position, cam.transform.position);

        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 worldPos = cam.ScreenToWorldPoint(mousePos);

        offset = transform.position - worldPos;
    }

    void OnMouseDrag()
    {
        if (InteractionManager.instance.currentMode != InteractionManager.Mode.Move)
            return;

        // ✅ ONLY OWNER MOVES
        if (pv != null && PhotonNetwork.IsConnected && !pv.IsMine)
            return;

        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 worldPos = cam.ScreenToWorldPoint(mousePos);

        Vector3 targetPos = worldPos + offset;

        float newY = transform.position.y;

        if (Input.GetKey(KeyCode.E))
            newY += heightSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.Q))
            newY -= heightSpeed * Time.deltaTime;

        if (newY < minHeight)
            newY = minHeight;

        targetPos.y = newY;

        targetPos.x = Mathf.Round(targetPos.x / gridSize) * gridSize;
        targetPos.z = Mathf.Round(targetPos.z / gridSize) * gridSize;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 5f))
        {
            if (hit.collider.CompareTag("Floor"))
            {
                targetPos.y = hit.point.y + 0.1f;
            }
        }

        rb.MovePosition(targetPos);
    }
}