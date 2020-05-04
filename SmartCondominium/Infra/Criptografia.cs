﻿using CryptSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartCondominium.Infra
{

    public class Criptografia
    {
        public static string Codifica(string senha)
        {

            return Crypter.MD5.Crypt(senha);
        }

        public static bool Compara(string senha, string hash)
        {

            return Crypter.CheckPassword(senha, hash);

        }

    }
}