using Abstract.Enums;

using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEngine;
namespace Concrete.Managers
{
        

        [OdinDrawer]
        public class CellTypeDrawer : OdinValueDrawer<CellType>
        {
            protected override void DrawPropertyLayout(GUIContent label)
            {
                EditorGUI.BeginChangeCheck();
                var value = this.ValueEntry.SmartValue;

                // CellType özelliğini enum popup olarak göster.
                value = (CellType) EditorGUILayout.EnumPopup(label, value);

                if (EditorGUI.EndChangeCheck())
                {
                    this.ValueEntry.SmartValue = value;
                }

                // CellType'a göre rengi ayarla.
                if (value == CellType.Obstacle)
                {
                    GUI.backgroundColor = Color.red;
                }
                else
                {
                    GUI.backgroundColor = Color.green;
                }

                // Rengi sadece bu arayüzde değil, tüm arayüzde kullanmak istemiyorsak renk ayarını tekrar eski hâline getirelim.
                GUI.backgroundColor = Color.white;
            }
        }
    
}