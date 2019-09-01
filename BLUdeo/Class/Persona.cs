using DALUdeO.DataClass;
using DALUdeO.Reader;
using Modelos.Persona;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLUdeo.Class
{
    public class Persona
    {
        public Collection<PersonaModel> GetPersonaByID()
        {
            PersonaModel personaModel = new PersonaModel
            {
                IdPersona = 1,
                Apellido = "Shark",
                Nombre = "Quintuss",
                Direccion = "Zona 1",
                FecNac = DateTime.Now
            };
            PersonaReader persona = new PersonaReader(QuerysRepo.TipoQuery.PorId, personaModel);
            Collection<PersonaModel> people = persona.Execute();
            return people;
        }
    }
}
