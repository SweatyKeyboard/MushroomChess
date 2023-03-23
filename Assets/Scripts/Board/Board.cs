using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] private BoardData[] _levels;

    [SerializeField] private BoardCell _cellPrefab;
    [SerializeField] private Transform _finishPrefab;

    [SerializeField] private SingnsList _digits;
    [SerializeField] private SingnsList _letters;

    [SerializeField] private int _boardSize = 5;

    private BoardCell[,] _cellPositions;
    private bool[,] _occupiedCells;

    private int _selectedLevel;

    private float _scale = 1f;
    public float StairScale = 0.1f;

    private ColorRandomizer _colorRandomizer;
    [SerializeField] private UnitPanel _unitPanel;
    public BoardCell[,] Cells => _cellPositions;
    public int LevelCount => _levels.Length;
    public int BoardSize => _boardSize;
    public Position FinishPosition { get; private set; }
    public static Board Instance;
    public Vector3 this[int i, int j] => new Vector3(
        _cellPositions[i, j].transform.position.x,
        _cellPositions[i, j].transform.position.y + _scale * transform.localScale.y,
        _cellPositions[i, j].transform.position.z);

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }


        _cellPositions = new BoardCell[_boardSize, _boardSize];
        _occupiedCells = new bool[_boardSize, _boardSize];

        _colorRandomizer = FindObjectOfType<ColorRandomizer>();
        _colorRandomizer.RandomizeColor();

        _selectedLevel = FindObjectOfType<LevelSelector>().SelectedLevel;
        CreateFromFileData(_levels[_selectedLevel - 1]);
    }

    private void CreateFromFileData(BoardData data)
    {
        _boardSize = data.BoardSize;
        for (int i = 0; i < _boardSize; i++)
        {
            for (int j = 0; j < _boardSize; j++)
            {
                CreateCell(i, j);
                SetCellHeight(i, j, data.HeightMap[i + j * data.BoardSize]);
                ColorChesslike(i, j);
                UpdateSigns(i, j);
            }
        }

        foreach (UnitSpawnData unitSpawnData in data.Units)
        {
            SpawnUnit(unitSpawnData);
        }

        transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
        CreateFinish(data.FinishPosition);
    }

    private void CreateCell(int i, int j)
    {
        _cellPositions[i, j] = Instantiate(
                   _cellPrefab,
                   transform.position +
                   new Vector3(
                       _scale * (i - _boardSize / 2),
                       0,
                       _scale * (j - _boardSize / 2)),
                   Quaternion.identity,
                   transform);
    }

    private void CreateFinish(Position position)
    {
        Instantiate(
               _finishPrefab,
               this[position.X, position.Y] + new Vector3(0, 0.01f, 0),
               Quaternion.identity,
               transform);
        FinishPosition = position;
    }

    private void SetCellHeight(int i, int j, int height = 1)
    {
        _cellPositions[i, j].Height = height;
        _cellPositions[i, j].transform.position += new Vector3(
                        0,
                        StairScale * _cellPositions[i, j].Height,
                        0);
    }

    private void ColorChesslike(int i, int j)
    {
        Color tileColor = _colorRandomizer.TileColor;
        if (i % 2 == j % 2)
        {
            Cells[i, j].GetComponent<MeshRenderer>().material.color =
                tileColor * 0.5f;
        }
    }

    private void UpdateSigns(int i, int j)
    {
        _cellPositions[i, j].SetSigns(_letters[i], _digits[j]);
        _cellPositions[i, j].HideSigns(
            i == 0,
            j == BoardSize - 1,
            i == BoardSize - 1,
            j == 0);
    }

    private void SpawnUnit(UnitSpawnData unitSpawnData)
    {
        int x = unitSpawnData.Position.X;
        int y = unitSpawnData.Position.Y;
        a_Unit newUnit = Instantiate(
            unitSpawnData.UnitData.Unit,
            this[x, y],
            Quaternion.identity,
            transform);

        newUnit.Position = new Position(x, y);
        newUnit.Rotation = new Rotation(unitSpawnData.Rotation.Angle);
        newUnit.transform.rotation = Quaternion.Euler(0, newUnit.Rotation.Angle, 0);

        Cells[x, y].Element = newUnit;
        UpdateOcuppiedCells(new Position(x, y));

        _unitPanel.AddUnit(newUnit, unitSpawnData);
    }

    public bool IsCellEmpty(Position position)
    {
        return _occupiedCells[position.X, position.Y];
    }

    public void UpdateOcuppiedCells(Position position)
    {
        _occupiedCells[position.X, position.Y] = !_occupiedCells[position.X, position.Y];
    }
}