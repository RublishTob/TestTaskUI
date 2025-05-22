using UnityEngine;
using UnityEngine.UI;

public abstract class ButtonView : MonoBehaviour
{
    private Button _button;
    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(Click);
    }
    private void OnDisable()
    {
        _button.onClick.RemoveListener(Click);
    }

    public abstract void Click();

}
