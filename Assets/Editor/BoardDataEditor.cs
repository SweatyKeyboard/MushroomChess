using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BoardData))]
[CanEditMultipleObjects]
public class BoardDataEditor : Editor
{
    private BoardData _data;
    private SerializedProperty _boardSizeProperty;
    private SerializedProperty _heightMapPropperty;
    private SerializedProperty _unitsPropperty;

    private int _boardSize;

    private bool _isHeightMapShown;
    private bool _isUnitsListShown;
    private List<bool> _isUnitShown = new List<bool>();

    private int _fillHeightsWithValue = 1;

    private void OnEnable()
    {
        _boardSizeProperty = serializedObject.FindProperty("BoardSize");
        _heightMapPropperty = serializedObject.FindProperty("HeightMap");
        _unitsPropperty = serializedObject.FindProperty("Units");

        // _unitsPropperty = serializedObject.FindProperty("Units");

        /*_data = (BoardData)target;

        while (_isUnitShown.Count < _data.Units.Count)
        {
            _isUnitShown.Add(false);
        }*/
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(_boardSizeProperty);
        _heightMapPropperty.arraySize = _boardSizeProperty.intValue * _boardSizeProperty.intValue;



        _isHeightMapShown = EditorGUILayout.BeginFoldoutHeaderGroup(_isHeightMapShown, "Height map");
        if (_isHeightMapShown)
        {
            for (int i = 0; i < _boardSizeProperty.intValue; i++)
            {
                EditorGUILayout.BeginHorizontal();
                for (int j = 0; j < _boardSizeProperty.intValue; j++)
                {
                    EditorGUILayout.PropertyField(_heightMapPropperty.GetArrayElementAtIndex(i + j * _boardSizeProperty.intValue), new GUIContent());
                }
                EditorGUILayout.EndHorizontal();
            }
        }
        EditorGUILayout.EndFoldoutHeaderGroup();


                EditorGUILayout.PropertyField(_unitsPropperty);
                
                /*for (int i = 0; i < _unitsPropperty.arraySize; i++)
                {
                    EditorGUILayout.BeginVertical("box");

                    EditorGUILayout.PropertyField(_unitsPropperty.GetArrayElementAtIndex(i).FindPropertyRelative("UnitData"));

                    //((UnitSpawnData)()
                    //    .UnitData = (UnitData)EditorGUILayout.ObjectField("Unit", unit.UnitData, typeof(UnitData), false);


                    /*EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField("Position");
                    unit.Position = new Position(
                        EditorGUILayout.IntField(unit.Position?.X ?? 0),
                        EditorGUILayout.IntField(unit.Position?.Y ?? 0));
                    EditorGUILayout.EndHorizontal();

                    // unit.Rotation = new Rotation(
                    //     (Direction)EditorGUILayout.EnumPopup("Rotation", unit.Rotation?.DirectedAngle ?? 0));

                    EditorGUILayout.LabelField("Moves / Jumps / Rotates / Specials");
                    EditorGUILayout.BeginHorizontal();
                    unit.MoveAcionsCount = EditorGUILayout.IntField(unit.MoveAcionsCount);
                    unit.JumpAcionsCount = EditorGUILayout.IntField(unit.JumpAcionsCount);
                    unit.RotateAcionsCount = EditorGUILayout.IntField(unit.RotateAcionsCount);
                    unit.SpecialAcionsCount = EditorGUILayout.IntField(unit.SpecialAcionsCount);
                    EditorGUILayout.EndHorizontal();
                    if (GUILayout.Button("Remove"))
                    {
                        _data.Units.Remove(unit);
                        break;
                    }
                    EditorGUILayout.EndVertical();
                }
                EditorGUILayout.EndFoldoutHeaderGroup();

                counter++;
            }
            else
            {
                EditorGUILayout.LabelField("There are no units yet");
            }
            #endregion
*/
                   /* if (GUILayout.Button("Add unit"))
                    {
                        _data.Units.Add(new UnitSpawnData());
                        _isUnitShown.Add(true);
                    }
               }*/
            

        serializedObject.ApplyModifiedProperties();




        /* if (GUI.changed)
         {
             MakeDirty(_data);
         }*/
    }

    private void MakeDirty(ScriptableObject obj)
    {
        Undo.RecordObject(obj, "Changed");
        EditorUtility.SetDirty(obj);
    }
}