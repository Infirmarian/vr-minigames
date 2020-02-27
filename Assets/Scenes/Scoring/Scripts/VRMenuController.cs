using UnityEngine;
using UnityEngine.UI;

public class VRMenuController : MonoBehaviour
{
    [SerializeField]
    private Image instructions;
    [SerializeField]
    private Canvas menu;

    public void HideMenu()
    {
        menu.gameObject.SetActive(false);
    }

    public void ShowResults()
    {

    }
}
