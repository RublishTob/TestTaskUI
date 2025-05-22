using System.Collections;
using UnityEngine;

public class ButtonChangeCharacter : ButtonView
{
    [SerializeField] private ChangeButtonType changeButtonType;
    [SerializeField] private CharacterView _characterView;

    private bool _isCanClick = true;
    private float _timeToClick = 1f;

    public override void Click()
    {
        if (!_isCanClick)
        {
            return;
        }
        if (changeButtonType == ChangeButtonType.Left)
        {
            _characterView.ChangeLeft();
            _isCanClick = false;
            StartCoroutine(TimerOrderToClick());
        }
        else
        {
            _characterView.ChangeRight();
            _isCanClick = false;
            StartCoroutine(TimerOrderToClick());
        }
    }

    private IEnumerator TimerOrderToClick()
    {
        yield return new WaitForSeconds(_timeToClick);
        _isCanClick = true;
    }
}

public enum ChangeButtonType
{
    Left,
    Right
}