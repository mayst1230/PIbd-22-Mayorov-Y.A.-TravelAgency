using TravelAgencyBusinnesLogic.BindingModels;
using TravelAgencyBusinnesLogic.Interfaces;
using TravelAgencyBusinnesLogic.ViewModels;
using TravelAgencyDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TravelAgencyDatabaseImplement.Implements
{
    public class AgencyStorage : IAgencyStorage
    {
        private Agency CreateModel(AgencyBindingModel model, Agency travelagency, TravelAgencyDatabase context)
        {
            travelagency.TravelAgencyName = model.AgencyName;
            travelagency.FullNameResponsible = model.FullNameResponsible;

            if (travelagency.Id == 0)
            {
                travelagency.DateCreate = DateTime.Now;
                context.TravelAgencies.Add(travelagency);
                context.SaveChanges();
            }

            if (model.Id.HasValue)
            {
                List<AgencyCondition> TravelAgencyConditions = context.TravelAgencyConditions
                    .Where(rec => rec.TravelAgencyId == model.Id.Value)
                    .ToList();

                context.TravelAgencyConditions.RemoveRange(TravelAgencyConditions
                    .Where(rec => !model.AgencyTravels.ContainsKey(rec.ConditionId))
                    .ToList());
                context.SaveChanges();

                foreach (AgencyCondition updateCondition in TravelAgencyConditions)
                {
                    updateCondition.Count = model.AgencyTravels[updateCondition.ConditionId].Item2;
                    model.AgencyTravels.Remove(updateCondition.ConditionId);
                }
                context.SaveChanges();
            }


            foreach (KeyValuePair<int, (string, int)> TravelAgencyCondition in model.AgencyTravels)
            {
                context.TravelAgencyConditions.Add(new AgencyCondition
                {
                    TravelAgencyId = travelagency.Id,
                    ConditionId = TravelAgencyCondition.Key,
                    Count = TravelAgencyCondition.Value.Item2
                });
                context.SaveChanges();
            }

            return travelagency;
        }

        public List<AgencyViewModel> GetFullList()
        {
            using (var context = new TravelAgencyDatabase())
            {
                return context.TravelAgencies
                    .Include(rec => rec.TravelAgencyConditions)
                    .ThenInclude(rec => rec.Condition)
                    .ToList()
                    .Select(rec => new AgencyViewModel
                    {
                        Id = rec.Id,
                        AgencyName = rec.TravelAgencyName,
                        FullNameResponsible = rec.FullNameResponsible,
                        CreationDate = rec.DateCreate,
                        AgencyConditions = rec.TravelAgencyConditions
                            .ToDictionary(recAgencyCondition => recAgencyCondition.ConditionId,
                            recAgencyConditions => (recAgencyConditions.Condition?.ConditionName,
                            recAgencyConditions.Count))
                    })
                    .ToList();
            }
        }

        public List<AgencyViewModel> GetFilteredList(AgencyBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new TravelAgencyDatabase())
            {
                return context.TravelAgencies
                    .Include(rec => rec.TravelAgencyConditions)
                    .ThenInclude(rec => rec.Condition)
                    .Where(rec => rec.TravelAgencyName.Contains(model.AgencyName))
                    .ToList()
                    .Select(rec => new AgencyViewModel
                    {
                        Id = rec.Id,
                        AgencyName = rec.TravelAgencyName,
                        FullNameResponsible = rec.FullNameResponsible,
                        CreationDate = rec.DateCreate,
                        AgencyConditions = rec.TravelAgencyConditions
                            .ToDictionary(recAgencyCondition => recAgencyCondition.ConditionId,
                            recAgencyConditions => (recAgencyConditions.Condition?.ConditionName,
                            recAgencyConditions.Count))
                    })
                    .ToList();
            }
        }

        public AgencyViewModel GetElement(AgencyBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new TravelAgencyDatabase())
            {
                Agency TravelAgency = context.TravelAgencies
                    .Include(rec => rec.TravelAgencyConditions)
                    .ThenInclude(rec => rec.Condition)
                    .FirstOrDefault(rec => rec.TravelAgencyName == model.AgencyName ||
                    rec.Id == model.Id);

                return TravelAgency != null ?
                    new AgencyViewModel
                    {
                        Id = TravelAgency.Id,
                        AgencyName = TravelAgency.TravelAgencyName,
                        FullNameResponsible = TravelAgency.FullNameResponsible,
                        CreationDate = TravelAgency.DateCreate,
                        AgencyConditions = TravelAgency.TravelAgencyConditions
                            .ToDictionary(recAgencyCondition => recAgencyCondition.ConditionId,
                            recAgencyConditions => (recAgencyConditions.Condition?.ConditionName,
                            recAgencyConditions.Count))
                    } :
                    null;
            }
        }

        public void Insert(AgencyBindingModel model)
        {
            using (var context = new TravelAgencyDatabase())
            {
                using (Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        CreateModel(model, new Agency(), context);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Update(AgencyBindingModel model)
        {
            using (var context = new TravelAgencyDatabase())
            {
                using (Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Agency travelagency = context.TravelAgencies.FirstOrDefault(rec => rec.Id == model.Id);

                        if (travelagency == null)
                        {
                            throw new Exception("Склад не найден");
                        }

                        CreateModel(model, travelagency, context);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Delete(AgencyBindingModel model)
        {
            using (var context = new TravelAgencyDatabase())
            {
                Agency travelagency = context.TravelAgencies.FirstOrDefault(rec => rec.Id == model.Id);

                if (travelagency == null)
                {
                    throw new Exception("Склад не найден");
                }
                context.TravelAgencies.Remove(travelagency);
                context.SaveChanges();
            }
        }

        public bool TakeFromTravelAgency(Dictionary<int, (string, int)> conditions, int travelCount)
        {
            using (var context = new TravelAgencyDatabase())
            {
                using (Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (KeyValuePair<int, (string, int)> travelAgencyCondition in conditions)
                        {
                            int count = travelAgencyCondition.Value.Item2 * travelCount;
                            IEnumerable<AgencyCondition> travelAgencyConditions = context.TravelAgencyConditions.Where(travelagency => travelagency.ConditionId == travelAgencyCondition.Key);
                            int availableCount = travelAgencyConditions.Sum(travelagency => travelagency.Count);
                            if (availableCount < count)
                            {
                                throw new Exception("Недостаточно условий поездок на складе");
                            }

                            foreach (AgencyCondition condition in travelAgencyConditions)
                            {
                                if (condition.Count <= count)
                                {
                                    count -= condition.Count;
                                    context.TravelAgencyConditions.Remove(condition);
                                    context.SaveChanges();
                                }
                                else
                                {
                                    condition.Count -= count;
                                    context.SaveChanges();
                                    count = 0;
                                }

                                if (count == 0)
                                {
                                    break;
                                }
                            }
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }
    }
}
