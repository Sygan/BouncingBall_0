using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class BallController : MonoBehaviour
{
    public Rigidbody rigidbody;
    public float bounceForce;
    private int points = 0;
    public string sceneName;

    public GameObject LosePanel;
    public TextMeshProUGUI pointsTextField;

    private int pointsAmount = 0;
    public float randomHorizontalForce = 0.1f;

    public Animator animator;

    public float Idle_Speed;
    
    private void Start()
    {
        pointsTextField.text = pointsAmount.ToString();
        LosePanel.SetActive(false);
    }

    private void Update()
    {
        animator.SetFloat("Idle_Speed", Idle_Speed);
        
        if(transform.position.y < -6)
            LosePanel.SetActive(true);
    }

    private void OnCollisionEnter(Collision other)
    {
        if(!other.collider.CompareTag("Player"))
            return;

        var randomForce = Random.Range(-randomHorizontalForce, randomHorizontalForce);
        
        rigidbody.AddForce(new Vector3(randomForce, bounceForce, 0), ForceMode.Impulse);

        pointsAmount++;

        pointsTextField.text = pointsAmount.ToString();
        
        animator.Play("Bounce");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(sceneName);
    }
}
