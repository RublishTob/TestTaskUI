using UnityEngine;
using UnityEngine.UI;

public class NavigateButton : MonoBehaviour
{
    [SerializeField] private UIRouter _uiRouter;
    [SerializeField] private PanelEnum _panelNavigateTo;
    [SerializeField] private Button _button;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClick);
    }
    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);
    }

    private void OnClick()
    {
        _uiRouter.ChangePanel(_panelNavigateTo);
    }
}
