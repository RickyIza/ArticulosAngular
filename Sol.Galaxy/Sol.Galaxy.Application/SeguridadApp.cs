using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Sol.Galaxy.Data.ServicesData;
using Sol.Galaxy.Domain;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Sol.Galaxy.Application
{
    public class SeguridadApp : ISeguridadApp
    {
        private readonly IUserRepositorio userRepositorio;
        private readonly IUserOptionRepositorio userOptionRepositorio;
        private readonly IMapper mapper;

        public SeguridadApp(
            IUserRepositorio userRepositorio, IUserOptionRepositorio userOptionRepositorio, IMapper mapper)
        {
            this.userRepositorio = userRepositorio;
            this.userOptionRepositorio = userOptionRepositorio;
            this.mapper = mapper;

        }
        public async Task<UserAutenticateResponse> Autentica(UserAutenticaRequest userAutenticaRequest)
        {
            var user = await userRepositorio.Autentica(userAutenticaRequest.User, userAutenticaRequest.Password);
            if (user == null)
            {
                return null;
            }

            //Paso 1: Generar la semilla
            string semilla = "EstaEsUnaClaveMuyLargaQueCumpleConElRequisitoDe256BitsParaHmacSha256";
            byte[] semillaByte = Encoding.UTF8.GetBytes(semilla);
            SymmetricSecurityKey key = new SymmetricSecurityKey(semillaByte);

            //Paso 2: Crear el algoritmo 
            var encripta = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //Paso 3: Crear el Payload
            var misClaims = new[] {
                new Claim("id", user.UserId.ToString()),
                new Claim("user", userAutenticaRequest.User),
                new Claim("rol", user.UserRol)
            };

            //Paso 4: Crear el generador de token
            JwtSecurityToken generador = new JwtSecurityToken(
                claims: misClaims,
                signingCredentials: encripta,
                expires: DateTime.Now.AddMinutes(10),
                issuer: "galaxy.com",
                audience: "galaxy.com"
                );

            string tk = new JwtSecurityTokenHandler().WriteToken(generador);

            UserAutenticateResponse response = new UserAutenticateResponse()
            {
                Token = tk,
                Id = user.UserId
            };
            return response;
        }

        public async Task<List<Opcion>> OpcionesPorUsuario(int userId)
        {
            List<Opcion> opcions = new List<Opcion>();
            var res = await userOptionRepositorio.getOptionByUser(userId);
            if (res != null && res.Count > 0)
            {
                opcions = mapper.Map<List<Opcion>>(res);
            }
            return opcions;
        }
    }
}
