using UnityEngine;
using Photon.Pun;

public class RotateObject : MonoBehaviourPun
{
    public float rotationSpeed = 200f;
    public float smoothFactor = 10f;

    private float targetRotationY;
    private PhotonView pv;

    void Start()
    {
        pv = GetComponent<PhotonView>();
    }

    void Update()
    {
        if (InteractionManager.instance.currentMode != InteractionManager.Mode.Rotate)
            return;

        if (ObjectSelector.selectedObject != gameObject)
            return;

        if (!Input.GetMouseButton(0))
            return;

        // ✅ TAKE OWNERSHIP ON CLICK
        if (pv != null && PhotonNetwork.IsConnected)
        {
            if (!pv.IsMine)
            {
                if (Input.GetMouseButtonDown(0))
                    pv.RequestOwnership();
                else
                    return;
            }
        }

        float mouseX = Input.GetAxis("Mouse X");

        targetRotationY += mouseX * rotationSpeed * Time.deltaTime;

        Quaternion targetRot = Quaternion.Euler(0, targetRotationY, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, smoothFactor * Time.deltaTime);
    }
}