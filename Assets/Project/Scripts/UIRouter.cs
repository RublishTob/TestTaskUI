using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRouter : MonoBehaviour
{
    [SerializeField] private GameObject[] _panelsGO;
    [SerializeField] private PanelEnum[] _panelsList;

    [SerializeField] private GameObject _fade;
    [SerializeField] private ChangeBrightness _changeBrightness;

    private Dictionary<PanelEnum, GameObject> _panels = new();

    private void Start()
    {
        for (int i = 0; i < _panelsGO.Length; i++)
        {
            _panels.Add(_panelsList[i], _panelsGO[i]);
            Debug.Log("add" + _panelsList[i].ToString());
        }
        Debug.Log("gameStart");
    }

    public void ChangePanel(PanelEnum panel)
    {
        ActiveFade();
        DeactivateAllPanels();
        _panels[panel].SetActive(true);

        if (panel == PanelEnum.Menu)
        {
            _changeBrightness.ChangeLightColor();
        }
        else
        {
            _changeBrightness.ChangeBrightColor();
        }
    }

    private void ActiveFade()
    {
        StartCoroutine(FadeTemp());
    }
    IEnumerator FadeTemp()
    {
        _fade.SetActive(true);
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
}
