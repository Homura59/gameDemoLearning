using Godot;
using System;

public partial class GameManager : Node
{
    private Label scoreLabel;
    public override void _Ready()
    {
        scoreLabel = GetNode<Label>("scoreLabel");
    }


    int score = 0;


    public void AddScore()
    {
        score += 1;
        scoreLabel.Text = "You Collected " + score.ToString() + " Coins.";
    }
}