using UnityEngine;

public class FloorCycle : MonoBehaviour
{
    public Renderer floorRenderer;
    public Material[] materials;

    private int index = 0;

    public void ChangeFloor()
    {
        if (materials == null || materials.Length == 0)
        {
            Debug.LogWarning("No materials assigned!");
            return;
        }

        index = (index + 1) % materials.Length;

        floorRenderer.material = materials[index];
    }
}