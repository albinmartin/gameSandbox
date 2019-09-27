using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace GameSandbox.Controls
{
    public class InputManager
    {
        private KeyboardState _previousKeyboardState;
        private KeyboardState _currentKeyboardState;
        private MouseState _previousMouseState;
        private MouseState _currentMouseState;
        private GamePadState[] _currentControllerState;
        private GamePadState[] _previousControllerState;
        private bool gamepadEnabled = false;

        public void Initialize()
        {
            _currentControllerState = new GamePadState[4];
            _previousControllerState = new GamePadState[4];
            _currentKeyboardState = Keyboard.GetState();
            _previousKeyboardState = _currentKeyboardState;
            _currentMouseState = Mouse.GetState();
            _previousMouseState = _currentMouseState;
        }

        public void Update()
        {
            _previousKeyboardState = _currentKeyboardState;
            _previousMouseState = _currentMouseState;
            _currentKeyboardState = Keyboard.GetState();
            _currentMouseState = Mouse.GetState();

            if (gamepadEnabled)
            {
                _currentControllerState[0] = GamePad.GetState(PlayerIndex.One);
                _currentControllerState[1] = GamePad.GetState(PlayerIndex.Two);
                _currentControllerState[2] = GamePad.GetState(PlayerIndex.Three);
                _currentControllerState[3] = GamePad.GetState(PlayerIndex.Four);
            }
        }

        public GamePadState GetGamePadState(PlayerIndex playerIndex)
        {
            if (playerIndex == PlayerIndex.One)
                return _previousControllerState[0];
            else if (playerIndex == PlayerIndex.Two)
                return _previousControllerState[1];
            else if (playerIndex == PlayerIndex.Three)
                return _previousControllerState[2];
            else
                return _previousControllerState[3];
        }

        /*
         * Mouse
         */
        public bool IsLeftMouseUp()
        {
            return Mouse.GetState().LeftButton == ButtonState.Released;
        }

        public bool IsRightMouseUp()
        {
            return Mouse.GetState().RightButton == ButtonState.Released;
        }

        public bool IsLeftMouseDown()
        {
            return Mouse.GetState().LeftButton == ButtonState.Pressed;
        }

        public bool IsRightMouseDown()
        {
            return Mouse.GetState().RightButton == ButtonState.Pressed;
        }

        public bool IsLeftMousePressed()
        {
            return IsLeftMouseDown() && (_previousMouseState.LeftButton == ButtonState.Released);
        }

        public bool IsRightMousePressed()
        {
            return IsRightMouseDown() && (_previousMouseState.RightButton == ButtonState.Released);
        }

        public bool IsLeftMouseReleased()
        {
            return !IsLeftMouseDown() && (_previousMouseState.LeftButton == ButtonState.Pressed);
        }

        public bool IsRightMouseReleased()
        {
            return !IsRightMouseDown() && (_previousMouseState.RightButton == ButtonState.Pressed);
        }

        public bool ScrolledUp()
        {
            return _previousMouseState.ScrollWheelValue - Mouse.GetState().ScrollWheelValue > 0;
        }

        public bool ScrolledDown()
        {
            return _previousMouseState.ScrollWheelValue - Mouse.GetState().ScrollWheelValue < 0;
        }

        public Vector2 GetMousePosition()
        {
            return new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
        }

        public  Vector2 GetRelativeMouse()
        {
            return GetMousePosition() - _previousMouseState.Position.ToVector2();
        }

        /*
         *  Keyboard
         */
        public bool IsKeyPressed(Keys key)
        {
            return Keyboard.GetState().IsKeyDown(key) && !_previousKeyboardState.IsKeyDown(key);
        }

        public bool IsKeyDown(Keys key)
        {
            return Keyboard.GetState().IsKeyDown(key) && _previousKeyboardState.IsKeyDown(key);
        }

        public bool IsKeyReleased(Keys key)
        {
            return !Keyboard.GetState().IsKeyDown(key) && _previousKeyboardState.IsKeyDown(key);
        }

        /*
         *  Gamepad
         */

        public bool IsButtonPressed(Buttons button, PlayerIndex playerIndex)
        {
            return GamePad.GetState(playerIndex).IsButtonDown(button) && !GetGamePadState(playerIndex).IsButtonDown(button);
        }

        public bool IsButtonDown(Buttons button, PlayerIndex playerIndex)
        {
            return GamePad.GetState(playerIndex).IsButtonDown(button) && GetGamePadState(playerIndex).IsButtonDown(button);
        }

        public bool IsButtonReleased(Buttons button, PlayerIndex playerIndex)
        {
            return !GamePad.GetState(playerIndex).IsButtonDown(button) && GetGamePadState(playerIndex).IsButtonDown(button);
        }

        public bool IsLeftAnalogueLeft(PlayerIndex playerIndex)
        {
            return GamePad.GetState(playerIndex).ThumbSticks.Left.X <= -0.5f &&
                   GetGamePadState(playerIndex).ThumbSticks.Left.X > -0.5f;
        }

        public bool IsLeftAnalogueRight(PlayerIndex playerIndex)
        {
            return GamePad.GetState(playerIndex).ThumbSticks.Left.X >= 0.5f &&
                   GetGamePadState(playerIndex).ThumbSticks.Left.X < 0.5f;
        }

        public bool IsLeftTriggerPressed(PlayerIndex playerIndex)
        {
            return GamePad.GetState(playerIndex).Triggers.Left <= 0.5f &&
                   GetGamePadState(playerIndex).Triggers.Left > 0.5f;
        }

        public bool IsRightTriggerPressed(PlayerIndex playerIndex)
        {
            return GamePad.GetState(playerIndex).Triggers.Right <= 0.5f &&
                   GetGamePadState(playerIndex).Triggers.Right > 0.5f;
        }
    }
}
