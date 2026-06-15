using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public static InteractionManager instance;

    public enum Mode
    {
        None,
        Material,
        Move,
        Rotate
    }

    public Mode currentMode = Mode.None;

    void Awake()
    {
        // ✅ SAFE SINGLETON (VERY IMPORTANT)
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // Optional: keep across scenes (safe)
        DontDestroyOnLoad(gameObject);
    }

    // 🔵 MATERIAL MODE
    public void SetMaterialMode()
    {
        currentMode = Mode.Material;
        Debug.Log("Material Mode ON");
    }

    // 🟢 MOVE MODE
    public void SetMoveMode()
    {
        currentMode = Mode.Move;
        Debug.Log("Move Mode ON");
    }

    // 🟡 ROTATE MODE
    public void SetRotateMode()
    {
        currentMode = Mode.Rotate;
        Debug.Log("Rotate Mode ON");
    }

    // 🔴 RESET MODE
    public void SetNoneMode()
    {
        currentMode = Mode.None;
        Debug.Log("No Mode Selected");
    }
}