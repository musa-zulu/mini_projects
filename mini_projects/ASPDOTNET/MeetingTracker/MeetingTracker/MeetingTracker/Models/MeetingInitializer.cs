using System;
using System.Collections.Generic;
using System.Data.Entity;
using MeetingTracker.Context;

namespace MeetingTracker.Models
{

    public class MeetingInitializer : DropCreateDatabaseAlways<MeetingContext>
    {
        protected override void Seed(MeetingContext context)
        {
            var meetingType = new List<MeetingType>()
            {
                new MeetingType
                {
                    MeetingTypeDescription = "MANCO",
                },
                   new MeetingType
                {
                    MeetingTypeDescription = "Finance",
                },
                new MeetingType
                {
                    MeetingTypeDescription = "Project Team Leaders",
                }
            };

            foreach (var type in meetingType)
            {
                context.MeetingTypes.Add(type);
            }
            context.SaveChanges();


            var persons = new List<Person>()
            {
                new Person
                {
                    FirstName = "Musa",
                    LastName = "Zulu",
                    Email = "musa@chillisoft.co.za",
                    Address = "some address",
                    
                },
                     new Person
                {
                    FirstName = "Scelumusa",
                    LastName = "Nkosi",
                    Email = "sce@gamil.com",
                    Address = "some address",
                }
            };

            foreach (var person in persons)
            {
                context.Persons.Add(person);
            }
            context.SaveChanges();


            var meetingItems = new List<MeetingItem>()
            {
                new MeetingItem
                {
                        // DueDate = DateTime.Now,
                    MeetingItemDescription = "Meeting Description",
                    Priority = "High",
                    PercentageCompleted = "15%",
                     DueDate = DateTime.Parse("2011-03-21"),
                     PersonId = 1,
                     MeetingItemId = 1,
                     Status = "Normal",
                     StartDate = DateTime.Parse("2011-01-11")
                },

                new MeetingItem
                {
                    MeetingItemDescription = "Meeting Description one",
                   // StartDate = DateTime.Now,
                   // DueDate = DateTime.Now,
                   
                    Priority = "High",
                    PercentageCompleted = "25%",
                 DueDate = DateTime.Parse("2011-03-21"),
                PersonId = 2,
                 MeetingItemId =2, 
                 Status = "Normal",
                   StartDate = DateTime.Parse("2011-01-11")

                }
            };

            foreach (var meetingItem in meetingItems)
            {
                context.MeetingItems.Add(meetingItem);
            }
            context.SaveChanges();

            var meetings = new List<Meeting>()
            {
                new Meeting
                {
                    MeetingDescription = "New Meeting one",
                    MeetingDate = DateTime.Parse("2011-03-21 13:26"),
                    StartTime =  DateTime.Parse("2011-03-21 13:26"),
                    EndTime =  DateTime.Parse("2011-03-21 13:26"),
                    Location = "Chillisoft Offices",
                    MeetingTypeId = 1,
                    MeetingId = 1,
                    
                },
                new Meeting 
                {
                    MeetingDescription = "New Meeting one",
                    MeetingDate = DateTime.Parse("2011-03-21 13:26"),
                    StartTime =  DateTime.Parse("2011-03-21 13:26"),
                    EndTime =  DateTime.Parse("2011-03-21 13:26"),
                    Location = "Chillisoft Offices",
                    MeetingTypeId = 2,
                    MeetingId = 2
                
                }
            };
            foreach (var m in meetings)
            {
                context.Meetings.Add(m);
            }
            context.SaveChanges();

            var meetingItemStatus = new List<MeetingItemStatus>()
            {
                new MeetingItemStatus
                {
                    CurrentStatus = "On Progress",
                    ActionRequired = "Fix Bug",
                    PersonId = 1,
                    MeetingId = 1,
                    MeetingItemId = 1,
                    DateUpdated = DateTime.Parse("2011-03-21 13:26"),
                    MeetingItemStatusId = 1
                    
                },

                   new MeetingItemStatus
                {
                    CurrentStatus = "On Progress",
                    ActionRequired = "Fix Bug",
                    PersonId = 2,
                    MeetingId = 2,
                    MeetingItemId =2,
                    DateUpdated = DateTime.Parse("2011-03-21 13:26"),
                    MeetingItemStatusId = 1
                },
            };
            foreach (var meetingItemStatuse in meetingItemStatus)
            {
                context.MeetingItemStatuses.Add(meetingItemStatuse);
            }
            context.SaveChanges();

        }
    }
}