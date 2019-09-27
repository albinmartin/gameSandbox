using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using GameSandbox.Controls;


namespace GameSandbox.GameState
{
    public class GameStateManager
    {
        private GameServiceContainer _serviceContainer;
        private Stack<GameState> _gameStates;
        private GameState _currentState;

        public GameState CurrentState { get => _currentState; }

        public GameStateManager(GameServiceContainer serviceContainer)
        {
            _serviceContainer = serviceContainer;
            _gameStates = new Stack<GameState>();
            _currentState = null;
        }

        private void PushState(GameState gameState)
        {
            _gameStates.Push(gameState);
            _currentState = gameState;
            _currentState.LoadContent();

        }

        private void PopState()
        {
            if (_gameStates.Count > 0)
            {
                GameState gameState = _gameStates.Pop();
                gameState.UnloadContent();
                _currentState = _gameStates.Peek();
            }
        }

        public void Update(GameTime gameTime)
        {
            _gameStates.Peek().Update(gameTime);
        }

        public void Draw(GameTime gameTime)
        {
            _gameStates.Peek().Draw(gameTime);
        }

        public void CreateMainMenu()
        {
            GameState menu = new MainMenu(_serviceContainer.GetService<GraphicsDevice>(), _serviceContainer.GetService<ContentManager>(), this, _serviceContainer.GetService<InputManager>());
            PushState(menu);
        }

        public void CreateHubWorld()
        {
            GameState worldState = new WorldState(this, _serviceContainer.GetService<ContentManager>(), _serviceContainer.GetService<GraphicsDevice>());
            PushState(worldState);
        }

        public void CreateDungeon()
        {

        }

    }
}
