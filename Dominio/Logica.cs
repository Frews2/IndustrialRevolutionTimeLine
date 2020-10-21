using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Logica
    {
		//Lista de meses con 31 dias
		List<int> meses31 = new List<int>();

		public Logica() {

			meses31.Add(1);
			meses31.Add(3);
			meses31.Add(5);
			meses31.Add(7);
			meses31.Add(8);
			meses31.Add(10);
			meses31.Add(12);
		}

		public bool esBiciesto(int anio)
		{
			return (anio % 4 == 0 && anio % 100 != 0) || (anio % 400 == 0) ? true : false;
		}

		public bool esFebrero(int mes)
		{
			return mes == 2 ? true : false;
		}

		public bool esFechaValida(int anio, int mes, int dia)
		{
			bool esValida = false;

			if (anio >= 1700 && anio <= 2100)
			{
				if (mes >= 1 && mes <= 12)
				{
					if (mes == 2)
					{
						if (esBiciesto(anio) && (dia >= 1 && dia <= 29))
						{
							esValida = true;
						}
						else if (dia >= 1 && dia <= 28)
						{
							esValida = true;
						}
					}
					else
					{
						if (meses31.Contains(mes))
						{
							if ((dia >= 1 && dia <= 31))
							{
								esValida = true;
							}
						}
						else
						{
							if ((dia >= 1 && dia <= 30))
							{
								esValida = true;
							}
						}
					}

				}

			}

			return esValida;
		}

		
    }
}
