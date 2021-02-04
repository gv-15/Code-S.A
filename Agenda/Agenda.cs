using System;
using System.Collections.Generic;
namespace Agenda
{
	/// <summary>
	/// Summary description for Class1
	/// </summary>
	public class Agenda1
	{

		private List<Contacto> agenda;

		public Agenda1()
		{

			agenda = new List<Contacto>();

		}

		public void add(Contacto contacto)
		{

			agenda.Add(contacto);

		}

		public int size()
		{

			return agenda.Count;
		}

		public Boolean exists(Contacto contacto)
		{

			Boolean existe = false;

			foreach (Contacto c in agenda)
			{

				if (agenda.Contains(c))
				{
					existe = true;

				}

			}

			return existe;
		}

	}
}

