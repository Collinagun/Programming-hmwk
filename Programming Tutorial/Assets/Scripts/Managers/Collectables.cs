using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    public string nameCollect;
    public int scoreCollect;
    public int healthUp;

    public Collectables(string name, int scoreValue, int restoreHP)
    {
        this.nameCollect = name;
        this.scoreCollect = scoreValue;
        this.healthUp = restoreHP;

    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Player"){
            Debug.Log("Collided");
            Destroy(gameObject);
        }
    }

    // Manages health
    public void UpdateHealth()
    {

    }

    // Manages score
    public void UpdateScore()
    {
        ScoreManager.scoreManager.UpdateScore(scoreCollect);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
