﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedIn_CLRReflectionForDevelopers
{
    class Point
    {
        public Point()
        {
			X = 0;
			Y = 0;
        }
		public Point(int x, int y) { X = x; Y = y; }

		public int X { get; set; }
		public int Y { get; set; }

		public static double Distance(Point lhs, Point rhs)
		{
			return Math.Sqrt(
				(Math.Pow((double)rhs.X - (double)lhs.X, 2)) +
				(Math.Pow((double)rhs.Y - (double)lhs.Y, 2)));
		}

		public static Point ORIGIN { get { return new Point(0, 0); } }

		public override string ToString()
		{ return String.Format("({0}, {1})", X, Y); }

		public override bool Equals(object other)
		{
			if (Object.ReferenceEquals(this, other))
				return true;

			if (!(other is Point))
				return false;

			Point rhs = (Point)other;
			return (X == rhs.X) && (Y == rhs.Y);
		}

		public static bool operator ==(Point lhs, Point rhs)
		{ return (lhs.X == rhs.X) && (lhs.Y == rhs.Y); }
		public static bool operator !=(Point lhs, Point rhs)
		{ return !(lhs.X == rhs.X); }
	}
}
