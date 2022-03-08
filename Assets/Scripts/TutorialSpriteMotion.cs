using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TutorialSpriteMotion : MonoBehaviour
{
    public enum Vertical
    {
        Up,
        Down
    }
    public Vertical noteVert;

    public enum Horizontal
    {
        Left,
        Right
    }
    public Horizontal noteHor;

    public enum Color
    {
        Blue,
        Yellow,
        Pink,
        Green,
        Red,
        Aquamarine
    }
    public Color noteColor;

    [Header("Objects")]
    [SerializeField] private GameObject note;
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject timer;
    [SerializeField] private bool useTimer;

    [Header("Colors")]
    [SerializeField] private Sprite[] colors;

    [Header("Speed")]
    [SerializeField] private float startSpeed;
    [SerializeField] private float speedMultiplier;
    private int completed;

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

    private void FixedUpdate()
    {
        SpriteMovment();
    }

    private void SpriteMovment()
    {
        float currentSpeed = startSpeed + (speedMultiplier * completed);
        
        if (TutorialGameButtonsScript._publMusicStatus == 0)
        {
            note.transform.position += new Vector3(currentSpeed, 0, 0);
        }
        else if (TutorialGameButtonsScript._publMusicStatus == 1)
        {
            note.transform.position += new Vector3(0, currentSpeed, 0);
        }

        if (note.transform.position.x >= topRight.x)
        {
            startSpeed *= -1;
            speedMultiplier *= -1;
            note.transform.position = new Vector3(note.transform.position.x - 0.05f, note.transform.position.y, note.transform.position.z);
        }
        if (note.transform.position.x <= topLeft.x)
        {
            startSpeed *= -1;
            speedMultiplier *= -1;
            note.transform.position = new Vector3(note.transform.position.x + 0.05f, note.transform.position.y, note.transform.position.z);
        }
        if (note.transform.position.y >= topRight.y)
        {
            startSpeed *= -1;
            speedMultiplier *= -1;
            note.transform.position = new Vector3(note.transform.position.x, note.transform.position.y - 0.05f, note.transform.position.z);
        }
        if (note.transform.position.y <= (bottomLeft.y + 1f))
        {
            startSpeed *= -1;
            speedMultiplier *= -1;
            note.transform.position = new Vector3(note.transform.position.x, note.transform.position.y + 0.05f, note.transform.position.z);
        }
    }

    private void SpawnNewNote(Collider2D other)
    {
        int rand = Random.Range(0, 3);
        other.gameObject.GetComponent<TutorialGoalScript>().SpawnNewGoal(rand);
        switch (rand)
        {
            case 0:
            {
                rand = Random.Range(0, 2);
                if (rand == 0)
                {
                    noteColor = Color.Blue;
                    note.GetComponent<SpriteRenderer>().sprite = colors[0];
                }
                else
                {
                    noteColor = Color.Yellow;
                    note.GetComponent<SpriteRenderer>().sprite = colors[1];
                }
                break;
            }
            case 1:
            {
                rand = Random.Range(0, 2);
                if (rand == 0)
                {
                    noteColor = Color.Pink;
                    note.GetComponent<SpriteRenderer>().sprite = colors[2];
                }
                else
                {
                    noteColor = Color.Green;
                    note.GetComponent<SpriteRenderer>().sprite = colors[3];
                }
                break;
            }

            case 2:
            {
                rand = Random.Range(0, 2);
                if (rand == 0)
                {
                    noteColor = Color.Red;
                    note.GetComponent<SpriteRenderer>().sprite = colors[4];
                }
                else
                {
                    noteColor = Color.Aquamarine;
                    note.GetComponent<SpriteRenderer>().sprite = colors[5];
                }
                break;
            }
        }
        note.transform.position = new Vector3(Random.Range(topLeft.x + 0.4f, topRight.x - 0.4f), Random.Range(bottomLeft.y + 1.7f, topLeft.y - 0.7f), 0); 
    }

    public void ChangeColor()
    {
        switch(noteColor)
        {
            case Color.Blue:
            {
                noteColor = Color.Yellow;
                note.GetComponent<SpriteRenderer>().sprite = colors[1];
                break;
            }

            case Color.Yellow:
            {
                noteColor = Color.Blue;
                note.GetComponent<SpriteRenderer>().sprite = colors[0];
                break;
            }

            case Color.Pink:
            {
                noteColor = Color.Green;
                note.GetComponent<SpriteRenderer>().sprite = colors[3];
                break;
            }

            case Color.Green:
            {
                noteColor = Color.Pink;
                note.GetComponent<SpriteRenderer>().sprite = colors[2];
                break;
            }

            case Color.Red:
            {
                noteColor = Color.Aquamarine;
                note.GetComponent<SpriteRenderer>().sprite = colors[5];
                break;
            }

            case Color.Aquamarine:
            {
                noteColor = Color.Red;
                note.GetComponent<SpriteRenderer>().sprite = colors[4];
                break;
            }
        }
    }

    public void FlipVertical()
    {
        note.transform.localScale = new Vector3(note.transform.localScale.x, note.transform.localScale.y * -1, note.transform.localScale.z);
        if (noteVert == Vertical.Up)
            noteVert = Vertical.Down;
        else
            noteVert = Vertical.Up;
    }

    public void FlipHorizontal()
    {
        note.transform.localScale = new Vector3(note.transform.localScale.x * -1, note.transform.localScale.y, note.transform.localScale.z);
        if (noteHor == Horizontal.Left)
            noteHor = Horizontal.Right;
        else
            noteHor = Horizontal.Left;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        int targetVert = (int)other.gameObject.GetComponent<TutorialGoalScript>().targetVert;
        int tarhetHor = (int)other.gameObject.GetComponent<TutorialGoalScript>().targetHor;
        int targetColor = (int)other.gameObject.GetComponent<TutorialGoalScript>().targetColor;

        if (targetVert == (int)noteVert && tarhetHor == (int)noteHor && targetColor == (int)noteColor)
        {
            completed += 1;
            SpawnNewNote(other);

            if (useTimer)
            {
                timer.GetComponent<Timer>().AddTime();
                timer.GetComponent<GameController>().AddScore();
            }
        }
    }
}