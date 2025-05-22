using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UIRouter : MonoBehaviour
{
    [SerializeField] private GameObject[] _panelsGO;
    [SerializeField] private PanelEnum[] _panelsList;

    [SerializeField] private GameObject _fade;
    [SerializeField] private ChangeBrightness _changeBrightness;
    [SerializeField] private CharacterView _characterView;

    private Dictionary<PanelEnum, GameObject> _panels = new();

    private void Start()
    {
        for (int i = 0; i < _panelsGO.Length; i++)
        {
            _panels.Add(_panelsList[i], _panelsGO[i]);
        }
    }

    public void ChangePanel(PanelEnum panel)
    {
        StartCoroutine(ActivePanel(panel));
    }

    private IEnumerator ActivePanel(PanelEnum panel)
    {
        yield return StartCoroutine(ActiveFade());

        DeactivateAllPanels();
        _panels[panel].SetActive(true);

        ChangeBrightness(panel);
    }

    IEnumerator ActiveFade()
    {
        _fade.SetActive(true);
        var imageFade = _fade.gameObject.GetComponent<Image>();

        Color c = imageFade.color;
        c.a = 0f;
        imageFade.color = c;

        imageFade.DOFade(1f, 0.2f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.2f);
        _fade.SetActive(false);
    }

    private void DeactivateAllPanels()
    {
        foreach(var panel in _panels.Values)
        {
            panel.SetActive(false);
        }
    }

    private void ChangeBrightness(PanelEnum panel)
    {
        if (panel == PanelEnum.Menu)
        {
            _changeBrightness.ChangeLightColor();
        }
        else
        {
            _changeBrightness.ChangeBrightColor();
            _characterView.Init();
        }
    }
}
