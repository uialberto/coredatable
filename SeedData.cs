using CoreWebApp.DataAccess.UnitOfWork;
using CoreWebApp.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApp
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider services)
        {
            await AddTestData(services.GetRequiredService<AppUnitOfWork>());
        }

        public static async Task AddTestData(AppUnitOfWork context)
        {
            if (context.Personas.Any())
            {
                return;
            }

            var testData = new List<Persona>()
            {
                new Persona
                {
                   Nombres = Guid.NewGuid().ToString().Substring(0,8),
                   Apellidos = Guid.NewGuid().ToString().Substring(0,10),
                   Cargo = Position.Accountant,
                   Oficina = "Santa Cruz",
                   Experiencia = 1,
                   FechaInicio = new DateTime(2020,01,01),
                   Salario = new Random().Next(1000,15000),
                },
                 new Persona
                {
                   Nombres = Guid.NewGuid().ToString().Substring(0,8),
                   Apellidos = Guid.NewGuid().ToString().Substring(0,10),
                   Cargo = Position.Accountant,
                   Oficina = "Santa Cruz",
                   Experiencia = 1,
                   FechaInicio = new DateTime(2020,01,01),
                   Salario = new Random().Next(1000,15000),
                },
                    new Persona
                {
                   Nombres = Guid.NewGuid().ToString().Substring(0,8),
                   Apellidos = Guid.NewGuid().ToString().Substring(0,10),
                   Cargo = Position.Accountant,
                   Oficina = "Santa Cruz",
                   Experiencia = 1,
                   FechaInicio = new DateTime(2020,01,01),
                   Salario = new Random().Next(1000,15000),
                },
                      new Persona
                {
                   Nombres = Guid.NewGuid().ToString().Substring(0,8),
                   Apellidos = Guid.NewGuid().ToString().Substring(0,10),
                   Cargo = Position.Accountant,
                   Oficina = "Santa Cruz",
                   Experiencia = 1,
                   FechaInicio = new DateTime(2020,01,01),
                   Salario = new Random().Next(1000,15000),
                },
                        new Persona
                {
                   Nombres = Guid.NewGuid().ToString().Substring(0,8),
                   Apellidos = Guid.NewGuid().ToString().Substring(0,10),
                   Cargo = Position.Accountant,
                   Oficina = "Cochabamba",
                   Experiencia = 1,
                   FechaInicio = new DateTime(2020,01,01),
                   Salario = new Random().Next(1000,15000),
                },
                          new Persona
                {
                   Nombres = Guid.NewGuid().ToString().Substring(0,8),
                   Apellidos = Guid.NewGuid().ToString().Substring(0,10),
                   Cargo = Position.Accountant,
                   Oficina = "Cochabamba",
                   Experiencia = 1,
                   FechaInicio = new DateTime(2020,01,01),
                   Salario = new Random().Next(1000,15000),
                },
                            new Persona
                {
                   Nombres = Guid.NewGuid().ToString().Substring(0,8),
                   Apellidos = Guid.NewGuid().ToString().Substring(0,10),
                   Cargo = Position.Accountant,
                   Oficina = "Cochabamba",
                   Experiencia = 1,
                   FechaInicio = new DateTime(2020,01,01),
                   Salario = new Random().Next(1000,15000),
                },
                              new Persona
                {
                   Nombres = Guid.NewGuid().ToString().Substring(0,8),
                   Apellidos = Guid.NewGuid().ToString().Substring(0,10),
                   Cargo = Position.Accountant,
                   Oficina = "Cochabamba",
                   Experiencia = 1,
                   FechaInicio = new DateTime(2020,01,01),
                   Salario = new Random().Next(1000,15000),
                },
                                new Persona
                {
                   Nombres = Guid.NewGuid().ToString().Substring(0,8),
                   Apellidos = Guid.NewGuid().ToString().Substring(0,10),
                   Cargo = Position.Accountant,
                   Oficina = "La Paz",
                   Experiencia = 1,
                   FechaInicio = new DateTime(2020,01,01),
                   Salario = new Random().Next(1000,15000),
                },
                                  new Persona
                {
                   Nombres = Guid.NewGuid().ToString().Substring(0,8),
                   Apellidos = Guid.NewGuid().ToString().Substring(0,10),
                   Cargo = Position.Accountant,
                   Oficina = "La Paz",
                   Experiencia = 1,
                   FechaInicio = new DateTime(2020,01,01),
                   Salario = new Random().Next(1000,15000),
                },
                                    new Persona
                {
                   Nombres = Guid.NewGuid().ToString().Substring(0,8),
                   Apellidos = Guid.NewGuid().ToString().Substring(0,10),
                   Cargo = Position.Accountant,
                   Oficina = "La Paz",
                   Experiencia = 1,
                   FechaInicio = new DateTime(2020,01,01),
                   Salario = new Random().Next(1000,15000),
                },
                                      new Persona
                {
                   Nombres = Guid.NewGuid().ToString().Substring(0,8),
                   Apellidos = Guid.NewGuid().ToString().Substring(0,10),
                   Cargo = Position.Accountant,
                   Oficina = "La Paz",
                   Experiencia = 1,
                   FechaInicio = new DateTime(2020,01,01),
                   Salario = new Random().Next(1000,15000),
                },
                                        new Persona
                {
                   Nombres = Guid.NewGuid().ToString().Substring(0,8),
                   Apellidos = Guid.NewGuid().ToString().Substring(0,10),
                   Cargo = Position.Accountant,
                   Oficina = "La Paz",
                   Experiencia = 1,
                   FechaInicio = new DateTime(2020,01,01),
                   Salario = new Random().Next(1000,15000),
                },
                                          new Persona
                {
                   Nombres = Guid.NewGuid().ToString().Substring(0,8),
                   Apellidos = Guid.NewGuid().ToString().Substring(0,10),
                   Cargo = Position.Accountant,
                   Oficina = "La Paz",
                   Experiencia = 1,
                   FechaInicio = new DateTime(2020,01,01),
                   Salario = new Random().Next(1000,15000),
                },
                                            new Persona
                {
                   Nombres = Guid.NewGuid().ToString().Substring(0,8),
                   Apellidos = Guid.NewGuid().ToString().Substring(0,10),
                   Cargo = Position.Accountant,
                   Oficina = "La Paz",
                   Experiencia = 1,
                   FechaInicio = new DateTime(2020,01,01),
                   Salario = new Random().Next(1000,15000),
                },
                new Persona
                {
                   Nombres = Guid.NewGuid().ToString().Substring(0,8),
                   Apellidos = Guid.NewGuid().ToString().Substring(0,10),
                   Cargo = Position.Accountant,
                   Oficina = "Oruro",
                   Experiencia = 1,
                   FechaInicio = new DateTime(2020,01,01),
                   Salario = new Random().Next(1000,15000),
                },
                new Persona
                {
                   Nombres = Guid.NewGuid().ToString().Substring(0,8),
                   Apellidos = Guid.NewGuid().ToString().Substring(0,10),
                   Cargo = Position.Accountant,
                   Oficina = "Oruro",
                   Experiencia = 1,
                   FechaInicio = new DateTime(2020,01,01),
                   Salario = new Random().Next(1000,15000),
                },
                new Persona
                {
                   Nombres = Guid.NewGuid().ToString().Substring(0,8),
                   Apellidos = Guid.NewGuid().ToString().Substring(0,10),
                   Cargo = Position.Accountant,
                   Oficina = "Oruro",
                   Experiencia = 1,
                   FechaInicio = new DateTime(2020,01,01),
                   Salario = new Random().Next(1000,15000),
                },
                new Persona
                {
                   Nombres = Guid.NewGuid().ToString().Substring(0,8),
                   Apellidos = Guid.NewGuid().ToString().Substring(0,10),
                   Cargo = Position.Accountant,
                   Oficina = "Oruro",
                   Experiencia = 1,
                   FechaInicio = new DateTime(2020,01,01),
                   Salario = new Random().Next(1000,15000),
                },
                new Persona
                {
                   Nombres = Guid.NewGuid().ToString().Substring(0,8),
                   Apellidos = Guid.NewGuid().ToString().Substring(0,10),
                   Cargo = Position.Accountant,
                   Oficina = "Oruro",
                   Experiencia = 1,
                   FechaInicio = new DateTime(2020,01,01),
                   Salario = new Random().Next(1000,15000),
                },
            };
            context.Personas.AddRange(testData);
            await context.SaveChangesAsync();
        }
    }
}
