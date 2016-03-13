﻿using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Diagnostics;

namespace Game
{
    public class Player : GameObject
    {
        public const uint PLAYER_BASE_SPEED = 125;
        public const float PLAYER_BASE_DAMAGE = 20;
        public uint playerSpeed = 150;
        public float playerDamage = 30f;

        public uint focusSpeedBonus = 65;
        public float focusDamageBonus = 10f;

        public bool playerFocus;
        public override void Start()
        {
            RectangleShape r = new RectangleShape(new Vector2f(10, 10));
            r.FillColor = Color.Red;
            drawable = r;

            Position = new Vector2f(10, 10);
        }

        private bool focusDeduced = false;
        public override void Update()
        {
            // Focus mecanism
            if (Input.GetKey(Keyboard.Key.LShift) || Input.GetKey(Keyboard.Key.RShift))
                playerFocus = true;
            else
                playerFocus = false;

            if (playerFocus && !focusDeduced)
            {
                playerSpeed -= focusSpeedBonus;
                playerDamage += focusDamageBonus;
                focusDeduced = true;
            }
            else
            {
                playerSpeed = PLAYER_BASE_SPEED;
                playerDamage = PLAYER_BASE_DAMAGE;
                focusDeduced = false;
                Debug.WriteLine("");
            }

            Vector2f lastPos = Position;

            // Player movement
            if (Input.GetKey(Keyboard.Key.Z))
                Position += new Vector2f(0, -1 * playerSpeed * Time.deltaTime);
            else if (Input.GetKey(Keyboard.Key.S))
                Position += new Vector2f(0, 1 * playerSpeed * Time.deltaTime);
            if (Input.GetKey(Keyboard.Key.Q))
                Position += new Vector2f(-1 * playerSpeed * Time.deltaTime, 0);
            else if (Input.GetKey(Keyboard.Key.D))
                Position += new Vector2f(1 * playerSpeed * Time.deltaTime, 0);

            // Player fire
            if (Input.GetKeyDown(Keyboard.Key.Space))
                Shoot((Position - lastPos) / Time.deltaTime);
                

            Debug.WriteLine(Position);
        }

        private void Shoot(Vector2f inheritVelocity)
        {
            Bullet b = new Bullet();
            b.startPos = Position;
            b.isPlayerOwned = true;
            b.bulletDamage = playerDamage;
            b.inheritVelocity = inheritVelocity;
            b.Launch();
        }

        public void Kill()
        {
            // todo
        }
    }
}