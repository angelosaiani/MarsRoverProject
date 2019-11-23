using MarsRoverProject.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverProject
{
    [Export(typeof(IPosition))]
    public class Position : IPosition
    {
        #region Constructor
        protected Position()
        {
        }
        #endregion

        #region Properties
        public int X { get; set; }
        public int Y { get; set; }
        #endregion

        #region Public methods
        public void Init(int x, int y)
        {
            X = x;
            Y = y;
        }
        #endregion

        public override bool Equals(object obj)
        {
            var pos = obj as Position;
            if (pos == null)
                return false;

            return X == pos.X && Y == pos.Y;
        }

        public override string ToString()
        {
            return string.Format("X:{0},Y:{1}", X, Y);
        }
    }

}
