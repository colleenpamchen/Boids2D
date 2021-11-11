using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Flock/Behavior/Composite")]
public class CompositeBehavior : FlockBehavior
{
    public FlockBehavior[] behaviors;

    [Range(0f, 10f)]
    public float[] weights;

    [SerializeField]
    changeWeights m_changeWeights; 

    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        // handle data mismatch 
        if (weights.Length != behaviors.Length)
        {
            Debug.LogError("Data mismatch in " + name, this);
            return Vector2.zero; 
        }
        // set up move
        Vector2 move = Vector2.zero;

        //iterate through behaviors 
        for (int i = 0; i < behaviors.Length; i++)
        {
            Vector2 partialMove = behaviors[i].CalculateMove(agent, context, flock) * weights[i];
            if (partialMove != Vector2.zero)
            {
                if (partialMove.sqrMagnitude > weights[i] * weights[i])
                {
                    partialMove.Normalize();
                    partialMove *= weights[i];
                }
                move += partialMove;
            }
        }
        return move; 
       
    }

    void Start()
    {
        m_changeWeights = GameObject.Find("Flock").GetComponent<changeWeights>();
    }

void Update()
    {
        weights[0] = m_changeWeights.getCohesionWeights();
        Debug.Log(weights[0]);
        m_changeWeights.changeCohesionWeights(weights[0]);

        weights[2] = m_changeWeights.getAlignmentWeights();
        Debug.Log(weights[2]);
        m_changeWeights.changeAlignmentWeights(weights[2]);

        weights[1] = m_changeWeights.getSeparationWeights();
        Debug.Log(weights[1]);
        m_changeWeights.changeSeparationWeights(weights[1]);
    }



}

