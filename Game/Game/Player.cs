using SFML.Graphics;
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

            bounds = new BoundingBox(10, 10);

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
            }
            
            // Player movement
            if (Input.GetKey(Keyboard.Key.Z))
                Position = new Vector2f(0, Mathf.Clamp(Position.Y + -1 * playerSpeed * Time.deltaTime, 0, GameCore.window.Size.Y));
            else if (Input.GetKey(Keyboard.Key.S) && Position.Y < GameCore.window.Size.Y)
                Position = new Vector2f(0, Mathf.Clamp(Position.Y + 1 * playerSpeed * Time.deltaTime, 0, GameCore.window.Size.Y));
            if (Input.GetKey(Keyboard.Key.Q) && Position.X > 1)
                Position = new Vector2f(Mathf.Clamp(Position.Y + -1 * playerSpeed * Time.deltaTime, 0, GameCore.window.Size.X), 0);
            else if (Input.GetKey(Keyboard.Key.D) && Position.X < GameCore.window.Size.X)
                Position = new Vector2f(Mathf.Clamp(Position.Y + 1 * playerSpeed * Time.deltaTime, 0, GameCore.window.Size.X), 0);
            Debug.WriteLine(Position);
            // Player fire
            if (Input.GetKeyDown(Keyboard.Key.Space))
                Shoot();
        }

        private void Shoot()
        {
            Bullet b = new Bullet();
            b.startPos = Position;
            b.isPlayerOwned = true;
            b.bulletDamage = playerDamage;
            b.Launch();
        }

        public void Kill()
        {
            // todo
        }
    }
}