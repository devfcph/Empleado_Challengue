using Empleado_Prueba.Entities;
using Microsoft.IdentityModel.Tokens;
using System.Net.Mail;
using System.Reflection;

namespace Empleado_Prueba.Utils
{
    public class EmpleadoValidaciones
    {
        public static Boolean isTelefonoValid(string telefono)
        {
            return telefono.Count() == 10;
        }

        public static Boolean isCorreoElectronicoValid(string correo)
        {
            try
            {
                MailAddress mail = new MailAddress(correo);
                return true;
            }
            catch(FormatException f)
            {
                return false;
            }
        }

        public static Boolean isFechaIngresoValid(string fecha)
        {
            try
            {
                DateTime dateValue;
                return DateTime.TryParse(fecha, result: out dateValue);
                
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public static Boolean isEntityValid(Empleado empleado)
        {
            bool response = true;
            foreach (PropertyInfo propertyInfo in empleado.GetType().GetProperties())
            {


                var info = propertyInfo.GetValue(empleado, null);
                if ( info == null || info.ToString().IsNullOrEmpty())
                {
                    response = false;
                    break;
                }
            }


            return response;
        }


    }
}
