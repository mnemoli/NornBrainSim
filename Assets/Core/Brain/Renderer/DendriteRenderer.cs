using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DendriteRenderer
{

    static int CellSize = 10;
    static Material _lineMaterial;
    static Material LineMaterial
    {
        get
        {
            if(!_lineMaterial)
            {
                Shader shader = Shader.Find("Hidden/Internal-Colored");
                _lineMaterial = new Material(shader);
                return _lineMaterial;
            }
            else
            {
                return _lineMaterial;
            }
        }
    }

    public static void Render(Vector2Int sourceLocation, Vector2Int sourceDimension, int sourceNeuron, Vector2Int destLocation, Vector2Int destDimension, int destNeuron)
    {
        GL.PushMatrix();
        LineMaterial.SetPass(0);
        GL.LoadPixelMatrix();
        GL.Begin(GL.LINES);
        GL.Color(Color.black);
        var Start = GetNeuronPosition(sourceLocation, sourceDimension, sourceNeuron);
        var End = GetNeuronPosition(destLocation, destDimension, destNeuron);
        GL.Vertex3(Start.x, Start.y, 0);
        GL.Vertex3(End.x, End.y, 0);
        GL.End();
        GL.PopMatrix();

    }

    private static Vector2 GetNeuronPosition(Vector2Int location, Vector2Int dimension, int neuronIndex)
    {
        var x = (location.x + (neuronIndex % dimension.x)) * CellSize;
        var y = (location.y + (neuronIndex / dimension.x)) * CellSize;
        y = Screen.height - y;
        return new Vector2(x, y);
    }
}
