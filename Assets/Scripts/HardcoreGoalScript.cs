using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardcoreGoalScript : MonoBehaviour
{
    public enum Vertical
    {
        Up,
        Down
    }
    public Vertical targetVert;

    public enum Horizontal
    {
        Left,
        Right
    }
    public Horizontal targetHor;

    public enum Color
    {
        Blue,
        Green,
        Red
    }
    public Color targetColor;

    [Header("Objects")]
    [SerializeField] private GameObject target;
    [SerializeField] private int targetNumber;
    [SerializeField] private GameObject targetNoteSprite;
    [SerializeField] private GameObject goal1;
    [SerializeField] private GameObject goal2;
    [SerializeField] private GameObject goal3;

    [Header("Colors")]
    [SerializeField] private Sprite[] colors;

    [Header("Camera")]
    [SerializeField] private Camera _camera;
    private Vector2 bottomLeft;
    private Vector2 bottomRight;
    private Vector2 topLeft;
    private Vector2 topRight;

    private void Start()
    {
        bottomLeft = _camera.ScreenToWorldPoint(new Vector2 (0, 0));
        bottomRight = _camera.ScreenToWorldPoint(new Vector2 (_camera.pixelWidth, 0));
        topLeft = _camera.ScreenToWorldPoint(new Vector2 (0, _camera.pixelHeight));
        topRight = _camera.ScreenToWorldPoint(new Vector2 (_camera.pixelWidth, _camera.pixelHeight));
    }

    public void LightTarget()
    {
        StartCoroutine(LightTargetCoroutine());
    }

    public void SpawnNewGoal(int noteColor, bool firstSpawn)
    {
        Vector3 newTargetPos = new Vector3(Random.Range(topLeft.x + 0.4f, topRight.x - 0.4f), Random.Range(bottomLeft.y + 1.7f, topLeft.y - 1.5f), 0);
        
        if (firstSpawn != true)
        {   
            if (targetNumber == 1)
                while (Vector3.Distance(newTargetPos, goal2.transform.position) <= 1f || Vector3.Distance(newTargetPos, goal3.transform.position) <= 1f)
                {
                    newTargetPos = new Vector3(Random.Range(topLeft.x + 0.4f, topRight.x - 0.4f), Random.Range(bottomLeft.y + 1.7f, topLeft.y - 1.5f), 0);
                }

            if (targetNumber == 2)
                while (Vector3.Distance(newTargetPos, goal1.transform.position) <= 1f || Vector3.Distance(newTargetPos, goal3.transform.position) <= 1f)
                {
                    newTargetPos = new Vector3(Random.Range(topLeft.x + 0.4f, topRight.x - 0.4f), Random.Range(bottomLeft.y + 1.7f, topLeft.y - 1.5f), 0);
                }

            if (targetNumber == 3)
                while (Vector3.Distance(newTargetPos, goal1.transform.position) <= 1f || Vector3.Distance(newTargetPos, goal2.transform.position) <= 1f)
                {
                    newTargetPos = new Vector3(Random.Range(topLeft.x + 0.4f, topRight.x - 0.4f), Random.Range(bottomLeft.y + 1.7f, topLeft.y - 1.5f), 0);
                }
        }
        
        int rand = Random.Range(0, 2);
        if (rand == 0)
        {
            targetVert = Vertical.Up;
            target.transform.localScale = new Vector3(target.transform.localScale.x, 0.04f, target.transform.localScale.z);
        }
        else
        {
            targetVert = Vertical.Down;
            target.transform.localScale = new Vector3(target.transform.localScale.x, -0.04f, target.transform.localScale.z);
        }

        rand = Random.Range(0, 2);
        if (rand == 0)
        {
            targetHor = Horizontal.Left;
            target.transform.localScale = new Vector3(0.04f, target.transform.localScale.y, target.transform.localScale.z);
        }
        else
        {
            targetHor = Horizontal.Right;
            target.transform.localScale = new Vector3(-0.04f, target.transform.localScale.y, target.transform.localScale.z);
        }

        switch (noteColor)
        {
            case 0:
            {
                targetColor = Color.Blue;
                targetNoteSprite.GetComponent<SpriteRenderer>().sprite = colors[0];
                break;
            }
            case 1:
            {
                targetColor = Color.Green;
                targetNoteSprite.GetComponent<SpriteRenderer>().sprite = colors[1];
                break;
            }

            case 2:
            {
                targetColor = Color.Red;
                targetNoteSprite.GetComponent<SpriteRenderer>().sprite = colors[2];
                break;
            }
        }
        target.transform.position = newTargetPos;
    }

    private IEnumerator LightTargetCoroutine()
    {
        targetNoteSprite.SetActive(true);
        yield return new WaitForSeconds(2f);
        targetNoteSprite.SetActive(false);
    }
}
