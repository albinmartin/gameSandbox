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
        GameServiceContainer _serviceContainer;
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
            /* - Populate services -
             * !CAREFUL! Don't add too many services to avoid hiding API
             * TODO: Watch how this works out
             */
            _serviceContainer = new GameServiceContainer();
            _serviceContainer.AddService<GraphicsDevice>(GraphicsDevice);
            _serviceContainer.AddService<SpriteBatch>(new SpriteBatch(GraphicsDevice));
            _serviceContainer.AddService<GameStateManager>(new GameStateManager(_serviceContainer));
            _serviceContainer.AddService<ContentManager>(Content);
            InputManager input = new InputManager();
            input.Initialize();
            _serviceContainer.AddService<InputManager>(input);

            /*
             * Create menu and world
             */
            GameStateManager stateManager = _serviceContainer.GetService<GameStateManager>();
            stateManager.CreateMainMenu();
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _serviceContainer.GetService<GameStateManager>().Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _serviceContainer.GetService<GameStateManager>().Draw(gameTime);
            base.Draw(gameTime);

        }

    }
}
