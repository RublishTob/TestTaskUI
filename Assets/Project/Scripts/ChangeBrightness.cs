using UnityEngine;
using UnityEngine.UI;

public class ChangeBrightness : MonoBehaviour
{

    [SerializeField] private Color _light;
    [SerializeField] private Color _bright;

    private Image _image;
    void Start()
    {
        _image = GetComponent<Image>();
        _image.color = new Color(_light.g, _light.r, _light.b, 200f);
    }

    public void ChangeBrightColor()
    {
        _image.color = new Color(_bright.g, _bright.r, _bright.b, 80f);
    }
    public void ChangeLightColor()
    {
        _image.color = new Color(_light.g, _light.r, _light.b, 200f);
    }
}
