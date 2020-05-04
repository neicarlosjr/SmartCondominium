using SmartCondominium.Infra;
using SmartCondominium.Models;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartCondominium.Dao
{
    public class UsuarioDao
    {

        public void Adiciona(Usuario usuario)
        {
            usuario.CodVendedor = (usuario.CodVendedor != null ? usuario.CodVendedor : " ");
            using (ISession session = NHibernateHelper.AbreSession())
            {
                ITransaction tx = session.BeginTransaction();
                session.Save(usuario);
                tx.Commit();
            }

        }

        public IList<Usuario> Lista()
        {
            using (ISession session = NHibernateHelper.AbreSession())
            {
                String hql = "select u from Usuario u";
                IQuery query = session.CreateQuery(hql);
                return query.List<Usuario>();
            }

        }

        public Usuario Busca(string login)
        {
            using (ISession session = NHibernateHelper.AbreSession())
            {
                String hql = "Select u from Usuario u where " + " u.Login= :login ";
                IQuery query = session.CreateQuery(hql);

                query.SetParameter("login", login);
                return query.UniqueResult<Usuario>();
            }
        }

        public void Lock(Usuario usuario)
        {
            using (ISession session = NHibernateHelper.AbreSession())
            {
                session.Lock(usuario, LockMode.UpgradeNoWait);
            }
        }

        public void Remove(Usuario usuario)
        {
            using (ISession session = NHibernateHelper.AbreSession())
            {
                ITransaction tx = session.BeginTransaction();
                session.Delete(usuario);
                tx.Commit();
            }



        }
        public void Exclui(Usuario usuario)
        {
            using (ISession session = NHibernateHelper.AbreSession())
            {
                ITransaction tx = session.BeginTransaction();
                session.Delete(usuario);
                tx.Commit();
            }


        }

        public void Atualiza(Usuario usuario)
        {
            usuario.CodVendedor = (usuario.CodVendedor != null ? usuario.CodVendedor : " ");
            using (ISession session = NHibernateHelper.AbreSession())
            {

                ITransaction tx = session.BeginTransaction();

                session.Update(usuario);
                tx.Commit();

            }
        }
        public Usuario BuscaPorId(int id)
        {

            using (ISession session = NHibernateHelper.AbreSession())
            {
                return session.Get<Usuario>(id);
            }

        }


    }
}