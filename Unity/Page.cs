﻿using System.ComponentModel;
using System.Drawing;
using Unity.Command;
using Unity.ShapeModelState;

namespace Unity
{
    enum ModelState
    {
        DRAWING,
        POINT
    }
    public class Page
    {
        public event ModelChangedEventHandler _modelChanged;
        public delegate void ModelChangedEventHandler();
        public event CommandManagerHandler _commandManagerChanges;
        public delegate void CommandManagerHandler(bool undo, bool redo);
        private BindingList<Shape> pages = new BindingList<Shape> { };
        private PointState _pointState = new PointState();
        private IState _state = new DrawingState();
        bool _isPressed;
        private const int CANVAS_MAX = 400;
        private CommandManager _commandManager = new CommandManager();
        Point _nowCanvas = new Point(1, 1);


        public BindingList<Shape> shapeList
        {
            get
            {
                return pages;
            }
        }
        #region state
        /// <summary>
        /// switch
        /// </summary>
        public virtual void SwitchStateDrawing()
        {
            _pointState = new PointState();
            _state = new DrawingState();
            NotifyModelChanged();
        }

        /// <summary>
        /// switch
        /// </summary>
        public virtual void SwitchStatePoint()
        {
            _state = _pointState;
        }

        /// <summary>
        /// set
        /// </summary>
        public virtual bool IsScale()
        {
            return _state.IsScale(pages);
        }

        /// <summary>
        /// a
        /// </summary>
        public void Resize(Point point)
        {
            _nowCanvas = point;
            foreach (var shape in pages)
            {
                shape.SetNowCanvasSize(point);
            }
        }
        #endregion

        #region draw
        /// <summary>
        /// draw
        /// </summary>
        /// <param name="graphics"></param>
        public virtual void Draw(IGraphics graphics)
        {
            foreach (Shape shape in pages)
            {
                shape.Draw(graphics);
            }
            _state.Draw(graphics, pages);
        }
        #endregion

        #region subscribe
        /// <summary>
        /// attach
        /// </summary>
        /// <param name="shapeObserver"></param>
        public void AttachCommandManager(Form1 model)
        {
            _commandManagerChanges += model.HandleUndoButtonState;
        }

        /// <summary>
        /// attach
        /// </summary>
        /// <param name="shapeObserver"></param>
        public void Attach(IShapeObserver shapeObserver)
        {
            _modelChanged += shapeObserver.ReceiveBell;
        }

        /// <summary>
        /// detach
        /// </summary>
        /// <param name="shapeObserver"></param>
        public void Detach(IShapeObserver shapeObserver)
        {
            _modelChanged -= shapeObserver.ReceiveBell;
        }

        /// <summary>
        /// notify
        /// </summary>
        public void NotifyModelChanged()
        {
            if (_modelChanged != null)
            {
                _modelChanged();
            }

            if (_commandManagerChanges != null)
            {
                _commandManagerChanges(_commandManager.IsUnDo(), _commandManager.IsReDo());
            }
        }

        /// <summary>
        /// mouse down
        /// </summary>
        /// <param name="shapeType"></param>
        /// <param name="point"></param>
        public virtual void MouseDown(ShapeType shapeType, Point point)
        {
            if (PointFunction.IsBothNotNegative(point))
            {
                _state.MouseDown(shapeType, point, pages, _nowCanvas);
                _isPressed = true;
            }
        }

        /// <summary>
        /// mouse up
        /// </summary>
        /// <param name="point"></param>
        public virtual void MouseUp(Point point)
        {
            if (_isPressed)
            {
                _state.MouseUp(point, pages, _commandManager);
                _isPressed = false;
                NotifyModelChanged();
            }
        }

        /// <summary>
        /// mouse up
        /// </summary>
        /// <param name="point"></param>
        public virtual void MouseMove(Point point)
        {
            _state.MouseMove(point, _isPressed, pages);
            NotifyModelChanged();
        }
        #endregion

        /// <summary>
        /// Add newShape with type, info is random
        /// </summary>
        /// <param name="type"></param>
        public virtual void Add(ShapeType shapeType)
        {
            pages.Add(ShapeFactory.CreateByRandom(shapeType, CANVAS_MAX, _nowCanvas, _commandManager));
            NotifyModelChanged();
        }

        /// <summary>
        /// Add newShape with type and two point
        /// </summary>
        /// <param name="type"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public virtual void Add(ShapeType type, Point start, Point end)
        {
            pages.Add(ShapeFactory.CreateShape(type, start, end, _nowCanvas));
            _commandManager.AddShape(type, start, end, _nowCanvas);
            NotifyModelChanged();
        }

        /// <summary>
        /// remove from list by index
        /// </summary>
        /// <param name="rowIndex"></param>
        public virtual void RemoveIndex(int rowIndex)
        {
            if (rowIndex < pages.Count)
            {
                _commandManager.Delete(rowIndex);
                pages.RemoveAt(rowIndex);
                _state.Reset();
                NotifyModelChanged();
            }
        }

        /// <summary>
        /// delete
        /// </summary>
        public virtual void DeletePress()
        {
            _state.DeletePress(pages, _commandManager);
            NotifyModelChanged();
        }

        /// <summary>
        /// a
        /// </summary>
        public void Undo()
        {
            _commandManager.Undo(pages);
            _state.Reset();
            NotifyModelChanged();
        }

        /// <summary>
        /// a
        /// </summary>
        public void Redo()
        {
            _commandManager.Redo(pages);
            NotifyModelChanged();
        }

    }
}