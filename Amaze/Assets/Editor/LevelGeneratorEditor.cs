using Abstract.Enums;
using Sirenix.OdinInspector.Editor;
using UnityEditor;

namespace Concrete.Managers
{
    [CustomEditor(typeof(LevelGenerator))]
    public class LevelGeneratorEditor : OdinEditor
    {
        private LevelGenerator levelGenerator;

        protected override void OnEnable()
        {
            base.OnEnable();
            levelGenerator = (LevelGenerator)target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (levelGenerator != null && levelGenerator._cells != null)
            {
                EditorGUILayout.Space();

                EditorGUILayout.LabelField("Edit Cell Types:");

                int rowCount = levelGenerator._cells.GetLength(0);
                int colCount = levelGenerator._cells.GetLength(1);

                for (int x = 0; x < rowCount; x++)
                {
                    EditorGUILayout.BeginHorizontal();

                    for (int y = 0; y < colCount; y++)
                    {
                        EditorGUI.BeginChangeCheck();
                        CellType newType = (CellType)EditorGUILayout.EnumPopup(levelGenerator._cells[x, y].cellSettings.cellType);

                        if (EditorGUI.EndChangeCheck())
                        {
                            Undo.RecordObject(levelGenerator._cells[x, y], "Change Cell Type");
                            levelGenerator._cells[x, y].cellSettings.cellType = newType;
                        }
                    }

                    EditorGUILayout.EndHorizontal();
                }
            }
        }
    }
}