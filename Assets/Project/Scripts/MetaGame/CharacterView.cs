using System.Collections;
using System.Security.Cryptography;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class CharacterView : MonoBehaviour
{
    [SerializeField] private Image _expIcon;

    [SerializeField] private Image _characterIcon;
    [SerializeField] private Image _character;

    [SerializeField] private Transform _characterTransform;

    [SerializeField] private Transform _fromTransform;
    [SerializeField] private Transform _toTransform;
    [SerializeField] private Transform _moveAlwaysFromTransform;

    public Vector3 moveOffset = new Vector3(0f, 0.2f, 0f);

    [SerializeField] private CharacterLayout _characterLayout;
    [SerializeField] private CharacterData _characterModel;


    private int _nextCharacter;
    private float _characterExpValue = 0.5f;
    private float _durationAnimation = 1f;

    private Tween _characterTween;
    private Tween _expIconTween;
    private Tween _iconCharacterTween;

    public void ChangeLeft()
    {
        _nextCharacter--;

        if (_nextCharacter < 0)
            _nextCharacter = _characterLayout._characters.Length - 1;

        ChangeCharacter();
    }
    public void ChangeRight()
    {
        _nextCharacter++;

        if (_nextCharacter >= _characterLayout._characters.Length)
            _nextCharacter = 0;

        ChangeCharacter();
    }

    public void ChangeCharacter()
    {
        _characterModel = _characterLayout._characters[_nextCharacter];

        _characterIcon.sprite = _characterModel.Icon;
        _character.sprite = _characterModel.Character;
        _characterExpValue = _characterModel.Exp;

        StartCoroutine(StartAnimate());
    }
    public void Init()
    {
        _nextCharacter = 0;
        RestartAnimation();
        ChangeCharacter();
        StartCoroutine(StartAnimate());
    }
    private IEnumerator StartAnimate()
    {
        RestartAnimation();
        FadeIconCharacter();
        FillExpCharacter();
        yield return StartCoroutine(AnimateCharacter());
        MoveAlwaysCharacter();
    }

    public void RestartAnimation()
    {
        _expIconTween = null;
        _characterTween = null;
        _iconCharacterTween = null;
        DOTween.KillAll();
    }
    private void MoveAlwaysCharacter()
    {
        _characterTransform.position = _toTransform.transform.position;
        _characterTween = null;
        _characterTween = _characterTransform.DOMoveY(0.6f, 3f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
    }
    private void FadeIconCharacter()
    {
        Color c = _characterIcon.color;
        c.a = 0f;
        _characterIcon.color = c;

        _iconCharacterTween = _characterIcon.DOFade(1f, 2f).SetEase(Ease.Linear);
    }
    private void FillExpCharacter()
    {
        _expIcon.fillAmount = 0f;
        _expIconTween = _expIcon.DOFillAmount(_characterExpValue / 100f, _durationAnimation).SetEase(Ease.OutCubic);
    }
    private IEnumerator AnimateCharacter()
    {
        _characterTween = null;
        _characterTransform.position = _fromTransform.transform.position;
        _characterTween = _characterTransform.DOMove(_toTransform.position, _durationAnimation).SetEase(Ease.InOutSine);
        yield return new WaitForSeconds(1f);
    }
}