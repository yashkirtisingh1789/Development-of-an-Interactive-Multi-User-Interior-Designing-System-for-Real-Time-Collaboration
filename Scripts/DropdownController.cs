using UnityEngine;

public class DropdownController : MonoBehaviour
{
    public GameObject dropdownPanel;

    public void ToggleDropdown()
    {
        dropdownPanel.SetActive(!dropdownPanel.activeSelf);
    }
}