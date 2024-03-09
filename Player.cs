using Godot;
using System;
using Godot.Collections;

public partial class Player : Node3D
{
    private bool _moving;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        var movementSpeed = TimeSpan.FromMilliseconds(300);

        if (Input.IsActionPressed("forward") && !_moving)
        {
            _moving = true;
            var tween = CreateTween();
            tween.TweenProperty(this, "position", Position + Vector3.Forward, movementSpeed.TotalSeconds);
            tween.TweenCallback(Callable.From(() => _moving = false));
            tween.Play();
        }

        if (Input.IsActionPressed("backward") && !_moving)
        {
            _moving = true;
            var tween = CreateTween();
            tween.TweenProperty(this, "position", Position + Vector3.Back, movementSpeed.TotalSeconds);
            tween.TweenCallback(Callable.From(() => _moving = false));
            tween.Play();
        }

        if (Input.IsActionPressed("left") && !_moving)
        {
            _moving = true;
            var tween = CreateTween();
            tween.TweenProperty(this, "position", Position + Vector3.Left, movementSpeed.TotalSeconds);
            tween.TweenCallback(Callable.From(() => _moving = false));
            tween.Play();
        }

        if (Input.IsActionPressed("right") && !_moving)
        {
            _moving = true;
            var tween = CreateTween();
            tween.TweenProperty(this, "position", Position + Vector3.Right, movementSpeed.TotalSeconds)
                .SetEase(Tween.EaseType.In)
                .SetTrans(Tween.TransitionType.Sine);
            
            tween.TweenCallback(Callable.From(() => _moving = false));
            tween.Play();
        }

    }
}