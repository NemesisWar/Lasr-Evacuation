using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;
using System.Collections;

public class Teacher : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private List<GameObject> _points = new List<GameObject>();
    [SerializeField] private RectTransform _canvasRect;
    [SerializeField] private RectTransform _teacher;
    [SerializeField] private float _warpTime;
    [SerializeField] private StopTime _stopTime;
    private Animator _animator;
    private Coroutine _coroutine;
    private int _step;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _step = 0;
        MoveFinger(CoordinatesOnScreen(_points[_step]));
    }

    private void OnEnable()
    {
        _stopTime.FirstZombieInTrigger += OnFirstZombieFinger;
    }

    private void OnDisable()
    {
        _stopTime.FirstZombieInTrigger -= OnFirstZombieFinger;
    }

    private void ToGoToDefaultPosition()
    {
        MoveFinger(new Vector2(Screen.width+_teacher.sizeDelta.x, Screen.height+_teacher.sizeDelta.y));
    }

    private void OnFirstZombieFinger(GameObject obj)
    {
        _points.Add(obj);
        Vector2 anchoredPos = Vector2.zero;
        Vector3 normalizePositionOnScreen = Camera.main.WorldToViewportPoint(obj.transform.position);
        Vector3 positionOnScreen = new Vector3(Screen.width * normalizePositionOnScreen.x, Screen.height * normalizePositionOnScreen.y, 0);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvasRect, positionOnScreen, null, out anchoredPos);
        _teacher.DOAnchorPos(anchoredPos, _warpTime).SetUpdate(true);
    }

    private RectTransform GetNewRectPoint()
    {
        return _points[_step].GetComponent<RectTransform>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        PlayAnimation();
        Time.timeScale = 1f;
        ExecuteEvents.Execute(_points[_step], new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
        _step++;
        if(_points.Count == _step)
        {
            ToGoToDefaultPosition();
            return;           
        }
        MoveFinger(CoordinatesOnScreen(_points[_step]));
    }

    private Vector2 CoordinatesOnScreen(GameObject target)
    {
        Vector2 anchoredPos = Vector2.zero;
        if (target.GetComponent<RectTransform>())
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvasRect, GetNewRectPoint().position, null, out anchoredPos);
        }

        else if (target.GetComponent<Transform>())
        {
            Vector3 normalizePositionOnScreen = Camera.main.WorldToViewportPoint(target.transform.position);
            Vector3 positionOnScreen = new Vector3(Screen.width * normalizePositionOnScreen.x, Screen.height * normalizePositionOnScreen.y, 0);
            RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvasRect, positionOnScreen, null, out anchoredPos);
        }

        return anchoredPos;
    }
    
    private void MoveFinger(Vector2 newPosition)
    {
        _teacher.DOAnchorPos(newPosition, _warpTime);
    }

    private IEnumerator AnimationCoroutineTime()
    {
        _animator.SetBool("NeedClick", false);
        yield return new WaitForSeconds(_warpTime);
        _animator.SetBool("NeedClick", true);
    }

    private void PlayAnimation()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }

        _coroutine = StartCoroutine(AnimationCoroutineTime());
    }
}
