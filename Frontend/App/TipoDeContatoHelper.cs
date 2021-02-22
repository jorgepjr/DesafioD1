using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace App
{
    public static class TipoDeContatoHelper
    {
        public static string Descricao(this int valor)
        {
            return valor switch
            {
                1 => "Telefone Comercial",
                2 => "Telefone Residencial",
                3 => "Celular",
                4 => "Email",
                5 => "Rede Social",
                _ => "",
            };
        }
    }
}