using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnitPanelElement : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private Image _background;
    [SerializeField] private Image _label;

    [SerializeField] private LabelsList _labels;

    [SerializeField] private TMP_Text _movesCounter;
    [SerializeField] private TMP_Text _jumpsCounter;
    [SerializeField] private TMP_Text _rotatesCounter;
    [SerializeField] private TMP_Text _specialCounter;

    private int _index;
    private string _name;
    private a_Unit _unit;

    public int MovesCount {get; private set;}
    public int JumpsCount {get; private set;}
    public int RotatesCount {get; private set;}
    public int SpecialCount { get; private set; }

    private Action[] _actions;

    public Image Background
    {
        get => _background;
        set => _background = value;
    }

    public a_Unit Unit => _unit;

    public Sprite Label => _labels[_index];

    public event System.Action<int> Clicking;
    public void Set(a_Unit unit, int index, Sprite icon, string name, Action[] actions)
    {
        _index = index;
        _icon.sprite = icon;
        _unit = unit;
        _actions = actions;
        _label.sprite = _labels[index];
        _name = name;

        UpdateName();

        _unit.Moving += OnMoved;
    }

    private void OnMoved()
    {
        UpdateName();
    }

    private void UpdateName()
    {
        _nameText.text = $"{_name} ({GetCoordinates()})";
    }

    private string GetCoordinates()
    {
        string[] letters = { "A", "B", "C", "D", "E" };
        return letters[Unit.Position.X] + (Unit.Position.Y + 1);
    }

    public void SetActionsCount(UnitSpawnData spawnData)
    {
        MovesCount = spawnData.MoveAcionsCount;
        JumpsCount = spawnData.JumpAcionsCount;
        RotatesCount = spawnData.RotateAcionsCount;
        SpecialCount = spawnData.SpecialAcionsCount;

        _movesCounter.text = MovesCount.ToString();
        _jumpsCounter.text = JumpsCount.ToString();
        _rotatesCounter.text = RotatesCount.ToString();
        _specialCounter.text = SpecialCount.ToString();
    }

    public void OnClicked()
    {
        Clicking?.Invoke(_index);
    }

    public void OnMove()
    {
        MovesCount--;
        _movesCounter.text = MovesCount.ToString();
    }

    public void OnJump()
    {
        JumpsCount--;
        _jumpsCounter.text = JumpsCount.ToString();
    }

    public void OnRotate()
    {
        RotatesCount--;
        _rotatesCounter.text = RotatesCount.ToString();
    }

    public void OnSpecial()
    {
        SpecialCount--;
        _specialCounter.text = SpecialCount.ToString();
    }

    public void OnMoveCanceled()
    {
        MovesCount++;
        _movesCounter.text = MovesCount.ToString();
    }

    public void OnJumpCanceled()
    {
        JumpsCount++;
        _jumpsCounter.text = JumpsCount.ToString();
    }

    public void OnRotateCanceled()
    {
        RotatesCount++;
        _rotatesCounter.text = RotatesCount.ToString();
    }

    public void OnSpecialCanceled()
    {
        SpecialCount++;
        _specialCounter.text = SpecialCount.ToString();
    }

}