public class ObjectWithData
{
    public a_BoardObject Object { get; set; }
    public ObjectSpawnData SpawnData { get; set; }

    public ObjectWithData(a_BoardObject obj, ObjectSpawnData spawnData)
    {
        Object = obj;
        SpawnData = spawnData;
    }
}
