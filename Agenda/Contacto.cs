using System;

/// <summary>
/// Summary description for Class1
/// </summary>
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

	public String getNombre()
    {
		return Nombre;
    }

	public void setNombre(String nombre)
	{
		Nombre = nombre;
	}


	public int getTelefono()
	{
		return Telefono;
	}

	public void setTelefono(int telefono)
	{
		Telefono = telefono;
	}

	public String getEmail()
	{
		return Email;
	}

	public void setEmail(String email)
	{
		Email = email;
	}
}
