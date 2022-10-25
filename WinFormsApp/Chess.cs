using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp
{
    internal class Chess : ICloneable
    {
        private Role _role;

        private string _code;

        private string _name;

        private Color _color;

        private Location _positon;

		public string Code
        {
            set
            {
                _code = value;
            }
            get
            {
                return _code;
            }
        }

        public string Name
        {
            set
            {
                _name = value;
            }
            get
            {
                return _name;
            }
        }

        public Role Role
        {
            set { _role = value; }
            get { return _role; }   
        }
        
        public Color Color
        {
            set
            {
                _color = value;
            }
            get
            {
                return _color;
            }
        }
        
        public Chess(string code, string name, Role role, Color color)
        {
            _code = code;
            _name = name;
            _role = role;
            _color = color;
        }

        public Location Position
        {
            set
            {
				_positon = value;
            }
            get
            {
                return _positon;

			}
        }

        public object Clone()
        {
			Random random = new Random();
			Chess chess = new Chess(random.Next().ToString(), this._name, this._role, this._color);
            return chess;
        }
    }
}
