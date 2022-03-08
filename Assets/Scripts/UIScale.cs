using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GridLayoutGroup))]
public class UIScale : MonoBehaviour
{
    private GridLayoutGroup _glg;

    [Header("Camera")]
    [SerializeField] private Camera _camera;
    private void Start()
    {
        float cellSize = _camera.pixelWidth / 9;
        float spacingX = cellSize / 3;

        _glg = this.GetComponent<GridLayoutGroup>();
        _glg.cellSize = new Vector2(cellSize, cellSize);
        _glg.spacing = new Vector2(spacingX, 10f);

        this.GetComponent<RectTransform>().sizeDelta = new Vector2 (0, cellSize + 40f);
    }
}
