﻿using System;

namespace CaixaTroco.Dominio
{
    public class NegocioException : Exception
    {
        public NegocioException(string message)
            : base(message) { }
    }
}
