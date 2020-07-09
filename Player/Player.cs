using Godot;
using System;
using ActionRPG.Core.Components;
using ActionRPG.Core.Items;
using ActionRPG.Core.StateMachine;
using ActionRPG.States;
using Godot.Collections;

namespace ActionRPG
{
    public class Player : KinematicBody2D
    {
        [Export] public int Speed = 80;

        // Node Components
        private AnimationTree _animationTree = null;
        private AnimationNodeStateMachinePlayback _animationNodeStateMachinePlayback = null;
        private Position2D _hitBoxPosition;

        // State handlers
        private StateMachine<Player> _stateMachine;

        // Data Components
        public readonly MovementComponent MovementComponent = new MovementComponent();
        public readonly DamageComponent DamageComponent = new DamageComponent();


        public override void _Ready()
        {
            base._Ready();
            // Initialize and mount the state machine.
            this._stateMachine = new StateMachine<Player>(this, StatesIndex.Idle);
            this._stateMachine
                .AddState(new PlayerAttackState())
                .AddState(new PlayerMovingState())
                .AddState(new PlayerIdleState());


            this._hitBoxPosition = GetNode<Position2D>("./HitBox");
            this.EquipWeapon();
            // Get Animation components (nodos). 
            this._animationTree = GetNode<AnimationTree>("./AnimationTree");
            this._animationTree.Active = true;
            this._animationNodeStateMachinePlayback =
                (AnimationNodeStateMachinePlayback) this._animationTree.Get("parameters/playback");
        }

        public override void _PhysicsProcess(float delta)
        {
            // Move and update the velocity after collision.
            MovementComponent.Velocity = MoveAndSlide(MovementComponent.Velocity);

            var v = MovementComponent.Velocity;
            if (v == Vector2.Zero) return;
            UpdateHitBox(v);
        }


        public override void _Process(float delta)
        {
            // Get and handle user inputs.
            GetInput();

            // Update the player state machine
            this._stateMachine.Update(delta);


            // play animations according to components data
            PlayAnimations();
        }

        private void GetInput()
        {
            MovementComponent component = this.MovementComponent;
            if (this.MovementComponent != null)
            {
                // get movement inputs
                this.MovementComponent.ItsMovingRight = Input.IsActionPressed("ui_right");
                this.MovementComponent.ItsMovingLeft = Input.IsActionPressed("ui_left");
                this.MovementComponent.ItsMovingBackward = Input.IsActionPressed("ui_down");
                this.MovementComponent.ItsMovingForward = Input.IsActionPressed("ui_up");
            }


            this.DamageComponent.ItsAttacking = Input.IsActionPressed("attack");
        }

        private void PlayAnimations()
        {
            if (this.MovementComponent.Velocity != Vector2.Zero)
            {
                _animationTree.Set("parameters/Idle/blend_position", MovementComponent.Velocity);
                _animationTree.Set("parameters/Run/blend_position", MovementComponent.Velocity);
                _animationTree.Set("parameters/Attack1/blend_position", MovementComponent.Velocity);
            }

            switch (this._stateMachine.CurrentState?.Code)
            {
                case StatesIndex.Attack:
                    _animationNodeStateMachinePlayback.Travel("Attack1");
                    break;
                case StatesIndex.Idle:
                    _animationNodeStateMachinePlayback.Travel("Idle");
                    break;
                case StatesIndex.MoveForward:
                    _animationNodeStateMachinePlayback.Travel("Run");
                    break;
                default:
                    _animationNodeStateMachinePlayback.Travel("Idle");
                    break;
            }
        }

        private void UpdateHitBox(Vector2 v)
        {
            if (v.x > 0)
            {
                this._hitBoxPosition.RotationDegrees = 180f;
            }
            else if (v.x < 0)
            {
                this._hitBoxPosition.RotationDegrees = 0f;
            }
            else if (v.y > 0)
            {
                this._hitBoxPosition.RotationDegrees = 270f;
            }
            else
            {
                this._hitBoxPosition.RotationDegrees = 90f;
            }
        }

        // TODO move to the hitbox it self.
        public void DisabledHitBox()
        {
            var area = this._hitBoxPosition.GetChild<Area2D>(0);
            var collider = area.GetChild<CollisionShape2D>(0);
            collider.Disabled = true;
        }

        public void EquipWeapon()
        {
            var hitBox = this._hitBoxPosition.GetChild<HitBox>(0);
            hitBox.Weapon = new Sword(5, 10);
        }
    }
}