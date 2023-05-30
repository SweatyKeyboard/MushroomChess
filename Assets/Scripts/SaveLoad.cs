using UnityEngine;
using System.IO;

public static class SaveLoad
{
    public static void Save()
    {
        LevelSelector levelSelector = GameObject.FindAnyObjectByType<LevelSelector>();

        using (BinaryWriter bw = new BinaryWriter(File.Open("sav.dat", FileMode.OpenOrCreate)))
        {
            //Version of save
            bw.Write(1);

            //Completed levels
            bw.Write(levelSelector.CompletedLevels.Count);
            foreach (int level in levelSelector.CompletedLevels)
            {
                bw.Write(level);
            }

            //Completed faster levels
            bw.Write(levelSelector.CompletedFasterLevels.Count);
            foreach (int level in levelSelector.CompletedFasterLevels)
            {
                bw.Write(level);
            }
        }

        Debug.Log("Saved");
    }

    public static void Load()
    {

        if (!File.Exists("sav.dat"))
            return;

        LevelSelector levelSelector = GameObject.FindAnyObjectByType<LevelSelector>();

        using (BinaryReader br = new BinaryReader(File.Open("sav.dat", FileMode.Open)))
        {
            int saveVersion = br.ReadInt32();

            if (saveVersion == 1)
            {
                int completedLength = br.ReadInt32();
                for (int i = 0; i < completedLength; i++)
                {
                    levelSelector.CompleteLevel(br.ReadInt32());
                }

                int completedFasterLength = br.ReadInt32();
                for (int i = 0; i < completedFasterLength; i++)
                {
                    levelSelector.CompleteLevelFaster(br.ReadInt32());
                }
            }
        }

        Debug.Log("Loaded");

    }
}