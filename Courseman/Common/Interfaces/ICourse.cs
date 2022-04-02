using System;
using Courseman.Common.Classes;

namespace Courseman.Common.Interfaces
{
	public interface ICourse
	{
		public string Name { get; set; }

		public Academician Academician { get; set; }
		public ArraySegment<Student> Students { get; set; }
	}
}

