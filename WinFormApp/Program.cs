﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormApp.Forms;
using WinFormsApp.Forms;

namespace WinFormApp
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new FrmPrincipal());

            //En el campo name del formulario obtengo el nombre que va.
            Application.Run(new FrmLogin());
            //Application.Run(new FrmGestorUsuarios());
        }
    }
}
