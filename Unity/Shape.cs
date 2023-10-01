using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unity
{
    public class Shape
    {
        private List<Number2> _info = new List<Number2>();
        private ShapeType _shapeType;

        public Shape(Number2 start, Number2 end)
        {
            SetInfo(start, end);
        }

        public ShapeType ShapeType
        {
            get 
            {
                return _shapeType; 
            }
            set 
            {
                _shapeType = value;
            }
        }

        /// <summary>
        /// set two point at once
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private Shape SetInfo(Number2 start, Number2 end)
        {
            _info.Add(start);
            _info.Add(end);
            return this;
        }

        /// <summary>
        /// getter
        /// </summary>
        /// <returns></returns>
        public virtual List<Number2> GetInfo()
        {
            return _info;
        }

        /// <summary>
        /// get info but string
        /// </summary>
        /// <returns></returns>
        public virtual string GetInfoString()
        {
            string result = "";
            foreach (var i in _info)
            {
                result += i.ToString();
            }
            return result;
        }

        /// <summary>
        /// get shape name string
        /// </summary>
        /// <returns></returns>
        public virtual string GetShapeName()
        {
            return _shapeType.ToString();
        }
    }
}