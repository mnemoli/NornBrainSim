using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobeRenderer {

     static int CellSize = 10;

    public static void Render(Vector2Int location, Vector2Int dimension, Type enumType, int enumValue)
    {
        var GUIRect = new Rect(location * CellSize, dimension * CellSize);
        if (enumType != null)
        {
            var LabelRect = new Rect(GUIRect.position + new Vector2(50, 0), new Vector2(200, 50));
            GUI.Label(LabelRect, new GUIContent(Enum.GetName(enumType, enumValue)));
        }
        GUI.Box(GUIRect, "");
        
    }
}
