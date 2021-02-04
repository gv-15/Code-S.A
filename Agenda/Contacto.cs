using System;

/// <summary>
/// Summary description for Class1
/// </summary>

namespace Agenda { 
public class Contacto
{
	public String Nombre;
	public int Telefono;
	public String Email;

	public Contacto(String nombre, int telefono, String email)
	{
		Nombre = nombre;
		Telefono = telefono;
		Email = email;
	}

	public String GetNombre()
    {
		return Nombre;
    }

	public void SetNombre(String nombre)
	{
		Nombre = nombre;
	}


	public int GetTelefono()
	{
		return Telefono;
	}

	public void SetTelefono(int telefono)
	{
		Telefono = telefono;
	}

	public String GetEmail()
	{
		return Email;
	}

	public void SetEmail(String email)
	{
		Email = email;
	}
}
}
