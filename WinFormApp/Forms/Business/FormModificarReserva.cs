using System;

namespace WinFormApp.Forms.Business
{
    internal class FormModificarReserva
    {
        public FormModificarReserva(Guid idAlquiler)
        {
            IdAlquiler = idAlquiler;
        }

        public Guid IdAlquiler { get; }
    }
}