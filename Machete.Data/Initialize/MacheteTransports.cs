﻿using System;
using System.Collections.Generic;
using System.Linq;
using Machete.Domain;
using Microsoft.EntityFrameworkCore;

namespace Machete.Data.Initialize
{
    public static class MacheteTransports
    {
        public static void Initialize(MacheteContext context)
        {
            if (!context.TransportProviders.Any()) {
                string lookups;
                string transportProviders;
                if (context.Database.GetDbConnection().GetType().Name == "SqlConnection") {
                    lookups = @"dbo.Lookups";
                    transportProviders = @"dbo.TransportProviders";
                }
                else {
                    lookups = @"Lookups";
                    transportProviders = "TransportProviders";
                }

                context.Database.ExecuteSqlCommand($@"insert into {transportProviders}
                        ( [key], text_EN, text_ES, defaultAttribute, sortorder, active, datecreated, dateupdated, Createdby, Updatedby )
                            select [key], text_EN, text_ES, selected, sortorder, active, datecreated, dateupdated, Createdby, Updatedby
                            from ${lookups}
                            where category = 'transportmethod'");
                
                context.SaveChanges();
            }

            if (!context.TransportProvidersAvailability.Any()) {
                var providers = context.TransportProviders.ToList();
                foreach (var provider in providers) {
                    provider.AvailabilityRules = new List<TransportProviderAvailability>();
                    for (var dayOfWeek = 0; dayOfWeek < 7; dayOfWeek++) {
                        provider.AvailabilityRules.Add(new TransportProviderAvailability {
                            transportProviderID = provider.ID,
                            day = dayOfWeek,
                            available = dayOfWeek != 0 || (provider.key == "transport_pickup"),
                            datecreated = DateTime.Now,
                            dateupdated = DateTime.Now,
                            createdby = "Init T. Script",
                            updatedby = "Init T. Script"
                        });
                    }
                }

                context.SaveChanges();
            }
        }
    }
}
