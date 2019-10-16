using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using GameSandbox.GameState;
using GameSandbox.Controls;
using Microsoft.Xna.Framework.Content;

namespace GameSandbox
{
    public class GameMain : Game
    {
        GameStateManager _stateManager;
        InputManager _input;
        GraphicsDeviceManager _graphicsDeviceManager;

        public GameMain()
        {
            _graphicsDeviceManager = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
            this.IsMouseVisible = true;
        }

        protected override void LoadContent()
        {
            /* 
             * Implement service provider?
             */

            _input = new InputManager();
            _input.Initialize();
            _stateManager = new GameStateManager(Content, _graphicsDeviceManager.GraphicsDevice, _input);

            /*
             * Create menu and world
             */
            _stateManager.CreateMainMenu();
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _stateManager.Update(gameTime);
            _input.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _stateManager.Draw(gameTime);
            base.Draw(gameTime);
        }

    }
}
