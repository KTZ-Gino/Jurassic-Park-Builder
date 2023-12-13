using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Paddock : Selectable
{
    [SerializeField] private Animator _selectedAnimator;
    [SerializeField] private Animator _dinosaurAnimator;
    [SerializeField] private GameObject _evolutionsChanger;
    [SerializeField] private AnimationEventsListener _dinosaurAnimationEventsListener;

    private MoneyObject _moneyObject;

    private void Awake()
    {
        _moneyObject = GetComponent<MoneyObject>();
    }

    private void Start()
    {
        _evolutionsChanger.SetActive(IsSelected);
    }

    private void OnMouseUp()
    {
        if (!EventSystem.current.IsPointerOverGameObject() && !GridBuildingSystem.Current.TempGridBuilding)
        {
            Select();
        }
    }

    public override void Select()
    {
        base.Select();

        _evolutionsChanger.SetActive(IsSelected);

        _selectedAnimator.SetBool("FadeInOut", IsSelected);

        if (_dinosaurAnimationEventsListener.IsAnimationEnded && _moneyObject.CurrentMoneyInteger != 0)
        {
            _dinosaurAnimator.SetTrigger("Fun");

            PlaySound(Sounds[2], 0.5f);
        }
    }

    public override void Unselect()
    {
        base.Unselect();

        _evolutionsChanger.SetActive(IsSelected);

        _selectedAnimator.SetBool("FadeInOut", IsSelected);
    }
}
