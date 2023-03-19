using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] private BoardData _data;

    [SerializeField] private BoardCell _cellPrefab;
    [SerializeField] private Transform _wallPrefab;
    [SerializeField] private Spawner _spawnPrefab;

    [SerializeField] private SingnsList _digits;
    [SerializeField] private SingnsList _letters;

    [SerializeField] private int _boardSize = 5;

    private BoardCell[,] _cellPositions;
    private bool[,] _occupiedCells;

    private float _scale = 1f;
    public float StairScale = 0.1f;

    private ColorRandomizer _colorRandomizer;
    [SerializeField] private UnitPanel _unitPanel;
    public BoardCell[,] Cells => _cellPositions;
    public int BoardSize => _boardSize;
    public static Board Instance;
    public Vector3 this[int i, int j] => new Vector3(
        _cellPositions[i, j].transform.position.x,
        _cellPositions[i, j].transform.position.y + _scale * transform.localScale.y,
        _cellPositions[i, j].transform.position.z);

    private void Awake()
    {
        Instance = this;
        _cellPositions = new BoardCell[_boardSize, _boardSize];
        _occupiedCells = new bool[_boardSize, _boardSize];

        _colorRandomizer = FindObjectOfType<ColorRandomizer>();
        _colorRandomizer.RandomizeColor();

        CreateFromFileData(_data);        
    }

    private void CreateFromFileData(BoardData data)
    {
        _boardSize = _data.BoardSize;
        for (int i = 0; i < _boardSize; i++)
        {
            for (int j = 0; j < _boardSize; j++)
            {
                CreateCell(i, j);
                SetCellHeight(i, j, _data.HeightMap[i + j * _data.BoardSize]);
                ColorChesslike(i, j);
                UpdateSigns(i, j);
            }
        }

        foreach (UnitSpawnData unitSpawnData in data.Units)
        {
            SpawnUnit(unitSpawnData);
        }

        transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
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

    private void CreateWall(int i, int j, int angle = 0)
    {
        Transform wall = Instantiate(
                            _wallPrefab,
                           this[i, j],
                            Quaternion.Euler(0, angle, 0),
                            transform);
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
        newUnit.transform.rotation = Quaternion.Euler(0,newUnit.Rotation.Angle, 0);

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