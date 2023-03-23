using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BoardData))]
[CanEditMultipleObjects]
public class BoardDataEditor : Editor
{
    private SerializedProperty _boardSizeProperty;
    private SerializedProperty _heightMapPropperty;
    private SerializedProperty _unitsPropperty;
    private SerializedProperty _finishPosPropperty;

    private bool _isHeightMapShown;


    private void OnEnable()
    {
        _boardSizeProperty = serializedObject.FindProperty("BoardSize");
        _heightMapPropperty = serializedObject.FindProperty("HeightMap");
        _unitsPropperty = serializedObject.FindProperty("Units");
        _finishPosPropperty = serializedObject.FindProperty("FinishPosition");
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
        EditorGUILayout.PropertyField(_finishPosPropperty);



        EditorGUILayout.PropertyField(_unitsPropperty);



        serializedObject.ApplyModifiedProperties();

    }
}