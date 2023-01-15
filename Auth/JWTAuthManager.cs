using Backend.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Auth
{
    public class JWTAuthManager: IJWTAuthManager
    {


        private readonly string tokenKey;


        public JWTAuthManager(string tokenKey)
        {
            this.tokenKey = tokenKey;
        }

        private bool isSamePassword(string inputPass, string savedPass)
        {
            string hashedPass = getStringHash(inputPass).ToLower();
            return hashedPass == savedPass;
        }

        public static string getStringHash(string passwordString)
        {
            HashAlgorithm algorithm = SHA256.Create();
            var hashBytes = algorithm.ComputeHash(Encoding.UTF8.GetBytes(passwordString));
            StringBuilder sb = new StringBuilder();
            foreach (byte b in hashBytes)
                sb.Append(b.ToString("X2"));

            return sb.ToString();

        }



        public LoginResponse Authenticate(string email, string contrasenia, Context context)
        {
            Credenciales credencial;
            Usuarios usuario;
            var credenciales = context.Credenciales.ToList();
            credencial = credenciales.FirstOrDefault(c => c.email == email && isSamePassword(contrasenia, c.contrasenia));
            if (credencial == null) return null;
            var us = context.Usuarios.ToList();
            usuario = us.FirstOrDefault(u => u.idUsuario == credencial.idUsuario);
            var clientes = context.Clientes.ToList();
            Clientes cliente = new Clientes();
            if (usuario == null)
            {
                cliente = clientes.FirstOrDefault(c => c.idClientes == credencial.idCliente);
            }
            

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(tokenKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, credencial.email),
                    new(ClaimTypes.Role, credencial.tipo.ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            if (usuario == null)
            {
                return new LoginResponse()
                {
                    email = credencial.email,
                    tipo = (LoginResponse.TipoUsuario)credencial.tipo,
                    token = tokenHandler.WriteToken(token),
                    id = cliente.idClientes,
                    nombre = cliente.nombre
                };
            }
            else
            {
                return new LoginResponse()
                {
                    email = credencial.email,
                    tipo = (LoginResponse.TipoUsuario)credencial.tipo,
                    token = tokenHandler.WriteToken(token),
                    id = usuario.idUsuario,
                    nombre = usuario.nombre
                };
            }
           
        }



    }
}
