using Esferas.Entidades;

namespace Esferas.Datos
{
  
}
public class RepositorioEsferas
{
    private List<Esfera> esferas;

    public RepositorioEsferas()
    {
        esferas = new List<Esfera>();
    }

    public void AgregarEsfera(Esfera esfera)
    {

        if (!EsferaDuplicada(esfera))
        {
            esferas.Add(esfera);
        }
        else
        {
            Console.WriteLine("Error: Esfera duplicada.");
        }
    }

    private bool EsferaDuplicada(Esfera esfera)
    {
        return esferas.Any(e => e.Radio == esfera.Radio);
    }

    public void BorrarEsfera(Esfera esfera)
    {
        esferas.Remove(esfera);
    }

    public void ActualizarEsfera(Esfera esferaAntigua, Esfera esferaNueva)
    {
        BorrarEsfera(esferaAntigua);
        AgregarEsfera(esferaNueva);
    }

    public List<Esfera> ObtenerEsferas()
    {
        return esferas;
    }

    public void Ordenar(bool ascendente)
    {
        if (ascendente)
        {
            esferas = esferas.OrderBy(e => e.Radio).ToList();
        }
        else
        {
            esferas = esferas.OrderByDescending(e => e.Radio).ToList();
        }
    }

    public void FiltrarPorColor(ColorEsfera color)
    {
        esferas = esferas.Where(e => e.ColorRelleno == color).ToList();
    }

    public void RestaurarDatosOriginales()
    {

    }

    public void PersistirEnArchivo(string nombreArchivo)
    {

        using (StreamWriter writer = new StreamWriter(nombreArchivo))
        {
            foreach (var esfera in esferas)
            {
                writer.WriteLine($"{esfera.Radio},{esfera.ColorRelleno},{esfera.TipoDeTrazo}");
            }
        }
    }

    public void RecuperarDesdeArchivo(string nombreArchivo)
    {

        try
        {
            using (StreamReader reader = new StreamReader(nombreArchivo))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var partes = line.Split(',');
                    if (partes.Length == 3)
                    {
                        double radio = Convert.ToDouble(partes[0]);
                        ColorEsfera color = (ColorEsfera)Enum.Parse(typeof(ColorEsfera), partes[1]);
                        TipoTrazo trazo = (TipoTrazo)Enum.Parse(typeof(TipoTrazo), partes[2]);

                        AgregarEsfera(new Esfera(radio, color, trazo));
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al recuperar desde el archivo: {ex.Message}");
        }
    }
}
