using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class NavigateButton : ButtonView
{
    [SerializeField] private UIRouter _uiRouter;
    [SerializeField] private PanelEnum _panelNavigateTo;

    private Sequence _sequense;
    private Transform _startTransform;

    private void Start()
    {
        _startTransform = transform;  
    }

    public override void Click()
    {
        StartCoroutine(AnimateAndNavigate());
    }

    private IEnumerator AnimateAndNavigate()
    {
        if (_sequense == null)
            _sequense = DOTween.Sequence();

        _sequense.Append(transform.DOMoveY(transform.position.y + 0.1f, 0.5f).SetEase(Ease.OutElastic)).SetLoops(1,LoopType.Yoyo);
        _sequense.Append(transform.DOMove(_startTransform.position, 0.5f));

       yield return new WaitForSeconds(0.4f);

        _uiRouter.ChangePanel(_panelNavigateTo);

        _sequense = null;
    }
}
