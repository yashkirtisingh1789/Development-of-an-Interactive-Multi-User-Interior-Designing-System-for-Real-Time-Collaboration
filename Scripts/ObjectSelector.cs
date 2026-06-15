using UnityEngine;

public class ObjectSelector : MonoBehaviour
{
    public static GameObject selectedObject;

    void OnMouseDown()
    {
        selectedObject = gameObject;
        Debug.Log("Selected: " + gameObject.name);
    }
}