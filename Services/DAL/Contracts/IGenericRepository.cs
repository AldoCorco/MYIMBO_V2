using Services.DomainModel;
using Services.DomainModel.CompositeSeguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DAL.Contracts
{
    internal interface IGenericRepository<T>
    {
        bool Add(T obj);
        bool Update(T obj);
        bool Delete(Guid id);
        IEnumerable<T> SelectAll();
        T SelectOne(Guid id);
        T SelectOneByName(string name);
        T SelectOneSesion(string name);
        
        /// <summary>
        /// Obtengo el listado de Permisos
        /// </summary>
        /// <returns></returns>
        List<Patente> ObtenerPatentes();

        /// <summary>
        /// Obtengo el listado de Roles
        /// </summary>
        /// <returns></returns>
        List<Familia> ObtenerFamilias();

        bool UnirUsuarioPatente(Guid idUsuario, Guid idPatente);

        bool BorrarUsuarioPatente(Guid idUsuario, Guid idPatente);

        bool UnirUsuarioFamilia(Guid idUsuario, Guid idFamilia);

        bool UnirFamilias(Guid idFamilia, Guid idFamiliaHijo, DateTime fechaCreacion);

        bool AgregarFamiliaPatente(Guid idFamilia, Guid idPatente, DateTime fechaCreacionFP);

        Patente SelectOne(Patente patenteId);
        Usuario ObtenerPorId(Guid idUsuario);
        bool ExisteRol(string nombreRol);
        bool ExisteUsuarioRol(string usuNom, string nombreRol);
        bool ExistePermiso(string nombrePermiso);
        List<Familia> ObtenerFamiliasPorUsuario(Guid usuarioId);

        List<Patente> ObtenerPatentesPorUsuario(Guid usuarioId);

        List<UsuarioPatente> ListarUsuarioPermisos();

        //List<PatenteFamilia> ListarRolesPermisos();

        //void UnirFamiliaPatente(Guid idFamilia, Guid idPatente);

        //bool FamiliaPatenteUnir(Guid idFamilia, PatenteFamilia patenteFamilia);
        //bool FamiliaPatenteUnir(Guid idFamilia, Guid idPatente);
        //List<Familia> ListarPatenteFamilia();
    }
}
