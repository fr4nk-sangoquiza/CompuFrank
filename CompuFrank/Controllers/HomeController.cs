using CompuFrank.Data;
using CompuFrank.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;

namespace CompuFrank.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }



        /*  CAROUSEL QUE USA IMG DE PRODUCTOS */

        //private readonly ApplicationDbContext _context;

        //public HomeController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.compu_articulos.ToListAsync());
        //    //return View();
        //}

        /*************************************/


        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ordenadores()      //NEW GET  Home/*.cshtml
        {
            return View();
        }

        public IActionResult software()         //NEW GET  Home/*.cshtml
        {
            return View();
        }

        public IActionResult perifericos()      //NEW GET  Home/*.cshtml
        {
            return View();
        }

        public IActionResult accesorios()      //NEW GET  Home/*.cshtml
        {
            return View();
        }

        public IActionResult contacto()         // MÉTODO GET. Entra a este fichero y me va a retornar la página
        {                                       // creada Home/contacto.cshtml
            return View();
        }


        /*
        [HttpPost]                             // MÉTODO POST, para que el 'enviar' pueda subir la información
        public IActionResult Contacto(string NOMBRE, string APELLIDO, string EMAIL, string TELEFONO, string MENSAJE)
        {
            enviarCorreo(NOMBRE, APELLIDO, EMAIL, TELEFONO, MENSAJE);

            ViewBag.clave = "¡GRACIAS POR CONTACTAR CON NOSOTROS! En breve nos pondremos en contacto con usted.";

            return View();
        }
        */


                        /* MÉTODO PARA ENVIAR LOS DATOS DEL FORMULARIO */
        /*
        public void enviarCorreo(string nombre, string apellido, string email, string telefono, string mensaje)
        {

            string DireccionOrigen = "fguillermo28sm@gmail.com"; //habrá que configurar nuestro gmail cambiando la seg permitiendo aplicaciones menos seguras

            MailMessage message = new MailMessage(); //Representa un mensaje de correo electrónico que se
            //puede enviar con la clase SmtpClient.

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.UseDefaultCredentials = false;
            //string pass = "NO PUDE HACER REFERENCIA A LA CONSTRASEÑA GUARDADA EN EL ADMINISTRADOR DE SECRETOS ";
            string pass =  CompuFrank.Properties.Resources.Password.ToString();
            smtpClient.Credentials = new System.Net.NetworkCredential() //le pasamos las credenciales
            {
                UserName = DireccionOrigen,

                Password = pass
            };

            //Especifique si el objeto SmtpClient utiliza SSL (Secure Sockets Layer) para cifrar la conexión.
            smtpClient.EnableSsl = true; //Es true si el objeto SmtpClient utiliza SSL; en caso contrario, es false.
            //De manera predeterminada, es false.
            message.From = new MailAddress(DireccionOrigen);
            message.To.Add(new MailAddress(DireccionOrigen));
            message.Subject = nombre + "-" + apellido + " - Telefono: " + telefono;
            message.IsBodyHtml = true;
            message.Body = mensaje + "Email: " + email;

            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network; //Especifica la forma en que se controlarán
            //los mensajes de correo electrónico salientes.
            smtpClient.Send(message);

        }
        */
                    /***************************************************************/



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
