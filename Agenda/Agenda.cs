using System;
using System.Collections.Generic;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Agenda1
{

	private List<Contacto> agenda;

	public Agenda1 {

		agenda = new List<Contacto>();
	
	}

	public void add(Contacto contacto) {

		agenda.add(contacto);	
	
	}

	public int size() {

		return agenda.size();
	}

	public Boolean exists(Contacto contacto) {

		Boolean existe = false;

		foreach Contacto c in agenda {

            if (agenda.contains(c))
            {
				existe = true;

            }

        }

		return existe;
	}

}
