using Godot;
using System;

public partial class Killzone : Area2D
{
    private Timer timer;

    public override void _Ready()
    {
        timer = GetNode<Timer>("Timer");

    }

    public void on_body_entered(Node body)
    {
        GD.Print("you died");
        Engine.TimeScale = 0.5;
        body.GetNode("CollisionShape2D").QueueFree();
        timer.Start();
    }

    public void on_timeout()
    {
        Engine.TimeScale = 1;
        GetTree().ReloadCurrentScene();
    }

}
