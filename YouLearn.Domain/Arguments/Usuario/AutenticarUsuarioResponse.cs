﻿using System;
using System.Collections.Generic;
using System.Text;
using YouLearn.Domain.Entities;

namespace YouLearn.Domain.Arguments.Usuario
{
    public class AutenticarUsuarioResponse
    {
        public AutenticarUsuarioResponse()
        {
        }

        public AutenticarUsuarioResponse(Guid id, string primeiroNome)
        {
            Id = id;
            PrimeiroNome = primeiroNome;
        }

        public Guid Id { get; set; }

        public string PrimeiroNome { get; set; }

        public static explicit operator AutenticarUsuarioResponse(Entities.Usuario entidade)
        {
            return new AutenticarUsuarioResponse()
            {
                Id = entidade.Id,
                PrimeiroNome = entidade.Nome.PrimeiroNome
            };
        }
    }
}
