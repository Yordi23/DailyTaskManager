using SQLite;
using System;
public class Activities 
{   
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string RowId { get; set; }
    public bool Pendiente { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public string Lugar { get; set; } 
    public DateTime Fecha { get; set; }
    public Byte Prioridad { get; set; }

    public override string ToString() {

        return string.Format("{0} {1} {2} {3} {4} {5}", Id, Nombre, Lugar, Descripcion, Fecha, Prioridad);
    }
}
