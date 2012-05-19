﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machete.Data.Infrastructure;
using Machete.Domain;
using NLog;

namespace Machete.Service
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IService<T> where T : Record
    {
        T Get(int id);
        IEnumerable<T> GetAll();
        T Create(T record, string user);
        void Delete(int id, string user);
        void Save(T record, string user);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ServiceBase<T> where T : Record
    {
        protected readonly IRepository<T> repo;
        protected readonly IUnitOfWork uow;
        protected Logger nlog = LogManager.GetCurrentClassLogger();
        protected LogEventInfo levent = new LogEventInfo(LogLevel.Debug, "Service", "");
        /// <summary>
        /// replace with service-specific string for logging
        /// </summary>
        protected string logPrefix = "ServiceBase";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="repo"></param>
        /// <param name="uow"></param>
        protected ServiceBase(IRepository<T> repo, IUnitOfWork uow)
        {
            this.repo = repo;
            this.uow = uow;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetAll() 
        {
            return repo.GetAll();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual T Get(int id)
        {
            return repo.GetById(id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="record"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public virtual T Create(T record, string user)
        {
            record.createdby(user);
            T created = repo.Add(record);
            uow.Commit();
            log(record.ID, user, logPrefix + " created");
            return created;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        public void Delete(int id, string user)
        {
            T record = repo.GetById(id);
            repo.Delete(record);
            log(id, user, logPrefix + " deleted");
            uow.Commit();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="record"></param>
        /// <param name="user"></param>
        public virtual void Save(T record, string user)
        {
            record.updatedby(user);
            log(record.ID, user, logPrefix + " edited");
            uow.Commit();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="user"></param>
        /// <param name="msg"></param>
        protected void log(int ID, string user, string msg)
        {
            levent.Level = LogLevel.Info;
            levent.Message = msg;
            levent.Properties["RecordID"] = ID; //magic string maps to NLog config
            levent.Properties["username"] = user;
            nlog.Log(levent);
        }

    }
    /// <summary>
    /// Case insensitive on iEnumerable LINQ joins (L2E handles iQueryable)
    /// </summary>
    public static class String
    {
        public static bool ContainsOIC(this string source, string toCheck)
        {
            if (toCheck == null || source == null) return false;
            return source.IndexOf(toCheck, StringComparison.OrdinalIgnoreCase) >= 0;
        }

    }
}