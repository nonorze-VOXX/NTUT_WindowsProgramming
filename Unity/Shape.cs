using System.Collections.Generic;

namespace Unity
{
    public class Shape
    {
        private ShapeType _shapeType;
        public ShapeType shape
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
        private List<Number2> _info = new List<Number2>();
        public string infomation
        {
            get
            {
                if (_info.Count == 0)
                {
                    return "";
                }
                return _info[0].ToString() + ", " + _info[1].ToString();
            }
        }

        public Shape(Number2 start, Number2 end)
        {
            SetInfo(start, end);
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