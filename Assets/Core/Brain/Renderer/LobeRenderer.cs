using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobeRenderer {

     static int CellSize = 10;

    public static void Render(Vector2Int location, Vector2Int dimension)
    {
        var GUIRect = new Rect(location * CellSize, dimension * CellSize);
        GUI.Box(GUIRect, "");
    }
}
