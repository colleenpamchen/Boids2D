using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeWeights : MonoBehaviour
{
    [SerializeField]
    FlockBehavior m_flockBehavior;
    CompositeBehavior m_compositeBehavior;

    public float m_cohesionWeight;
    public float m_alignmentWeight;
    public float m_separationWeight;

    private void Start()
    {
        m_flockBehavior = GameObject.Find("Flock").GetComponent<FlockBehavior>();
        m_compositeBehavior = GameObject.Find("Flock").GetComponent<CompositeBehavior>();


    }


    public void changeCohesionWeights(float weight)
    {
        m_cohesionWeight = weight;
        m_compositeBehavior.weights[0] = m_cohesionWeight;
    }
    public void changeAlignmentWeights(float weight)
    {
        m_alignmentWeight = weight;
        m_compositeBehavior.weights[2] = m_alignmentWeight; 
    }
    public void changeSeparationWeights(float weight)
    {
        m_separationWeight = weight;
        m_compositeBehavior.weights[1] = m_separationWeight;
    }
    

    public float getCohesionWeights()
    {
        return m_cohesionWeight;
    }
    public float getAlignmentWeights()
    {
        return m_alignmentWeight;
    }
    public float getSeparationWeights()
    {
        return m_separationWeight;
    }


}
