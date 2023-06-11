using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnitPanelElement : MonoBehaviour
{
    [SerializeField] private Image _bodyIcon;
    [SerializeField] private Image _headIcon;
    [SerializeField] private Image _leftEye;
    [SerializeField] private Image _rightEye;

    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private Image _background;

    [SerializeField] private TMP_Text _movesCounter;
    [SerializeField] private TMP_Text _jumpsCounter;
    [SerializeField] private TMP_Text _rotatesCounter;
    [SerializeField] private TMP_Text _specialCounter;
    [SerializeField] private TMP_Text _hotKey;

    public int Index { get; private set; }
    public Color Color { get; private set; }
    private string _name;
    private a_Unit _unit;

    public int MovesCount {get; private set;}
    public int JumpsCount {get; private set;}
    public int RotatesCount {get; private set;}
    public int SpecialCount { get; private set; }

    public Image Background
    {
        get => _background;
        set => _background = value;
    }

    public a_Unit Unit => _unit;

    public event System.Action<int> Clicking;

    private void Update()
    {
        if (Input.GetKeyDown((Index+1).ToString()))
        {
            OnClicked();
        }
    }

    public void Set(a_Unit unit, int index, IconsSet icons, string name, Color color, Color bodyColor)
    {
        Index = index;
        _hotKey.text = $"[{index+1}]";

        _headIcon.color = color;
        _bodyIcon.color = bodyColor;
        _leftEye.sprite = icons.Eye;
        _rightEye.sprite = icons.Eye;

        _unit = unit;
        _name = name;
        Color = color;

        UpdateName();

        _unit.Moved += OnMoved;
    }

    private void OnMoved()
    {
        UpdateName();
         if (Board.Instance.CoinPosition != null && Unit.Position == Board.Instance.CoinPosition)
        {
            FindObjectOfType<Coin>().OnCollected();
        }
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
        Clicking?.Invoke(Index);
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