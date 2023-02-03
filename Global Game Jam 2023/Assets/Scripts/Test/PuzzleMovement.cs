using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleMovement : MonoBehaviour
{
    [SerializeField] private GameObject m_Puzzle;
    [SerializeField] private Transform m_PuzzleHidden;
    [SerializeField] private Transform m_PuzzleRevealed;
    [SerializeField] private bool m_ShowPuzzle;

    [SerializeField] private float m_MovementSpeed;
    private float m_MovementSpeedMultiplier;

    public void Start()
    {
        m_MovementSpeedMultiplier = 100;
        m_Puzzle.transform.position = m_PuzzleHidden.position;
    }

    public void Update()
    {
        if (m_ShowPuzzle)
        {
            PuzzleAppear();
        }
        else if(m_ShowPuzzle == false)
        {
            PuzzleDisappear();
        }
    }

    public void PuzzleAppear()
    {
        m_Puzzle.transform.position = Vector3.MoveTowards(m_Puzzle.transform.position, m_PuzzleRevealed.position, m_MovementSpeed * m_MovementSpeedMultiplier * Time.deltaTime);
    }

    public void PuzzleDisappear()
    {
        m_Puzzle.transform.position = Vector3.MoveTowards(m_Puzzle.transform.position, m_PuzzleHidden.position, m_MovementSpeed * m_MovementSpeedMultiplier * Time.deltaTime);
    }

}
